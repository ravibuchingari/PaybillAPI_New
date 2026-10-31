using PaybillAPI.Models;

namespace PaybillAPI.ViewModel
{
    public class SalesVM
    {
        public int SalesId { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string SalesType { get; set; } = string.Empty;
        public string PaymentMode { get; set; } = string.Empty;
        public string? UpiType { get; set; } = string.Empty;
        public double PaidAmount { get; set; }
        public double BalanceAmount { get; set; }
        public string? Remarks { get; set; } = string.Empty;
        public string? CreatedDate { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsLocked { get; set; }
        public string? EndUserMobile { get; set; } = string.Empty;
        public int ServiceRequestId { get; set; }
        public double RewardPointsEarned { get; set; }
        public double RewardPointsRedeemed { get; set; }
        public double RewardDiscountAmount { get; set; }
        public PartyVM? PartyModel { get; set; }
        public List<SalesItemVM> SalesItems { get; set; } = [];
        public InvoiceSummary? Summary { get; set; }
        public JobCardVM? JobCard { get; set; }
    }
}
