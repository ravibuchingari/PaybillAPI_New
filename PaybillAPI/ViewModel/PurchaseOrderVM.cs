namespace PaybillAPI.ViewModel
{
    public class PurchaseOrderVM
    {
        public int PurchaseOrderId { get; set; }
        public string OrderDate { get; set; } = null!;
        public string? PurchaseInvoiceNo { get; set; }
        public string? PurchaseInvoiceDate { get; set; }
        public string? Remarks { get; set; }
        public Double OrderAmount { get; set; }
        public PartyVM PartyModel { get; set; } = new PartyVM();
        public List<PurchaseOrderItemVM> OrderItems { get; set; } = [];
    }
}
