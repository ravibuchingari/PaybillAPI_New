namespace Paybill.ViewModel
{
    public class PurchaseOrderVM
    {
        public int PurchaseOrderId { get; set; }
        public string OrderDate { get; set; } = string.Empty;
        public string? PurchaseInvoiceNo { get; set; }
        public string? PurchaseInvoiceDate { get; set; }
        public string? Remarks { get; set; } = string.Empty;
        public double OrderAmount { get; set; }
        public PartyVM PartyModel { get; set; } = new();
        public List<PurchaseOrderItemVM> OrderItems { get; set; } = [];

        public PartyVM Party
        {
            get => PartyModel;
            set => PartyModel = value ?? new PartyVM();
        }
        public int PartyId
        {
            get => PartyModel.PartyId;
            set => PartyModel.PartyId = value;
        }
        public bool IsActive { get; set; } = true;
        public List<PurchaseOrderItemVM> PurchaseOrderItems
        {
            get => OrderItems;
            set => OrderItems = value ?? [];
        }
    }
    //public class PurchaseOrderVM
    //{
    //    public int PurchaseOrderId { get; set; }
    //    public string OrderDate { get; set; } = null!;
    //    public string? PurchaseInvoiceNo { get; set; }
    //    public string? PurchaseInvoiceDate { get; set; }
    //    public string? Remarks { get; set; }
    //    public Double OrderAmount { get; set; }
    //    public PartyVM PartyModel { get; set; } = new PartyVM();
    //    public List<PurchaseOrderItemVM> OrderItems { get; set; } = [];
    //}
}
