namespace Paybill.ViewModel
{
    public class AuthRequestVM
    {
        public string ClientUniqueId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? BiometricAuthKey { get; set; }
    }
}
