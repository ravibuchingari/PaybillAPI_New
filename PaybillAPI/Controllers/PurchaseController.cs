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
    public class PurchaseController(IPurchaseRepository purchaseRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("purchase/upsert")]
        public async Task<IActionResult> UpsertPurchase([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await purchaseRepository.UpsertPurchase(userParam.PurchaseModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("purchase/item/{purchaseItemId}/delete")]
        public async Task<IActionResult> DeletePurchaseItem([FromBody] UserParam userParam, [FromRoute] string purchaseItemId)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            if (string.IsNullOrWhiteSpace(userParam.remarks))
                return BadRequest("Remarks cannot be empty.");
            purchaseItemId = DataProtection.UrlDecode(purchaseItemId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await purchaseRepository.DeletePurchaseItem(int.Parse(purchaseItemId), userParam.remarks, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("purchase/invoice/list/{fromDate}/{toDate}")]
        public async Task<IActionResult> GetPurchaseInvoices([FromBody] UserParam userParam, [FromRoute] string fromDate, [FromRoute] string toDate)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await purchaseRepository.GetPurchaseInvoices(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpPost]
        [Route("purchase/invoice/{purchaseId}/delete")]
        public async Task<IActionResult> DeletePurchaseInvoice([FromBody] UserParam userParam, [FromRoute] string purchaseId)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            purchaseId = DataProtection.UrlDecode(purchaseId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await purchaseRepository.DeletePurchaseInvoice(int.Parse(purchaseId)));
        }

        [HttpPost]
        [Route("purchase/invoice/details/{purchaseId}")]
        public async Task<IActionResult> GetPurchaseInvoiceDetails([FromBody] UserParam userParam, [FromRoute] string purchaseId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            purchaseId = DataProtection.UrlDecode(purchaseId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await purchaseRepository.GetPurchaseInvoiceDetails(int.Parse(purchaseId)));
        }
    }
}
