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
    public class TransactionController(ITransactionRepository transactionRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("trans/insert")]
        public async Task<IActionResult> InsertTransaction([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await transactionRepository.SaveTransaction(userParam.TransactionModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("trans/{transactionId}/delete")]
        public async Task<IActionResult> DeleteTransaction([FromBody] UserParam userParam, [FromRoute] string transactionId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            transactionId = DataProtection.UrlDecode(transactionId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await transactionRepository.DeleteTransaction(int.Parse(transactionId), Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("trans/list/today/{isPayment}")]
        public async Task<IActionResult> GetTodayTransactions([FromBody] UserParam userParam, [FromRoute] bool isPayment)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await transactionRepository.GetTodayTransactions(isPayment));
        }

        [HttpPost]
        [Route("trans/list/today/{fromDate}/{toDate}/{isPayment}")]
        public async Task<IActionResult> GetTransactions([FromBody] UserParam userParam, [FromRoute] string fromDate, [FromRoute] string toDate, [FromRoute] int isPayment)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            fromDate = DataProtection.UrlDecode(fromDate, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            toDate = DataProtection.UrlDecode(toDate, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await transactionRepository.GetTransactions(DateTime.Parse(fromDate), DateTime.Parse(toDate), isPayment));
        }
    }
}
