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
    public class PurchaseController(IPaybillApiService apiService) : Controller
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

            var purchases = await apiService.GetPurchaseInvoicesAsync(start, end);
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.IsAdmin = apiService.IsAdminUser();

            return View(purchases);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id = null, int? poId = null)
        {
            var settingsTask = apiService.GetSettingsAsync();
            var vendorsTask = apiService.GetActivePartiesAsync(isVendor: true, isAll: false);
            var activePosTask = apiService.GetActivePurchaseOrdersAsync();
            var categoriesTask = apiService.GetCategoriesAsync();
            var gstTask = apiService.GetGstListAsync(isActiveOnly: true);
            var itemsTask = apiService.GetAllItemsOfflineAsync(isAllItems: false);

            Task<PurchaseVM?>? purchaseTask = id.HasValue && id.Value > 0
                ? apiService.GetPurchaseInvoiceDetailsAsync(id.Value)
                : null;
            Task<ResponseMessage>? unlockCheckTask = id.HasValue && id.Value > 0
                ? apiService.CheckUnlockRequestStatusAsync(null, id.Value)
                : null;

            await Task.WhenAll(
                settingsTask,
                vendorsTask,
                activePosTask,
                categoriesTask,
                gstTask,
                itemsTask,
                purchaseTask ?? Task.FromResult<PurchaseVM?>(null),
                unlockCheckTask ?? Task.FromResult(new ResponseMessage()));

            var settings = settingsTask.Result;
            var purchase = purchaseTask?.Result ?? new PurchaseVM
            {
                PurchaseDate = DateTime.Today.ToString("yyyy-MM-dd"),
                InvoiceDate = DateTime.Today.ToString("yyyy-MM-dd"),
                PaymentMode = "Cash",
                IsCashPurchase = true
            };

            if ((!id.HasValue || id.Value == 0) && poId.HasValue && poId.Value > 0)
            {
                var poDetails = await apiService.GetPurchaseOrderDetailsAsync(poId.Value);
                var poItems = await apiService.GetPurchaseOrderItemsForPurchaseAsync(poId.Value);
                if (poDetails != null)
                {
                    purchase.PurchaseOrderId = poId.Value;
                    purchase.PartyId = poDetails.PartyId;
                    purchase.PurchaseItems = poItems;
                }
            }

            var vm = new PurchaseInvoicePageViewModel
            {
                Purchase = purchase,
                Settings = settings,
                Vendors = vendorsTask.Result,
                ActivePurchaseOrders = activePosTask.Result,
                Categories = categoriesTask.Result,
                GstSlabs = gstTask.Result,
                InitialItems = itemsTask.Result,
                CompanyGstin = string.IsNullOrWhiteSpace(settings.ReceiptHeaderLine5)
                    ? apiService.GetCurrentCompanyGstin()
                    : settings.ReceiptHeaderLine5,
                IsAdmin = apiService.IsAdminUser(),
                PendingUnlockMessage = unlockCheckTask?.Result?.IsSuccess == true ? unlockCheckTask.Result.Message : null
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> LoadPurchaseOrderItemsJson(int poId)
        {
            var poDetailsTask = apiService.GetPurchaseOrderDetailsAsync(poId);
            var poItemsTask = apiService.GetPurchaseOrderItemsForPurchaseAsync(poId);
            await Task.WhenAll(poDetailsTask, poItemsTask);

            return Json(new
            {
                order = poDetailsTask.Result,
                items = poItemsTask.Result
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

            var res = await apiService.UpsertPurchaseAsync(model);
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

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int purchaseItemId, string remarks)
        {
            if (string.IsNullOrWhiteSpace(remarks))
                return Json(new { isSuccess = false, message = "Audit remarks are required to delete a purchase item." });

            var res = await apiService.DeletePurchaseItemAsync(purchaseItemId, remarks);
            return Json(new { isSuccess = res.IsSuccess, message = res.Message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInvoice(int id, string? remarks, string? fromDate, string? toDate)
        {
            string auditRemark = string.IsNullOrWhiteSpace(remarks) ? "Purchase invoice deleted by Admin" : remarks;
            var details = await apiService.GetPurchaseInvoiceDetailsAsync(id);
            if (details != null && details.PurchaseItems.Count > 0)
            {
                if (details.IsLocked)
                {
                    TempData["ErrorMessage"] = "This purchase invoice is locked. Approve an Unlock Request before deleting its items.";
                    return RedirectToAction(nameof(Index), new { fromDate, toDate });
                }

                foreach (var item in details.PurchaseItems.Where(i => i.PurchaseItemId > 0))
                {
                    var itemDel = await apiService.DeletePurchaseItemAsync(item.PurchaseItemId, auditRemark);
                    if (!itemDel.IsSuccess)
                    {
                        TempData["ErrorMessage"] = itemDel.Message ?? "Failed to remove purchase line items.";
                        return RedirectToAction(nameof(Index), new { fromDate, toDate });
                    }
                }
            }

            var res = await apiService.DeletePurchaseInvoiceAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Purchase invoice deleted successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to delete purchase invoice.";

            return RedirectToAction(nameof(Index), new { fromDate, toDate });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestUnlock(int purchaseId, string remarks, string? returnUrl = null)
        {
            var res = await apiService.InsertUnlockRequestAsync(new UnlockRequestVM
            {
                PurchaseId = purchaseId,
                Remarks = string.IsNullOrWhiteSpace(remarks) ? "Request to edit purchase invoice" : remarks
            });

            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Unlock request submitted to Administrator.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Could not submit unlock request.";

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction(nameof(Create), new { id = purchaseId });
        }

        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            var purchaseTask = apiService.GetPurchaseInvoiceDetailsAsync(id);
            var headerTask = apiService.GetPrintHeaderAsync();
            await Task.WhenAll(purchaseTask, headerTask);

            var purchase = purchaseTask.Result ?? new PurchaseVM { PurchaseId = id };
            ViewBag.Header = headerTask.Result;
            ViewBag.AmountInWords = GstHelper.NumberToWords(purchase.TotalInvoiceAmount);

            return View(purchase);
        }
    }
}


