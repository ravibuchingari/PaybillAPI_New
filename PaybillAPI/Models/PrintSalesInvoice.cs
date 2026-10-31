namespace PaybillAPI.Models
{
    public class PrintSalesInvoice
    {
        public string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string SalesType { get; set; } = string.Empty;
        public double PaidAmount { get; set; } = 0.0;
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string PaymentMode { get; set; } = string.Empty;
        public string UpiType { get; set; } = string.Empty;
        public string PartyName { get; set; } = string.Empty;
        public string PartyMobile { get; set; } = string.Empty;
        public string PartyAddress { get; set; } = string.Empty;
        public string PrintedTime { get; set; } = string.Empty;
        public double RewardPointsEarned { get; set; }
        public double RewardPointsRedeemed { get; set; }
        public double RewardDiscountAmount { get; set; }
        public double CustomerAvailablePoints { get; set; }
        public List<GSTData> GstSummary { get; set; } = [];
        public List<PrintSalesItem> SalesItems { get; set; } = [];
    }
}
