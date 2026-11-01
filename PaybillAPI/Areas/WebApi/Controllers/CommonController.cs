using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;

namespace Paybill.Areas.WebApi.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Area("WebApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(IAdminRepository adminRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("client/profile/update")]
        public async Task<IActionResult> UpdateProfile([FromBody] ClientVM client)
        {
            ResponseMessage response = await sharedRepository.UpdateProfile(client);
            return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
        }

        [HttpPost]
        [Route("create/user")]
        public async Task<IActionResult> CreateUserIfNotExists([FromBody] UserVM user)
        {
            string key = User.Identity?.Name!;
            if (string.IsNullOrEmpty(user.SecurityKey) || !key.Equals(user.SecurityKey))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);

            user.Password = DataProtection.DecryptWithIV(user.Password, AppConstants.PAYBILL_API_AES_KEY_AND_IV);

            string response = await sharedRepository.CreateUserIfNotExists(user);
            return response.Equals(AppConstants.RESPONSE_SUCCESS) ? Ok(new ResponseMessage(isSuccess: true, message: "User created successfully")) : BadRequest(response);
        }

        [HttpPost]
        [Route("user/upset")]
        public async Task<IActionResult> UpsertUser([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            userParam.UserModel!.Password = DataProtection.DecryptWithIV(userParam.UserModel!.Password, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await sharedRepository.UpsertUser(userParam.UserModel, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("user/password/change/{oldPassword}/{newPassword}")]
        public async Task<IActionResult> ChangePassword([FromBody] UserParam userParam, [FromRoute] string oldPassword, [FromRoute] string newPassword)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            oldPassword = DataProtection.UrlDecode(oldPassword, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            newPassword = DataProtection.UrlDecode(newPassword, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await sharedRepository.ChangePassword(Convert.ToInt32(User.Identity?.Name), oldPassword, newPassword));
        }

        [HttpPost]
        [Route("user/list")]
        public async Task<IActionResult> GetUsers([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await adminRepository.GetUsers());
        }

        [HttpPost]
        [Route("user/{userRowId}/delete")]
        public async Task<IActionResult> DeleteUser([FromBody] UserParam userParam, [FromRoute] string userRowId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            userRowId = DataProtection.UrlDecode(userRowId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await adminRepository.DeleteUser(int.Parse(userRowId)));
        }

        [HttpGet]
        [Route("print/header")]
        public async Task<IActionResult> GetPrintHeader()
        {
            return Ok(await sharedRepository.GetPrintHeader());
        }

        [HttpPost]
        [Route("unlock/request/insert")]
        public async Task<IActionResult> InsUnlockRequest([FromBody] UnlockRequestVM request)
        {
            return Ok(await sharedRepository.InsUnlockRequest(request, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [HttpGet]
        [Route("unlock/request/status")]
        public async Task<IActionResult> CheckUnlockRequestStatus([FromQuery] int? salesId, [FromQuery] int? purchaseId)
        {
            return Ok(await sharedRepository.CheckUnlockRequestStatus(salesId, purchaseId));
        }

        [HttpPost]
        [Route("unlock/request/list")]
        public async Task<IActionResult> GetUnlockRequests([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await sharedRepository.GetUnlockRequests());
        }

        [HttpPost]
        [Route("unlock/request/update/{unlockRequestId}/{isApproved}")]
        public async Task<IActionResult> UpdateUnlockRequest([FromBody] UserParam userParam, [FromRoute] string unlockRequestId, [FromRoute] bool isApproved)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            unlockRequestId = DataProtection.UrlDecode(unlockRequestId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await sharedRepository.UpdateUnlockRequest(int.Parse(unlockRequestId), isApproved, userParam.remarks, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("message/insert")]
        public async Task<IActionResult> InsMessage([FromForm] string messageId, [FromForm] string messageDescription, [FromForm] string? messageType = null, [FromForm] bool isSelected = false)
        {
            return Ok(await adminRepository.InsMessage(int.Parse(messageId), messageDescription, messageType, isSelected));
        }

        [HttpPost]
        [Route("message/select")]
        public async Task<IActionResult> SelectMessageTemplate([FromForm] int messageId, [FromForm] string messageType)
        {
            return Ok(await adminRepository.SelectMessageTemplate(messageId, messageType));
        }

        [HttpGet]
        [Route("message/selected")]
        public async Task<IActionResult> GetSelectedMessageDescription([FromQuery] string messageType)
        {
            return Ok(await adminRepository.GetSelectedMessageDescription(messageType));
        }

        [HttpPost]
        [Route("message/{messageId}/delete")]
        public async Task<IActionResult> DeleteMessage([FromRoute] int messageId)
        {
            return Ok(await adminRepository.DeleteMessage(messageId));
        }

        [HttpGet]
        [Route("message/list")]
        public async Task<IActionResult> GetMessages()
        {
            return Ok(await adminRepository.GetMessages());
        }

        [HttpGet]
        [Route("custom-receipt/list")]
        public async Task<IActionResult> GetAllCustomLines()
        {
            return Ok(await adminRepository.GetAllCustomLines());
        }

        [HttpGet]
        [Route("custom-receipt/active")]
        public async Task<IActionResult> GetActiveCustomLines()
        {
            return Ok(await adminRepository.GetActiveCustomLines());
        }

        [HttpPost]
        [Route("custom-receipt/upsert")]
        public async Task<IActionResult> UpsertCustomLine([FromBody] UserParam userParam)
        {
            if (userParam.CustomReceiptLineModel == null)
                return BadRequest("Custom receipt line model is required.");
            return Ok(await adminRepository.UpsertCustomLine(userParam.CustomReceiptLineModel));
        }

        [HttpPost]
        [Route("custom-receipt/status/{customLineId}/{isActive}")]
        public async Task<IActionResult> UpdateCustomLineActiveStatus([FromRoute] int customLineId, [FromRoute] bool isActive)
        {
            return Ok(await adminRepository.UpdateCustomLineActiveStatus(customLineId, isActive));
        }

        [HttpPost]
        [Route("custom-receipt/{customLineId}/delete")]
        public async Task<IActionResult> DeleteCustomLine([FromRoute] int customLineId)
        {
            return Ok(await adminRepository.DeleteCustomLine(customLineId));
        }

        [HttpGet]
        [HttpPost]
        [Route("sever/backups/max")]
        public async Task<IActionResult> GetMaxServerBackups()
        {
            return Ok(await sharedRepository.GetMaxServerBackups());
        }
    }
}

