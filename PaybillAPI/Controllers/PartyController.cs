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
    public class PartyController(IPartyRepository partyRepository, ISharedRepository sharedRepository) : ControllerBase
    {

        [HttpPost]
        [Route("party/upsert")]
        public async Task<IActionResult> UpsertParty([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await partyRepository.UpsertParty(userParam.PartyModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("party/list/{isVendor}")]
        public async Task<IActionResult> GetParties([FromBody] UserParam userParam, [FromRoute] bool isVendor)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
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
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
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

    }
}
