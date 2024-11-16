namespace PaybillAPI.Models
{
    public class BiometricAuth
    {
        public string ClientId { get; set; } = null!;
        public string ClientUniqueId { get; set; } = null!;
        public int UserRowId { get; set; }
        public string UserId { get; set; } = null!;
        public string SecurityKey { get; set; } = null!;
        public string BiometricAuthKeyDate { get; set; } = null!;
        public int BiometricAuthKeyValidity { get; set; }

    }
}
