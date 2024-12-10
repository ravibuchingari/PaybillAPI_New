using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController(IPurchaseOrderRepository purchaseOrderRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("purchase/order/upsert")]
        public async Task<IActionResult> UpsertPurchaseOrder([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await purchaseOrderRepository.UpsertPurchaseOrder(userParam.PurchaseOrderModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("purchase/order/details/{purchaseOrderId}")]
        public async Task<IActionResult> GetPurchaseOrderDetails([FromBody] UserParam userParam, [FromRoute] string purchaseOrderId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            purchaseOrderId = DataProtection.UrlDecode(purchaseOrderId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await purchaseOrderRepository.GetPurchaseOrderDetails(int.Parse(purchaseOrderId)));
        }

        [HttpPost]
        [Route("purchase/order/item/{purchaseOrderItemId}/delete")]
        public async Task<IActionResult> DeletePurchaseOrderItem([FromBody] UserParam userParam, [FromRoute] string purchaseOrderItemId)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            purchaseOrderItemId = DataProtection.UrlDecode(purchaseOrderItemId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await purchaseOrderRepository.DeletePurchaseOrderItem(int.Parse(purchaseOrderItemId)));
        }

        [HttpPost]
        [Route("purchase/order/active/list")]
        public async Task<IActionResult> GetPurchaseOrderActiveList([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await purchaseOrderRepository.GetPurchaseOrderActiveList());
        }


        [HttpPost]
        [Route("purchase/order/{purchaseOrderId}/delete")]
        public async Task<IActionResult> DeletePurchaseOrder([FromBody] UserParam userParam, [FromRoute] string purchaseOrderId)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            purchaseOrderId = DataProtection.UrlDecode(purchaseOrderId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await purchaseOrderRepository.DeletePurchaseOrder(int.Parse(purchaseOrderId)));
        }

        [HttpGet]
        [Route("purchase/order/items/{purchaseOrderId}")]
        public async Task<IActionResult> GetPurchaseOrderItems([FromRoute] string purchaseOrderId)
        {
            purchaseOrderId = DataProtection.UrlDecode(purchaseOrderId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await purchaseOrderRepository.GetPurchaseOrderItems(int.Parse(purchaseOrderId)));
        }
    }
}
