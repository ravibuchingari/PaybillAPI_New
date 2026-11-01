using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillWebApp.Models;
using PaybillWebApp.Services;

namespace PaybillWebApp.Controllers
{
    [Authorize]
    public class PurchaseOrderController(IPaybillApiService apiService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await apiService.GetPurchaseOrderReportListAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id = null)
        {
            var vendorsTask = apiService.GetActivePartiesAsync(isVendor: true, isAll: false);
            var itemsTask = apiService.GetAllItemsOfflineAsync(isAllItems: false);
            Task<PurchaseOrderVM?>? orderTask = id.HasValue && id.Value > 0
                ? apiService.GetPurchaseOrderDetailsAsync(id.Value)
                : null;

            await Task.WhenAll(vendorsTask, itemsTask, orderTask ?? Task.FromResult<PurchaseOrderVM?>(null));

            var vm = new PurchaseOrderPageViewModel
            {
                Order = orderTask?.Result ?? new PurchaseOrderVM
                {
                    OrderDate = DateTime.Today.ToString("yyyy-MM-dd")
                },
                Vendors = vendorsTask.Result,
                InitialItems = itemsTask.Result
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] PurchaseOrderVM model)
        {
            if (model == null || model.PurchaseOrderItems == null || model.PurchaseOrderItems.Count == 0)
                return Json(new { isSuccess = false, message = "Please add at least one item to the Purchase Order." });

            if (model.PartyId <= 0)
                return Json(new { isSuccess = false, message = "Please select a Supplier / Vendor." });

            if (string.IsNullOrWhiteSpace(model.OrderDate))
                model.OrderDate = DateTime.Today.ToString("yyyy-MM-dd");

            var res = await apiService.UpsertPurchaseOrderAsync(model);
            return Json(new
            {
                isSuccess = res.IsSuccess,
                message = res.Message,
                purchaseOrderId = res.Data
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int purchaseOrderItemId)
        {
            var res = await apiService.DeletePurchaseOrderItemAsync(purchaseOrderItemId);
            return Json(new { isSuccess = res.IsSuccess, message = res.Message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var details = await apiService.GetPurchaseOrderDetailsAsync(id);
            if (details != null && details.PurchaseOrderItems.Count > 0)
            {
                foreach (var item in details.PurchaseOrderItems.Where(i => i.PurchaseOrderItemId > 0))
                {
                    await apiService.DeletePurchaseOrderItemAsync(item.PurchaseOrderItemId);
                }
            }

            var res = await apiService.DeletePurchaseOrderAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Purchase Order deleted successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to delete Purchase Order.";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            var orderTask = apiService.GetPurchaseOrderDetailsAsync(id);
            var headerTask = apiService.GetPrintHeaderAsync();
            await Task.WhenAll(orderTask, headerTask);

            ViewBag.Header = headerTask.Result;
            return View(orderTask.Result ?? new PurchaseOrderVM { PurchaseOrderId = id });
        }
    }
}

