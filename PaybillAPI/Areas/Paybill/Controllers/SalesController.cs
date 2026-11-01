using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Models;
using Paybill.ViewModel;
using Paybill.Helpers;
using Paybill.Services;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class SalesController(IPaybillApiService apiService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string? fromDate = null, string? toDate = null)
        {
            string start = string.IsNullOrWhiteSpace(fromDate) ? DateTime.Today.ToString("yyyy-MM-dd") : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate) ? DateTime.Today.ToString("yyyy-MM-dd") : toDate;

            var invoices = await apiService.GetSalesInvoicesAsync(start, end);
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.IsAdmin = apiService.IsAdminUser();

            return View(invoices);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id = null)
        {
            var settingsTask = apiService.GetSettingsAsync();
            var customersTask = apiService.GetActivePartiesAsync(isVendor: false, isAll: false);
            var categoriesTask = apiService.GetCategoriesAsync();
            var gstTask = apiService.GetGstListAsync(isActiveOnly: true);
            var servicesTask = apiService.GetServiceTypesAsync(isAll: false);
            var itemsTask = apiService.GetAllItemsOfflineAsync(isAllItems: false);

            Task<SalesVM?>? invoiceTask = id.HasValue && id.Value > 0
                ? apiService.GetSalesInvoiceDetailsAsync(id.Value)
                : null;
            Task<ResponseMessage>? unlockCheckTask = id.HasValue && id.Value > 0
                ? apiService.CheckUnlockRequestStatusAsync(id.Value, null)
                : null;

            await Task.WhenAll(
                settingsTask,
                customersTask,
                categoriesTask,
                gstTask,
                servicesTask,
                itemsTask,
                invoiceTask ?? Task.FromResult<SalesVM?>(null),
                unlockCheckTask ?? Task.FromResult(new ResponseMessage()));

            var settings = settingsTask.Result;
            var invoice = invoiceTask?.Result ?? new SalesVM
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
                Customers = customersTask.Result,
                Categories = categoriesTask.Result,
                GstSlabs = gstTask.Result,
                ServiceTypes = servicesTask.Result,
                InitialItems = itemsTask.Result,
                CompanyGstin = string.IsNullOrWhiteSpace(settings.ReceiptHeaderLine5)
                    ? apiService.GetCurrentCompanyGstin()
                    : settings.ReceiptHeaderLine5,
                IsAdmin = apiService.IsAdminUser(),
                PendingUnlockMessage = unlockCheckTask?.Result?.IsSuccess == true ? unlockCheckTask.Result.Message : null
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

            if (string.IsNullOrWhiteSpace(model.SalesDate))
                model.SalesDate = DateTime.Today.ToString("yyyy-MM-dd");

            model.IsCashSales = !string.Equals(model.PaymentMode, "Credit", StringComparison.OrdinalIgnoreCase);

            var res = await apiService.SaveSalesInvoiceAsync(model);
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

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int salesItemId, string remarks)
        {
            if (string.IsNullOrWhiteSpace(remarks))
                return Json(new { isSuccess = false, message = "Audit remarks are required to delete a line item." });

            var res = await apiService.DeleteSalesItemAsync(salesItemId, remarks);
            return Json(new { isSuccess = res.IsSuccess, message = res.Message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInvoice(int id, string? remarks, string? fromDate, string? toDate)
        {
            string auditRemark = string.IsNullOrWhiteSpace(remarks) ? "Invoice cancelled/deleted by Admin" : remarks;
            var details = await apiService.GetSalesInvoiceDetailsAsync(id);
            if (details != null && details.SalesItems.Count > 0)
            {
                if (details.IsLocked)
                {
                    TempData["ErrorMessage"] = "This invoice is locked. Please approve an Unlock Request first before deleting its items.";
                    return RedirectToAction(nameof(Index), new { fromDate, toDate });
                }

                foreach (var item in details.SalesItems.Where(i => i.SalesItemId > 0))
                {
                    var itemDel = await apiService.DeleteSalesItemAsync(item.SalesItemId, auditRemark);
                    if (!itemDel.IsSuccess)
                    {
                        TempData["ErrorMessage"] = itemDel.Message ?? "Failed to remove invoice line items before deletion.";
                        return RedirectToAction(nameof(Index), new { fromDate, toDate });
                    }
                }
            }

            var res = await apiService.DeleteSalesInvoiceAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Sales invoice deleted successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to delete sales invoice.";

            return RedirectToAction(nameof(Index), new { fromDate, toDate });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestUnlock(int salesId, string remarks, string? returnUrl = null)
        {
            var res = await apiService.InsertUnlockRequestAsync(new UnlockRequestVM
            {
                SalesId = salesId,
                Remarks = string.IsNullOrWhiteSpace(remarks) ? "Request to edit/cancel invoice" : remarks
            });

            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Unlock request submitted to Administrator.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Could not submit unlock request.";

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(Create), new { id = salesId });
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerRewardInfoJson(int partyId)
        {
            if (partyId <= 0)
                return Json(new { availablePoints = 0.0, expiryDate = "" });

            var ptsTask = apiService.GetCustomerAvailablePointsAsync(partyId);
            var expTask = apiService.GetCustomerEarliestExpiryDateAsync(partyId);
            await Task.WhenAll(ptsTask, expTask);

            return Json(new
            {
                availablePoints = ptsTask.Result,
                expiryDate = expTask.Result
            });
        }

        [HttpGet]
        public async Task<IActionResult> Print(int id, string format = "A4")
        {
            var printTask = apiService.GetSalesInvoiceToPrintAsync(id);
            var rawTask = apiService.GetSalesInvoiceDetailsAsync(id);
            var headerTask = apiService.GetPrintHeaderAsync();
            var settingsTask = apiService.GetSettingsAsync();
            var customLinesTask = apiService.GetActiveCustomReceiptLinesAsync();
            var msgTask = apiService.GetSelectedMessageAsync("Sales Invoice");

            await Task.WhenAll(printTask, rawTask, headerTask, settingsTask, customLinesTask, msgTask);

            var printInv = printTask.Result ?? new PrintSalesInvoice { SalesId = id };
            var rawInv = rawTask.Result;
            var header = headerTask.Result;
            var settings = settingsTask.Result;

            double netAmount = printInv.TotalInvoiceAmount > 0 ? printInv.TotalInvoiceAmount : (rawInv?.TotalInvoiceAmount ?? 0);
            string msgTemplate = msgTask.Result?.Data ?? "Thank you for shopping at {CompanyName}! Your Invoice #{InvoiceNo} for Rs. {Amount} is generated.";
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
                CustomLines = customLinesTask.Result,
                Format = format.ToUpperInvariant(),
                AmountInWords = GstHelper.NumberToWords(netAmount),
                WhatsAppMessage = waMessage
            };

            return View(vm);
        }
    }
}


