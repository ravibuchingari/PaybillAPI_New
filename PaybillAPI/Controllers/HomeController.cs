using Authentication.JWTAuthenticationManager;
using Microsoft.AspNetCore.Mvc;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System.Net;

namespace PaybillAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(ISharedRepository sharedRepository, IJwtTokenHandler jwtTokenHandler) : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public async Task<ContentResult> Test()
        {
            string message = await sharedRepository.CheckDatabase();
            return new ContentResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                ContentType = "text/html",
                Content = $"<html><body style='background-color: black;'>{message}</body></html>"
            };
        }

        [HttpPost]
        [Route("create/account")]
        public async Task<IActionResult> CreateAccountIfNotExists([FromBody] ClientVM client)
        {
            client.SecurityKey = SharedMethod.GenerateUniqueID();
            await sharedRepository.CreateAccountIfNotExists(client);
            AuthenticationResponse authenticationResponse = await jwtTokenHandler.GenerateToken(new AuthenticationResponse()
            {
                UserRowId = client.SecurityKey,
                UserId = client.ClientId,
                UserRole = "user",
                SecurityKey = client.SecurityKey
            }, true);

            if (authenticationResponse.IsSuccess)
                return Ok(new ResponseMessage(isSuccess: true, message: authenticationResponse.JwtToken, data: client.SecurityKey));
            else
                return BadRequest(authenticationResponse.Message);
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequestVM authRequest)
        {
            if (!await sharedRepository.IsValidAccount(authRequest.ClientUniqueId, authRequest.ClientId))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            authRequest.Password = DataProtection.DecryptWithIV(authRequest.Password, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            AuthResponseVM authResponse = await sharedRepository.UserAuthentication(authRequest);
            if (authResponse.IsSuccess)
            {
                AuthenticationResponse authenticationResponse = await jwtTokenHandler.GenerateToken(new AuthenticationResponse()
                {
                    UserRowId = authResponse.User.UserRowId.ToString()!,
                    UserId = authResponse.User.UserId,
                    UserRole = authResponse.User.IsAdmin ? "admin" : "user",
                    SecurityKey = authResponse.User.SecurityKey!
                });
                if (authenticationResponse.IsSuccess)
                {
                    authResponse.User.JwtToken = authenticationResponse.JwtToken;
                    authResponse.User.SecurityKey = DataProtection.UrlEncode(authResponse.User.SecurityKey!, AppConstants.API_AES_KEY_AND_IV);
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
