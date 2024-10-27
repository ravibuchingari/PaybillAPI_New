using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Authentication.JWTAuthenticationManager
{
    public class JwtTokenHandler(JwtTokenParameter jwtTokenParameter) : IJwtTokenHandler
    {
        private readonly JwtTokenParameter _jwtTokenParameter = jwtTokenParameter;

        public async Task<AuthenticationResponse> GenerateToken(AuthenticationResponse authenticationResponse)
        {
            if (authenticationResponse.UserRowId < 0 ||
                string.IsNullOrWhiteSpace(authenticationResponse.UserId) ||
                string.IsNullOrWhiteSpace(authenticationResponse.UserRole) ||
                string.IsNullOrWhiteSpace(authenticationResponse.SecurityKey))
                return new AuthenticationResponse() { IsSuccess = false, Message = "User authentication failed." };

            byte[] tokenKey = Encoding.ASCII.GetBytes(_jwtTokenParameter.JwtSecurityKey);

            ClaimsIdentity claimsIdentity = new(
            [
                new(ClaimTypes.Name, authenticationResponse.UserRowId.ToString()),
                new(ClaimTypes.Role, authenticationResponse.UserRole),
                new("UserId", authenticationResponse.UserId),
                new("SecurityKey", authenticationResponse.SecurityKey),
                new("AESKey", authenticationResponse.AESKey),
                new("UserType", authenticationResponse.UserRole),
                new("Origin", _jwtTokenParameter.Origin)
            ]);

            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Subject = claimsIdentity,
                Issuer = _jwtTokenParameter.ValidIssuer,
                Audience = _jwtTokenParameter.ValidAudience,
                Expires = DateTime.UtcNow.AddMinutes(_jwtTokenParameter.TokenValidityInMinutes),
                SigningCredentials = signingCredentials,
            };

            JwtSecurityTokenHandler securityTokenHandler = new();
            SecurityToken securityToken = securityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = securityTokenHandler.WriteToken(securityToken);

            authenticationResponse.ValidityTime = 0; // (int)tokenTimestamp.Subtract(DateTime.Now).TotalSeconds;
            authenticationResponse.JwtToken = token;

            return await Task.FromResult(authenticationResponse);
        }
        public async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return await Task.FromResult(Convert.ToBase64String(randomNumber));
        }

        public async Task<AuthenticationResponse> ValidateRefreshToken(RefreshCredentials refreshCredentials)
        {
            if (string.IsNullOrWhiteSpace(refreshCredentials.JWTToken) ||
                string.IsNullOrWhiteSpace(refreshCredentials.RefreshToken))
                return new AuthenticationResponse() { IsSuccess = false, Message = "No token(s) found." };

            JwtSecurityTokenHandler securityTokenHandler = new();
            SecurityToken securityToken;
            var principal = securityTokenHandler.ValidateToken(refreshCredentials.JWTToken, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = _jwtTokenParameter.IsValidateIssuer,
                ValidateAudience = _jwtTokenParameter.IsValidateAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtTokenParameter.JwtSecurityKey))
            }, out securityToken);

            JwtSecurityToken? jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature) ||
                !principal.FindFirstValue("UserSecurityKey")!.Equals(refreshCredentials.SecurityKey))
                throw new SecurityTokenException("Invalid refresh token.");


            AuthenticationResponse authenticationResponse = new()
            {
                UserRowId = int.Parse(principal.Identity?.Name!),
                IsSuccess = true
            };

            byte[] tokenKey = Encoding.ASCII.GetBytes(_jwtTokenParameter.JwtSecurityKey);
            DateTime tokenTimestamp = DateTime.Now.AddHours(_jwtTokenParameter.TokenValidityInMinutes);

            jwtSecurityToken = new JwtSecurityToken(
                claims: principal.Claims,
                expires: tokenTimestamp,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature));


            authenticationResponse.JwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationResponse.ValidityTime = (int)tokenTimestamp.Subtract(DateTime.Now).TotalHours;
            //authenticationResponse.RefreshToken = await GenerateRefreshToken();

            return await Task.FromResult(authenticationResponse);
        }
    }
}
