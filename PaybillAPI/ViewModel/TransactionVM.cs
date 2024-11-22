namespace PaybillAPI.ViewModel
{
    public class TransactionVM
    {
        public int TransactionId { get; set; }
        public string TransactionDate { get; set; } = null!;
        public string? TransactionRefNo { get; set; }
        public string PaymentMode { get; set; } = null!;
        public string? UpiType { get; set; }
        public double ReceiptAmount { get; set; }
        public double PaymentAmount { get; set; }
        public string? Remarks { get; set; } = string.Empty;
        public string TransactionType { get; set; } = null!;
        public string? CreatedDate { get; set; }
        public PartyVM? PartyModel { get; set; } = null!;
    }
}
