namespace AuthenticationManager
{
    public class AuthenticationResponse
    {
        public string UserRowId { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string JwtToken { get; set; } = null!;
        public string SecurityKey { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public int ValidityTime { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
