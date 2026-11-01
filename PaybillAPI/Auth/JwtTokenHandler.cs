using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Paybill.Areas.Paybill.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Paybill.Auth
{
    public class JwtTokenHandler(IOptions<JwtTokenParameter> options) : IJwtTokenHandler
    {
        public async Task<ResponseMessage> GenerateToken(TokenParameter param, bool isTemporary = false)
        {
            if (string.IsNullOrEmpty(param.UserRowId) ||
                string.IsNullOrEmpty(param.UserId) ||
                string.IsNullOrEmpty(param.UserRole) ||
                string.IsNullOrEmpty(param.SecurityKey))
                return new ResponseMessage() { IsSuccess = false, Message = "User authentication failed." };

            var jwtTokenParameter = new JwtTokenParameter()
            {
                JWTKey = options.Value.JWTKey,
                IsValidIssuer = options.Value.IsValidIssuer,
                IsValidAudience = options.Value.IsValidAudience,
                ValidIssuer = options.Value.ValidIssuer,
                ValidAudience = options.Value.ValidAudience,
                JWTTokenValidityInMinutes = options.Value.JWTTokenValidityInMinutes,
                RefreshTokenValidityInMinutes = options.Value.RefreshTokenValidityInMinutes
            };

            byte[] tokenKey = Encoding.ASCII.GetBytes(jwtTokenParameter.JWTKey);

            ClaimsIdentity claimsIdentity = new(
            [
                new(ClaimTypes.NameIdentifier, param.UserRowId.ToString()),
                new(ClaimTypes.Name, param.UserRowId.ToString()),
                new(ClaimTypes.Role, param.UserRole),
                new(JwtRegisteredClaimNames.Iss, param.ClientName),
                new("UserId", param.UserId),
                new("SecurityKey", param.SecurityKey),
            ]);

            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Subject = claimsIdentity,
                Issuer = jwtTokenParameter.ValidIssuer,
                Audience = jwtTokenParameter.ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(isTemporary == false ? jwtTokenParameter.JWTTokenValidityInMinutes : 5),
                SigningCredentials = signingCredentials,
            };

            JwtSecurityTokenHandler securityTokenHandler = new();
            SecurityToken securityToken = securityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = securityTokenHandler.WriteToken(securityToken);

            return await Task.FromResult(new ResponseMessage() { IsSuccess = true, Message = token, Data = SecurityKey });
        }
    }
}
