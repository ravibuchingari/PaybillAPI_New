using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Helpers;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class SalesController(
        ISalesRepository salesRepository,
        IPartyRepository partyRepository,
        IItemRepository itemRepository,
        IAdminRepository adminRepository,
        ISharedRepository sharedRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(string? fromDate = null, string? toDate = null)
        {
            string start = string.IsNullOrWhiteSpace(fromDate) ? DateTime.Today.ToString("yyyy-MM-dd") : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate) ? DateTime.Today.ToString("yyyy-MM-dd") : toDate;

            var invoices = (await salesRepository.GetSalesInvoices(ParseDate(start), ParseDate(end))).ToList();
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.IsAdmin = IsAdminUser;

            return View(invoices);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id = null)
        {
            var settings = await adminRepository.GetSettings() ?? new SettingVM();
            var customers = (await partyRepository.GetActiveParties(isVendor: false, isAll: false)).ToList();
            var categories = (await itemRepository.GetCategories()).ToList();
            var gstSlabs = (await itemRepository.GetGsts(isActive: true)).ToList();
            var serviceTypes = (await itemRepository.GetServiceTypes(isAll: false)).ToList();
            var initialItems = (await itemRepository.GetItemsForOffline(isAllItems: false, lastUpdatedTime: null)).ToList();

            SalesVM? existingInvoice = null;
            ResponseMessage? unlockCheck = null;
            if (id.HasValue && id.Value > 0)
            {
                try
                {
                    existingInvoice = await salesRepository.GetSalesInvoiceDetails(id.Value);
                }
                catch
                {
                    existingInvoice = null;
                }
                unlockCheck = await sharedRepository.CheckUnlockRequestStatus(id.Value, null);
            }

            var invoice = existingInvoice ?? new SalesVM
            {
                SalesDate = DateTime.Today.ToString("yyyy-MM-dd"),
                SalesType = settings.IsGstInvoice ? "GST" : "Non-GST",
                PaymentMode = "Cash",
                IsCashSales = true
            };

            var vm = new SalesInvoicePageViewModel
            {
                Invoice = invoice,
                Settings = settings,
                Customers = customers,
                Categories = categories,
                GstSlabs = gstSlabs,
                ServiceTypes = serviceTypes,
                InitialItems = initialItems,
                CompanyGstin = string.IsNullOrWhiteSpace(settings.ReceiptHeaderLine5)
                    ? CurrentCompanyGstin
                    : settings.ReceiptHeaderLine5,
                IsAdmin = IsAdminUser,
                PendingUnlockMessage = unlockCheck != null && !string.Equals(unlockCheck.Message, "NONE", StringComparison.OrdinalIgnoreCase)
                    ? unlockCheck.Message
                    : null
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SaveInvoice([FromBody] SalesVM model)
        {
            if (model == null || model.SalesItems == null || model.SalesItems.Count == 0)
            {
                return Json(new { isSuccess = false, message = "Please add at least one item or service to the invoice." });
            }

            bool isCredit = string.Equals(model.PaymentMode, "Credit", StringComparison.OrdinalIgnoreCase)
                         || string.Equals(model.SalesType, "Credit", StringComparison.OrdinalIgnoreCase)
                         || !model.IsCashSales;

            int selectedPartyId = model.PartyId ?? (model.PartyModel != null ? model.PartyModel.PartyId : 0);
            if (isCredit && selectedPartyId <= 0)
            {
                return Json(new { isSuccess = false, message = "Customer selection is mandatory for Credit invoices. Please select a registered customer." });
            }

            if (selectedPartyId > 0)
            {
                model.PartyId = selectedPartyId;
                model.PartyModel ??= new PartyVM { PartyId = selectedPartyId };
                model.PartyModel.PartyId = selectedPartyId;
            }

            if (string.IsNullOrWhiteSpace(model.SalesDate))
                model.SalesDate = DateTime.Today.ToString("yyyy-MM-dd");

            model.IsCashSales = !isCredit;

            try
            {
                var res = await salesRepository.SaveSalesInvoice(model, CurrentUserRowId);
                int salesId = model.SalesId;
                if (!string.IsNullOrWhiteSpace(res.Data) && int.TryParse(res.Data, out int parsedId) && parsedId > 0)
                {
                    salesId = parsedId;
                }

                return Json(new
                {
                    isSuccess = res.IsSuccess,
                    message = res.Message,
                    salesId
                });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int salesItemId, string remarks)
        {
            if (string.IsNullOrWhiteSpace(remarks))
                return Json(new { isSuccess = false, message = "Audit remarks are required to delete a line item." });

            try
            {
                var res = await salesRepository.DeleteSalesItem(salesItemId, remarks, CurrentUserRowId);
                return Json(new { isSuccess = res.IsSuccess, message = res.Message });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInvoice(int id, string? remarks, string? fromDate, string? toDate)
        {
            string auditRemark = string.IsNullOrWhiteSpace(remarks) ? "Invoice cancelled/deleted by Admin" : remarks;
            try
            {
                SalesVM? details = null;
                try
                {
                    details = await salesRepository.GetSalesInvoiceDetails(id);
                }
                catch
                {
                    details = null;
                }

                if (details != null && details.SalesItems.Count > 0)
                {
                    if (details.IsLocked)
                    {
                        TempData["ErrorMessage"] = "This invoice is locked. Please approve an Unlock Request first before deleting its items.";
                        return RedirectToAction(nameof(Index), new { fromDate, toDate });
                    }

                    foreach (var item in details.SalesItems.Where(i => i.SalesItemId > 0))
                    {
                        var itemDel = await salesRepository.DeleteSalesItem(item.SalesItemId, auditRemark, CurrentUserRowId);
                        if (!itemDel.IsSuccess)
                        {
                            TempData["ErrorMessage"] = itemDel.Message ?? "Failed to remove invoice line items before deletion.";
                            return RedirectToAction(nameof(Index), new { fromDate, toDate });
                        }
                    }
                }

                var res = await salesRepository.DeleteSalesInvoice(id, CurrentUserRowId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Sales invoice deleted successfully.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to delete sales invoice.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { fromDate, toDate });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestUnlock(int salesId, string remarks, string? returnUrl = null)
        {
            try
            {
                var res = await sharedRepository.InsUnlockRequest(new UnlockRequestVM
                {
                    SalesId = salesId,
                    Remarks = string.IsNullOrWhiteSpace(remarks) ? "Request to edit/cancel invoice" : remarks
                }, CurrentUserRowId);

                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Unlock request submitted to Administrator.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Could not submit unlock request.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(Create), new { id = salesId });
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerRewardInfoJson(int partyId)
        {
            if (partyId <= 0)
                return Json(new { availablePoints = 0.0, expiryDate = "" });

            var ptsRes = await partyRepository.GetCustomerAvailablePoints(partyId);
            var expRes = await partyRepository.GetCustomerEarliestUpcomingExpiryDate(partyId);

            double pts = 0.0;
            if (ptsRes != null)
                double.TryParse(ptsRes.Data?.ToString() ?? ptsRes.Message, out pts);

            string expDate = expRes?.Data?.ToString() ?? expRes?.Message ?? string.Empty;

            return Json(new
            {
                availablePoints = pts,
                expiryDate = expDate
            });
        }

        [HttpGet]
        public async Task<IActionResult> Print(int id, string format = "A4")
        {
            PrintSalesInvoice? printInv = null;
            try
            {
                printInv = await salesRepository.GetSalesInvoiceToPrint(id);
            }
            catch
            {
                printInv = null;
            }
            printInv ??= new PrintSalesInvoice { SalesId = id };

            SalesVM? rawInv = null;
            try
            {
                rawInv = await salesRepository.GetSalesInvoiceDetails(id);
            }
            catch
            {
                rawInv = null;
            }

            var header = await sharedRepository.GetPrintHeader();
            var settings = await adminRepository.GetSettings() ?? new SettingVM();
            var customLines = await adminRepository.GetActiveCustomLines();
            var msgRes = await adminRepository.GetSelectedMessageDescription("Sales Invoice");

            double netAmount = printInv.TotalInvoiceAmount > 0 ? printInv.TotalInvoiceAmount : (rawInv?.TotalInvoiceAmount ?? 0);
            string msgTemplate = msgRes?.Data ?? "Thank you for shopping at {CompanyName}! Your Invoice #{InvoiceNo} for Rs. {Amount} is generated.";
            string waMessage = msgTemplate
                .Replace("{CompanyName}", header.HeaderLine1)
                .Replace("{InvoiceNo}", string.IsNullOrWhiteSpace(printInv.InvoiceNo) ? id.ToString() : printInv.InvoiceNo)
                .Replace("{Amount}", netAmount.ToString("N2"));

            var vm = new SalesPrintViewModel
            {
                Invoice = printInv,
                RawInvoice = rawInv,
                Header = header,
                Settings = settings,
                CustomLines = customLines,
                Format = format.ToUpperInvariant(),
                AmountInWords = GstHelper.NumberToWords(netAmount),
                WhatsAppMessage = waMessage
            };

            return View(vm);
        }
    }
}
