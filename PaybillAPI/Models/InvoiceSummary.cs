namespace PaybillAPI.Models
{
    public class InvoiceSummary
    {
        public double TotalAmount { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalTaxableAmount { get; set; }
        public double TotalGSTAmount { get; set; }
        public double TotalInvoiceAmount { get; set; }
    }
}
