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
    public class PurchaseController(
        IPurchaseRepository purchaseRepository,
        IPurchaseOrderRepository purchaseOrderRepository,
        IPartyRepository partyRepository,
        IItemRepository itemRepository,
        IAdminRepository adminRepository,
        ISharedRepository sharedRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(string? fromDate = null, string? toDate = null)
        {
            string start = string.IsNullOrWhiteSpace(fromDate)
                ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString("yyyy-MM-dd")
                : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate)
                ? DateTime.Today.ToString("yyyy-MM-dd")
                : toDate;

            var purchases = (await purchaseRepository.GetPurchaseInvoices(ParseDate(start), ParseDate(end))).ToList();
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.IsAdmin = IsAdminUser;

            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id = null, int? poId = null)
        {
            var settings = await adminRepository.GetSettings() ?? new SettingVM();
            var vendors = (await partyRepository.GetActiveParties(isVendor: true, isAll: false)).ToList();
            var activePos = (await purchaseOrderRepository.GetPurchaseOrderActiveList()).ToList();
            var categories = (await itemRepository.GetCategories()).ToList();
            var gstSlabs = (await itemRepository.GetGsts(isActive: true)).ToList();
            var items = (await itemRepository.GetItemsForOffline(isAllItems: false, lastUpdatedTime: null)).ToList();

            PurchaseVM? existingPurchase = null;
            ResponseMessage? unlockCheck = null;
            if (id.HasValue && id.Value > 0)
            {
                try
                {
                    existingPurchase = await purchaseRepository.GetPurchaseInvoiceDetails(id.Value);
                }
                catch
                {
                    existingPurchase = null;
                }
                unlockCheck = await sharedRepository.CheckUnlockRequestStatus(null, id.Value);
            }

            var purchase = existingPurchase ?? new PurchaseVM
            {
                PurchaseDate = DateTime.Today.ToString("yyyy-MM-dd"),
                InvoiceDate = DateTime.Today.ToString("yyyy-MM-dd"),
                PaymentMode = "Cash",
                IsCashPurchase = true
            };

            if ((!id.HasValue || id.Value == 0) && poId.HasValue && poId.Value > 0)
            {
                try
                {
                    var poDetails = await purchaseOrderRepository.GetPurchaseOrderDetails(poId.Value);
                    var poItems = (await purchaseRepository.GetPurchaseOrderItems(poId.Value)).ToList();
                    if (poDetails != null)
                    {
                        purchase.PurchaseOrderId = poId.Value;
                        purchase.PartyId = poDetails.PartyId;
                        purchase.PurchaseItems = poItems;
                    }
                }
                catch
                {
                    // Ignore if PO not found
                }
            }

            var vm = new PurchaseInvoicePageViewModel
            {
                Purchase = purchase,
                Settings = settings,
                Vendors = vendors,
                ActivePurchaseOrders = activePos,
                Categories = categories,
                GstSlabs = gstSlabs,
                InitialItems = items,
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

        [HttpGet]
        public async Task<IActionResult> LoadPurchaseOrderItemsJson(int poId)
        {
            PurchaseOrderVM? order = null;
            List<PurchaseItemVM> items = [];
            try
            {
                order = await purchaseOrderRepository.GetPurchaseOrderDetails(poId);
                items = (await purchaseRepository.GetPurchaseOrderItems(poId)).ToList();
            }
            catch
            {
                // Ignore
            }

            return Json(new
            {
                order,
                items
            });
        }

        [HttpPost]
        public async Task<IActionResult> SavePurchase([FromBody] PurchaseVM model)
        {
            if (model == null || model.PurchaseItems == null || model.PurchaseItems.Count == 0)
                return Json(new { isSuccess = false, message = "Please add at least one item to the purchase invoice." });

            if (model.PartyId <= 0)
                return Json(new { isSuccess = false, message = "Please select a Supplier / Vendor." });

            if (string.IsNullOrWhiteSpace(model.PurchaseDate))
                model.PurchaseDate = DateTime.Today.ToString("yyyy-MM-dd");
            if (string.IsNullOrWhiteSpace(model.InvoiceDate))
                model.InvoiceDate = model.PurchaseDate;

            model.IsCashPurchase = !string.Equals(model.PaymentMode, "Credit", StringComparison.OrdinalIgnoreCase);
            if (string.IsNullOrWhiteSpace(model.PurchaseType))
                model.PurchaseType = model.IsCashPurchase ? "Cash" : "Credit";

            try
            {
                var res = await purchaseRepository.UpsertPurchase(model, CurrentUserRowId);
                int purchaseId = model.PurchaseId;
                if (!string.IsNullOrWhiteSpace(res.Data) && int.TryParse(res.Data, out int parsedId) && parsedId > 0)
                {
                    purchaseId = parsedId;
                }

                return Json(new
                {
                    isSuccess = res.IsSuccess,
                    message = res.Message,
                    purchaseId
                });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int purchaseItemId, string remarks)
        {
            if (string.IsNullOrWhiteSpace(remarks))
                return Json(new { isSuccess = false, message = "Audit remarks are required to delete a purchase item." });

            try
            {
                var res = await purchaseRepository.DeletePurchaseItem(purchaseItemId, remarks, CurrentUserRowId);
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
            string auditRemark = string.IsNullOrWhiteSpace(remarks) ? "Purchase invoice deleted by Admin" : remarks;
            try
            {
                PurchaseVM? details = null;
                try
                {
                    details = await purchaseRepository.GetPurchaseInvoiceDetails(id);
                }
                catch
                {
                    details = null;
                }

                if (details != null && details.PurchaseItems.Count > 0)
                {
                    if (details.IsLocked)
                    {
                        TempData["ErrorMessage"] = "This purchase invoice is locked. Approve an Unlock Request before deleting its items.";
                        return RedirectToAction(nameof(Index), new { fromDate, toDate });
                    }

                    foreach (var item in details.PurchaseItems.Where(i => i.PurchaseItemId > 0))
                    {
                        var itemDel = await purchaseRepository.DeletePurchaseItem(item.PurchaseItemId, auditRemark, CurrentUserRowId);
                        if (!itemDel.IsSuccess)
                        {
                            TempData["ErrorMessage"] = itemDel.Message ?? "Failed to remove purchase line items.";
                            return RedirectToAction(nameof(Index), new { fromDate, toDate });
                        }
                    }
                }

                var res = await purchaseRepository.DeletePurchaseInvoice(id);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Purchase invoice deleted successfully.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to delete purchase invoice.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { fromDate, toDate });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestUnlock(int purchaseId, string remarks, string? returnUrl = null)
        {
            try
            {
                var res = await sharedRepository.InsUnlockRequest(new UnlockRequestVM
                {
                    PurchaseId = purchaseId,
                    Remarks = string.IsNullOrWhiteSpace(remarks) ? "Request to edit purchase invoice" : remarks
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

            return RedirectToAction(nameof(Create), new { id = purchaseId });
        }

        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            PurchaseVM? purchase = null;
            try
            {
                purchase = await purchaseRepository.GetPurchaseInvoiceDetails(id);
            }
            catch
            {
                purchase = null;
            }

            purchase ??= new PurchaseVM { PurchaseId = id };
            var header = await sharedRepository.GetPrintHeader();

            ViewBag.Header = header;
            ViewBag.AmountInWords = GstHelper.NumberToWords(purchase.TotalInvoiceAmount);

            return View(purchase);
        }
    }
}
