using Authentication.JWTAuthenticationManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Security;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System.Text;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(ISharedRepository sharedRepository) : ControllerBase
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
            if(user.SecurityKey.IsNullOrEmpty() || !key.Equals(user.SecurityKey))
                    return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);

            user.Password = DataProtection.DecryptWithIV(user.Password, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            string saltKey = Convert.ToBase64String(DataProtection.GenerateRandomNumber(20));
            byte[] hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(user.Password), Convert.FromBase64String(saltKey));
            user.Password = DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV);
            user.SaltKey = DataProtection.EncryptWithIV(saltKey, AppConstants.API_AES_KEY_AND_IV);
            string response = await sharedRepository.CreateUserIfNotExists(user);
            return response.Equals(AppConstants.RESPONSE_SUCCESS) ? Ok(new ResponseMessage(isSuccess: true, message: "User created successfully")) : BadRequest(response);
        }

       
    }
}
