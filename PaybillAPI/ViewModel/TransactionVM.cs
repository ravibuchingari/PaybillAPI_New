namespace Paybill.ViewModel
{
    public class TransactionVM
    {
        public int TransactionId { get; set; }
        public string TransactionDate { get; set; } = string.Empty;
        public string? TransactionRefNo { get; set; }
        public string PaymentMode { get; set; } = "Cash";
        public string? UpiType { get; set; } = string.Empty;
        public double ReceiptAmount { get; set; }
        public double PaymentAmount { get; set; }
        public double Balance { get; set; }
        public string? Remarks { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string? CreatedDate { get; set; }
        public PartyVM? PartyModel { get; set; } = new();

        public bool IsPayment { get; set; }
        public double InvoiceAmount { get; set; }
        public double Discount { get; set; }

        public PartyVM? Party
        {
            get => PartyModel;
            set => PartyModel = value;
        }
        public int PartyId
        {
            get => PartyModel?.PartyId ?? 0;
            set
            {
                PartyModel ??= new PartyVM();
                PartyModel.PartyId = value;
            }
        }
        public double ReceivedAmount
        {
            get => ReceiptAmount;
            set => ReceiptAmount = value;
        }
        public double PaidAmount
        {
            get => PaymentAmount;
            set => PaymentAmount = value;
        }
        public double BalanceAmount
        {
            get => Balance;
            set => Balance = value;
        }
    }


    //public class TransactionVM
    //{
    //    public int TransactionId { get; set; }
    //    public string TransactionDate { get; set; } = null!;
    //    public string? TransactionRefNo { get; set; }
    //    public string PaymentMode { get; set; } = null!;
    //    public string? UpiType { get; set; }
    //    public double ReceiptAmount { get; set; }
    //    public double PaymentAmount { get; set; }
    //    public double Balance { get; set; }
    //    public string? Remarks { get; set; } = string.Empty;
    //    public string TransactionType { get; set; } = null!;
    //    public string? CreatedDate { get; set; }
    //    public PartyVM? PartyModel { get; set; } = null!;
    //}
}
