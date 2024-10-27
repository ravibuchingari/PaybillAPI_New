namespace Authentication.JWTAuthenticationManager
{
    public class AuthenticationResponse
    {
        public int UserRowId { get; set; }
        public string ClientName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string JwtToken { get; set; }
        public string SecurityKey { get; set; }
        public string UserRole { get; set; }
        public int ValidityTime { get; set; }
        public bool IsSuccess { get; set; }
        public string AESKey { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string ServerDate { get; set; }
        public string PlayerStartTime { get; set; }
        public bool IsAdmin { get; set; }
        public int CityId { get; set; }
        public bool IsVendor { get; set; }
        public bool IsVendorOwnContent { get; set; }
    }
}
