using Authentication.JWTAuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories;
using PaybillAPI.ViewModel;
using System.Text;

namespace PaybillAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaybillController(ISharedRepository sharedRepository, IJwtTokenHandler jwtTokenHandler) : ControllerBase
    {
        #region "AllowAnonymous"

        [HttpPost]
        [Route("create/account")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAccountIfNotExists([FromBody] ClientVM client)
        {
            client.SecurityKey = SharedMethod.GenerateUniqueID();
            await sharedRepository.CreateAccountIfNotExists(client);
            AuthenticationResponse authenticationResponse = await jwtTokenHandler.GenerateToken(new AuthenticationResponse()
            {
                UserRowId = client.ClientUniqueId,
                UserId = client.SecurityKey,
                UserRole = "TempKey",
                SecurityKey = client.SecurityKey }, true);

            if (authenticationResponse.IsSuccess)
                return Ok(new ResponseMessage(isSuccess: true, message: authenticationResponse.JwtToken));
            else
                return BadRequest(authenticationResponse.Message);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequestVM authRequest)
        {
            if (!await sharedRepository.IsValidAccount(authRequest.ClientUniqueId, authRequest.ClientId))
                throw new UnauthorizedAccessException(AppConstants.UNAUTHORIZED_ACCESS);
            authRequest.Password = DataProtection.DecryptWithIV(authRequest.Password, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            AuthResponseVM authResponse = await sharedRepository.UserAuthentication(authRequest);
            if (authResponse.IsSuccess)
                return Ok(authResponse);
            else 
                return BadRequest(authResponse.Message);
        }

        #endregion

        #region "Authorized"

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

        [HttpPost]
        [Route("list/users")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsers()
        {
            var users = await sharedRepository.GetUsers();
            return Ok(users);
        }

        #endregion
    }
}
