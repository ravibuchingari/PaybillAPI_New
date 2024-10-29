using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAdminRepository adminRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("settings/view")]
        public async Task<IActionResult> GetSettings([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await adminRepository.GetSettings());
        }

        [HttpPost]
        [Route("settings/update")]
        public async Task<IActionResult> UpdateSettings([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await adminRepository.UpdateSettings(Convert.ToInt32(User.Identity?.Name), userParam.SettingModel!));
        }
    }
}
