namespace Authentication.JWTAuthenticationManager
{
    public class RefreshCredentials
    {
        public string JWTToken { get; set; }
        public string RefreshToken { get; set; }
        public string SecurityKey { get; set; }
    }
}
