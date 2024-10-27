
namespace Authentication.JWTAuthenticationManager
{
    public interface IJwtTokenHandler
    {
        Task<AuthenticationResponse> GenerateToken(AuthenticationResponse authenticationResponse);
        Task<string> GenerateRefreshToken();
        Task<AuthenticationResponse> ValidateRefreshToken(RefreshCredentials refreshCredentials);
    }
}