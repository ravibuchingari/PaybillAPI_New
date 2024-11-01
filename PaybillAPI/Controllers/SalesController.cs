using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories;
using PaybillAPI.Repositories.Service;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController(ISalesRepository salesRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("sales/invoice/save")]
        public async Task<IActionResult> SaveSalesInvoice([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await salesRepository.SaveSalesInvoice(userParam.SalesModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("sales/item/{salesItemId}/delete")]
        public async Task<IActionResult> DeleteSalesItem([FromBody] UserParam userParam, [FromRoute] string salesItemId)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            salesItemId = DataProtection.UrlDecode(salesItemId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.DeleteSalesItem(int.Parse(salesItemId), userParam.remarks, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("sales/invoice/list/{fromDate}/{toDate}")]
        public async Task<IActionResult> GetSalesInvoices([FromBody] UserParam userParam, [FromRoute] string fromDate, [FromRoute] string toDate)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await salesRepository.GetSalesInvoices(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpPost]
        [Route("sales/invoice/details/{salesId}")]
        public async Task<IActionResult> GetSalesInvoiceDetails([FromBody] UserParam userParam, [FromRoute] string salesId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            salesId = DataProtection.UrlDecode(salesId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.GetSalesInvoiceDetails(int.Parse(salesId)));
        }

        [HttpPost]
        [Route("sales/invoice/{salesId}/delete")]
        public async Task<IActionResult> DeleteSalesInvoice([FromBody] UserParam userParam, [FromRoute] string salesId)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            salesId = DataProtection.UrlDecode(salesId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.DeleteSalesInvoice(int.Parse(salesId)));
        }
    }
}
