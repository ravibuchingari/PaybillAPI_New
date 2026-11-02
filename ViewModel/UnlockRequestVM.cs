namespace Paybill.ViewModel
{
    public class UnlockRequestVM
    {
        public int UnlockRequestId { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public string? RequestedBy { get; set; }
        public string? RequestedDate { get; set; }
        public string? RequestStatusDesc { get; set; }
        public double TotalAmount { get; set; }
        public SalesVM? SalesModel { get; set; }
        public PurchaseVM? PurchaseModel { get; set; }

        public int? SalesId
        {
            get => SalesModel?.SalesId;
            set
            {
                if (value.HasValue && value.Value > 0)
                {
                    SalesModel ??= new SalesVM();
                    SalesModel.SalesId = value.Value;
                }
            }
        }
        public int? PurchaseId
        {
            get => PurchaseModel?.PurchaseId;
            set
            {
                if (value.HasValue && value.Value > 0)
                {
                    PurchaseModel ??= new PurchaseVM();
                    PurchaseModel.PurchaseId = value.Value;
                }
            }
        }
        public string? InvoiceNumber => SalesModel?.InvoiceNo ?? PurchaseModel?.InvoiceNo;
    }

    //public class UnlockRequestVM
    //{
    //    public int UnlockRequestId { get; set; }

    //    public string Remarks { get; set; } = null!;

    //    public string? RequestedBy { get; set; }

    //    public string? RequestedDate { get; set; }

    //    public string? RequestStatusDesc { get; set; }
    //    public double TotalAmount { get; set; }

    //    public SalesVM? SalesModel { get; set; }
    //    public PurchaseVM? PurchaseModel { get; set; }
    //}
}
