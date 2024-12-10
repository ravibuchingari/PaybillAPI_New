using PaybillAPI.Models;

namespace PaybillAPI.ViewModel
{
    public class PurchaseVM
    {
        public int PurchaseId { get; set; }
        public string InvoiceNo { get; set; } = null!;
        public string InvoiceDate { get; set; } = null!;
        public string PurchaseType { get; set; } = null!;
        public string PaymentMode { get; set; } = null!;
        public string? UpiType { get; set; }
        public string? Remarks { get; set; }
        public bool IsLocked { get; set; }
        public int PurchaseOrderId { get; set; }
        public List<PurchaseItemVM> PurchaseItems { get; set; } = [];
        public InvoiceSummary? Summary { get; set; }
        public PartyVM PartyModel { get; set; } = new PartyVM();
    }
}
