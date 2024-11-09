namespace PaybillAPI.ViewModel
{
    public class UnlockRequestVM
    {
        public int UnlockRequestId { get; set; }

        public string Remarks { get; set; } = null!;

        public string? RequestedBy { get; set; }

        public string? RequestedDate { get; set; }

        public string? RequestStatusDesc { get; set; }

        public SalesVM? SalesModel { get; set; }
        public PurchaseVM? PurchaseModel { get; set; }
    }
}
