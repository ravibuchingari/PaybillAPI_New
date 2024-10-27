using Authentication.JWTAuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Security;
using PaybillAPI.Models;
using PaybillAPI.Repositories;
using PaybillAPI.ViewModel;

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
            await sharedRepository.CreateAccountIfNotExists(client);
            AuthenticationResponse authenticationResponse = new AuthenticationResponse()
            {
                UserId = client.SecurityKey,
                UserRole = "TempKey",
                SecurityKey = client.SecurityKey,
            };
            authenticationResponse = await jwtTokenHandler.GenerateToken(authenticationResponse);
            return Ok(new ResponseMessage(isSuccess: true, message: "Account created successfully"));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequestVM authRequest)
        {
            if (!await sharedRepository.IsValidAccount(authRequest.ClientUniqueId, authRequest.ClientId))
                throw new UnauthorizedAccessException(AppConstants.UNAUTHORIZED_ACCESS);

            authRequest.Password = DataProtection.EncryptWithIV(DataProtection.DecryptWithIV(authRequest.Password, AppConstants.API_AES_KEY_AND_IV), AppConstants.API_AES_KEY_AND_IV);
            return Ok(new ResponseMessage(isSuccess: true, message: "Validated successfully"));
        }

        #endregion

        #region "Authorized"

        [HttpPost]
        [Route("create/user")]
        public async Task<IActionResult> CreateUserIfNotExists([FromBody] UserVM user)
        {
            user.Password = DataProtection.EncryptWithIV(DataProtection.DecryptWithIV(user.Password, AppConstants.API_AES_KEY_AND_IV), AppConstants.API_AES_KEY_AND_IV);
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
