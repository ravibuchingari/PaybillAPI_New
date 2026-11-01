using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class PurchaseOrderController(
        IPurchaseOrderRepository purchaseOrderRepository,
        IPartyRepository partyRepository,
        IItemRepository itemRepository,
        IReportRepository reportRepository,
        ISharedRepository sharedRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = (await reportRepository.GetPurchaseOrderList()).ToList();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id = null)
        {
            var vendors = (await partyRepository.GetActiveParties(isVendor: true, isAll: false)).ToList();
            var items = (await itemRepository.GetItemsForOffline(isAllItems: false, lastUpdatedTime: null)).ToList();

            PurchaseOrderVM? existingOrder = null;
            if (id.HasValue && id.Value > 0)
            {
                try
                {
                    existingOrder = await purchaseOrderRepository.GetPurchaseOrderDetails(id.Value);
                }
                catch
                {
                    existingOrder = null;
                }
            }

            var vm = new PurchaseOrderPageViewModel
            {
                Order = existingOrder ?? new PurchaseOrderVM
                {
                    OrderDate = DateTime.Today.ToString("yyyy-MM-dd")
                },
                Vendors = vendors,
                InitialItems = items
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

            try
            {
                var res = await purchaseOrderRepository.UpsertPurchaseOrder(model, CurrentUserRowId);
                return Json(new
                {
                    isSuccess = res.IsSuccess,
                    message = res.Message,
                    purchaseOrderId = res.Data
                });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteItem(int purchaseOrderItemId)
        {
            try
            {
                var res = await purchaseOrderRepository.DeletePurchaseOrderItem(purchaseOrderItemId);
                return Json(new { isSuccess = res.IsSuccess, message = res.Message });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                PurchaseOrderVM? details = null;
                try
                {
                    details = await purchaseOrderRepository.GetPurchaseOrderDetails(id);
                }
                catch
                {
                    details = null;
                }

                if (details != null && details.PurchaseOrderItems.Count > 0)
                {
                    foreach (var item in details.PurchaseOrderItems.Where(i => i.PurchaseOrderItemId > 0))
                    {
                        await purchaseOrderRepository.DeletePurchaseOrderItem(item.PurchaseOrderItemId);
                    }
                }

                var res = await purchaseOrderRepository.DeletePurchaseOrder(id);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Purchase Order deleted successfully.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to delete Purchase Order.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            PurchaseOrderVM? order = null;
            try
            {
                order = await purchaseOrderRepository.GetPurchaseOrderDetails(id);
            }
            catch
            {
                order = null;
            }

            var header = await sharedRepository.GetPrintHeader();
            ViewBag.Header = header;
            return View(order ?? new PurchaseOrderVM { PurchaseOrderId = id });
        }
    }
}
