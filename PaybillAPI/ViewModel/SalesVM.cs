using PaybillAPI.Models;

namespace PaybillAPI.ViewModel
{
    public class SalesVM
    {
        public int SalesId { get; set; }
        public string InvoiceNo { get; set; } = null!;
        public string InvoiceDate { get; set; } = null!;
        public string SalesType { get; set; } = null!;
        public string PaymentMode { get; set; } = null!;
        public string? UpiType { get; set; } = string.Empty;
        public double PaidAmount { get; set; }
        public double BalanceAmount { get; set; }
        public string? Remarks { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsLocked { get; set; }
        public string? EndUserMobile { get; set; }
        public PartyVM? PartyModel { get; set; }
        public List<SalesItemVM> SalesItems { get; set; } = [];
        public InvoiceSummary? Summary { get; set; }
    }
}
