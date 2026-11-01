using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;

namespace Paybill.Areas.WebApi.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Area("WebApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAdminRepository adminRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("settings/view")]
        public async Task<IActionResult> GetSettings([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await adminRepository.GetSettings());
        }

        [HttpPost]
        [Route("settings/update")]
        public async Task<IActionResult> UpdateSettings([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await adminRepository.UpdateSettings(Convert.ToInt32(User.Identity?.Name), userParam.SettingModel!));
        }
    }
}

