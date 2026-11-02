using Paybill.Models;

namespace Paybill.ViewModel
{
    public class ClientVM
    {
        public int ClientRowId { get; set; }
        public string ClientId { get; set; } = string.Empty;
        public string ClientUniqueId { get; set; } = string.Empty;
        public string BusinessType { get; set; } = "Retail & POS";
        public string ClientName { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string SubscriptionType { get; set; } = "Standard";
        public double SubscriptionAmount { get; set; }
        public string SubscriptionEndDate { get; set; } = string.Empty;
        public bool IsPremiumUser { get; set; } = true;
        public bool IsActivated { get; set; } = true;
        public string? SecurityKey { get; set; }
        public int MaxBackups { get; set; } = 5;
        public CountryModel? Country { get; set; } = new();
    }

    //public class ClientVM
    //{
    //    public string ClientId { get; set; } = null!;
    //    public string ClientUniqueId { get; set; } = null!;
    //    public string BusinessType { get; set; } = null!;
    //    public string ClientName { get; set; } = null!;
    //    public string Mobile { get; set; } = null!;
    //    public string? Email { get; set; }
    //    public string Address { get; set; } = null!;
    //    public string SubscriptionType { get; set; } = null!;
    //    public double SubscriptionAmount { get; set; } = 0.0;
    //    public string SubscriptionEndDate { get; set; } = null!;
    //    public bool IsPremiumUser { get; set; }
    //    public bool IsActivated { get; set; }
    //    public string? SecurityKey { get; set; }
    //    public int MaxBackups { get; set; }
    //    public CountryModel? Country { get; set; }
    //}
}
