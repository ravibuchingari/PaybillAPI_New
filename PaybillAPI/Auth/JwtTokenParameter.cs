namespace Paybill.Auth
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

    public class TokenParameter
    {
        public string UserRowId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string SecurityKey { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
    }
}
