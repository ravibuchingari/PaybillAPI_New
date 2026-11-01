namespace AuthenticationManager
{
    public interface IJwtTokenHandler
    {
        Task<AuthRespon> GenerateToken(AuthResponse authenticationResponse, bool isTemporary = false);
    }
}