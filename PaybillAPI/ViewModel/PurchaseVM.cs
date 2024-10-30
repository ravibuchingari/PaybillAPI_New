using PaybillAPI.Models;

namespace PaybillAPI.ViewModel
{
    public class PurchaseVM
    {
        public int PurchaseId { get; set; }
        public string InvoiceNo { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public string PurchaseType { get; set; } = null!;
        public string? Remarks { get; set; }
        public List<PurchaseItemVM>? PurchaseItems { get; set; }
        public PurchaseSummary? Summary { get; set; }
        public PartyVM PartyModel { get; set; } = new PartyVM();
    }
}
