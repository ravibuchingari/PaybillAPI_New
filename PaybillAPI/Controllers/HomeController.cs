using Authentication.JWTAuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(ISharedRepository sharedRepository, IJwtTokenHandler jwtTokenHandler) : ControllerBase
    {
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
                SecurityKey = client.SecurityKey
            }, true);

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
            {
                AuthenticationResponse authenticationResponse = await jwtTokenHandler.GenerateToken(new AuthenticationResponse()
                {
                    UserRowId = authResponse.User.UserRowId!,
                    UserId = authResponse.User.UserId,
                    UserRole = authResponse.User.IsAdmin ? "admin" : "user",
                    SecurityKey = authResponse.User.SecurityKey!
                });
                if (authenticationResponse.IsSuccess)
                {
                    authResponse.User.JwtToken = authenticationResponse.JwtToken;
                    return Ok(authResponse);
                }
                else
                    return BadRequest(authResponse.Message);
            }
            else
                return BadRequest(authResponse.Message);
        }

    }
}
