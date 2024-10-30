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
    public class PurchaseController(IPurchaseRepository purchaseRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("invoice/upsert")]
        public async Task<IActionResult> UpsertPurchase([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await purchaseRepository.UpsertPurchase(userParam.PurchaseModel!, Convert.ToInt32(User.Identity?.Name)));
        }
    }
}
