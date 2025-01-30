using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Models
{
    public class ClientVM
    {
        public string? ClientId { get; set; }
        public string? ClientUniqueId { get; set; }
        public string BusinessType { get; set; } = null!;
        public string ClientName { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = null!;
        public string? SecurityKey { get; set; }
        public string? SubscriptionType { get; set; }
        public double SubscriptionAmount { get; set; }
        public string? SubscriptionEndDate { get; set; }
        public bool IsPremiumUser { get; set; }
        public bool IsApiService { get; set; }
        public string ServiceUrl { get; set; } = string.Empty;
        public string Otp { get; set; } = string.Empty;
        public int PaybillApkVersionCode { get; set; }
        public string PaybillApkVersionName { get; set; } = string.Empty;
        public int MaxBackups { get; set; }
        public CountryVM Country { get; set; } = new CountryVM();
    }
}
