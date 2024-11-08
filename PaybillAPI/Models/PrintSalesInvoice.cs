namespace PaybillAPI.Models
{
    public class PrintSalesInvoice
    {
        public string InvoiceNo { get; set; } = null!;
        public string InvoiceDate { get; set; } = null!;
        public string SalesType { get; set; } = null!;
        public double PaidAmount { get; set; } = 0.0;
        public string CreatedBy { get; set; } = null!;
        public string CreatedDate { get; set; } = null!;
        public string PaymentMode { get; set; }
        public string UpiType { get; set; }
        public string PartyName { get; set; }
        public List<GSTData> GstSummary { get; set; } = [];
        public List<PrintSalesItem> SalesItems { get; set; } = [];
    }

}
