using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationManager
{
    public class JwtTokenHandler(IOptions<JwtTokenParameter> options) : IJwtTokenHandler
    {
        public async Task<AuthenticationResponse> GenerateToken(AuthenticationResponse authenticationResponse, bool isTemporary = false)
        {
            if (string.IsNullOrEmpty(authenticationResponse.UserRowId) ||
                string.IsNullOrEmpty(authenticationResponse.UserId) ||
                string.IsNullOrEmpty(authenticationResponse.UserRole) ||
                string.IsNullOrEmpty(authenticationResponse.SecurityKey))
                return new AuthenticationResponse() { IsSuccess = false, Message = "User authentication failed." };

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
                new(ClaimTypes.NameIdentifier, authenticationResponse.UserRowId.ToString()),
                new(ClaimTypes.Name, authenticationResponse.UserRowId.ToString()),
                new(ClaimTypes.Role, authenticationResponse.UserRole),
                new(JwtRegisteredClaimNames.Iss, authenticationResponse.ClientName),
                new("UserId", authenticationResponse.UserId),
                new("SecurityKey", authenticationResponse.SecurityKey),
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

            authenticationResponse.JwtToken = token;
            authenticationResponse.IsSuccess = true;

            return await Task.FromResult(authenticationResponse);
        }
    }
}
