using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController(IPartyRepository partyRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("party/upsert")]
        public async Task<IActionResult> UpsertParty([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await partyRepository.UpsertParty(userParam.PartyModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("party/list/{isVendor}")]
        public async Task<IActionResult> GetParties([FromBody] UserParam userParam, [FromRoute] bool isVendor)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await partyRepository.GetParties(isVendor));
        }

        [HttpPost]
        [Route("party/{partyId}/details")]
        public async Task<IActionResult> GetPartyDetails([FromRoute] string partyId)
        {
            partyId = DataProtection.UrlDecode(partyId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await partyRepository.GetPartyDetails(int.Parse(partyId)));
        }

        [HttpPost]
        [Route("party/{partyId}/delete/{isVendor}")]
        public async Task<IActionResult> DeleteParty([FromBody] UserParam userParam, [FromRoute] string partyId, [FromRoute] bool isVendor)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            partyId = DataProtection.UrlDecode(partyId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await partyRepository.DeleteParty(int.Parse(partyId), isVendor));
        }

        [HttpGet]
        [Route("party/active/list/{isVendor}/{isAll}")]
        public async Task<IActionResult> GetActiveParties([FromRoute] bool isVendor, [FromRoute] bool isAll)
        {
            return Ok(await partyRepository.GetActiveParties(isVendor, isAll));
        }

        #region "Customer Rewards"

        [HttpGet]
        [Route("party/{partyId}/rewards/available")]
        public async Task<IActionResult> GetCustomerAvailablePoints([FromRoute] int partyId)
        {
            return Ok(await partyRepository.GetCustomerAvailablePoints(partyId));
        }

        [HttpGet]
        [Route("party/{partyId}/rewards/summary")]
        public async Task<IActionResult> GetCustomerRewardsSummary([FromRoute] int partyId)
        {
            return Ok(await partyRepository.GetCustomerRewardsSummary(partyId));
        }

        [HttpGet]
        [Route("party/{partyId}/rewards/expiry")]
        public async Task<IActionResult> GetCustomerEarliestUpcomingExpiryDate([FromRoute] int partyId)
        {
            return Ok(await partyRepository.GetCustomerEarliestUpcomingExpiryDate(partyId));
        }

        [HttpGet]
        [Route("party/rewards/transactions")]
        public async Task<IActionResult> GetRewardsTransactions(
            [FromQuery] int? partyId,
            [FromQuery] int? salesId,
            [FromQuery] string? fromDate,
            [FromQuery] string? toDate,
            [FromQuery] string? transType,
            [FromQuery] string? searchQuery)
        {
            return Ok(await partyRepository.GetRewardsTransactions(partyId, salesId, fromDate, toDate, transType, searchQuery));
        }

        [HttpPost]
        [Route("party/rewards/adjustment")]
        public async Task<IActionResult> SaveManualRewardAdjustment([FromBody] RewardAdjustmentRequestVM request)
        {
            if (!await sharedRepository.IsValidUser(request.UserRowId, request.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await partyRepository.SaveManualRewardAdjustment(request, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpGet]
        [Route("party/rewards/customers-summary")]
        public async Task<IActionResult> GetAllCustomerRewardsSummary(
            [FromQuery] string? fromDate,
            [FromQuery] string? toDate,
            [FromQuery] string? searchQuery)
        {
            return Ok(await partyRepository.GetAllCustomerRewardsSummary(fromDate, toDate, searchQuery));
        }

        [HttpGet]
        [Route("party/rewards/overall-summary")]
        public async Task<IActionResult> GetOverallRewardsSummary()
        {
            return Ok(await partyRepository.GetOverallRewardsSummary());
        }

        [HttpPost]
        [Route("party/rewards/expire")]
        public async Task<IActionResult> ExpireOldPoints()
        {
            int userRowId = int.TryParse(User.Identity?.Name, out var uid) ? uid : 0;
            return Ok(await partyRepository.ExpireOldPoints(userRowId));
        }

        [HttpGet]
        [Route("party/rewards/redemptions")]
        public async Task<IActionResult> GetRedemptionDetails(
            [FromQuery] string? specificDate,
            [FromQuery] string? fromDate,
            [FromQuery] string? toDate,
            [FromQuery] string? searchQuery,
            [FromQuery] string? filterInvoiceNo)
        {
            return Ok(await partyRepository.GetRedemptionDetails(specificDate, fromDate, toDate, searchQuery, filterInvoiceNo));
        }

        #endregion
    }
}
