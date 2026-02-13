namespace AuthenticationManager
{
    public interface IJwtTokenHandler
    {
        Task<AuthenticationResponse> GenerateToken(AuthenticationResponse authenticationResponse, bool isTemporary = false);
    }
}