using Authentication.JWTAuthenticationManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Security;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories;
using PaybillAPI.ViewModel;
using System.Text;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController(ISharedRepository sharedRepository, IJwtTokenHandler jwtTokenHandler) : ControllerBase
    {

        [HttpPost]
        [Route("create/user")]
        public async Task<IActionResult> CreateUserIfNotExists([FromBody] UserVM user)
        {
            user.Password = DataProtection.DecryptWithIV(user.Password, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            string saltKey = Convert.ToBase64String(DataProtection.GenerateRandomNumber(20));
            byte[] hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(user.Password), Convert.FromBase64String(saltKey));
            user.Password = DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV);
            user.SaltKey = DataProtection.EncryptWithIV(saltKey, AppConstants.API_AES_KEY_AND_IV);
            string response = await sharedRepository.CreateUserIfNotExists(user);
            if (response.Equals(AppConstants.SUCCESS))
                return Ok(new ResponseMessage(isSuccess: true, message: "User created successfully"));
            else
                return BadRequest(response);
        }

        [HttpGet]
        [Route("list/users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await sharedRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("settings")]
        public async Task<IActionResult> GetSettings()
        {
            var users = await sharedRepository.GetUsers();
            return Ok(users);
        }
    }
}
