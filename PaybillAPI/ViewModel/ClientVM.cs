namespace PaybillAPI.ViewModel
{
    public class ClientVM
    {
        public string ClientId { get; set; } = null!;
        public string ClientUniqueId { get; set; } = null!;
        public string BusinessType { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string SubscriptionType { get; set; } = null!;
        public double SubscriptionAmount { get; set; } = 0.0;
        public string SubscriptionEndDate { get; set; } = null!;
        public bool IsPremiumUser { get; set; } = false;
        public string SecurityKey { get; set; }
    }
}
