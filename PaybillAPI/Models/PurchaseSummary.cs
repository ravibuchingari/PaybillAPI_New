namespace PaybillAPI.Models
{
    public class PurchaseSummary
    {
        public double TotalAmount { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalTaxableAmount { get; set; }
        public double TotalGSTAmount { get; set; }
        public double TotalPurchaseAmount { get; set; }
    }
}
