namespace AuthenticationManager
{
    public class JwtTokenParameter
    {
        public string JWTKey { get; set; } = null!;
        public string JWTKeyVer { get; set; } = null!;
        public bool IsValidAudience { get; set; } = true;
        public bool IsValidIssuer { get; set; } = true;
        public string ValidAudience { get; set; } = null!;
        public string ValidIssuer { get; set; } = null!;
        public bool IsValidateLifetime { get; set; } = true;
        public double JWTTokenValidityInMinutes { get; set; }
        public int RefreshTokenValidityInMinutes { get; set; } = 20;
    }
}
