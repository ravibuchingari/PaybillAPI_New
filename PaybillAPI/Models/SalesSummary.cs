namespace PaybillAPI.Models
{
    public class SalesSummary
    {
        public string Month { get; set; }
        public string SalesType { get; set; }
        public string PaymentMode { get; set; }
        public double Cash { get; set; }
        public double Card { get; set; }
        public double Upi { get; set; }
        public double Credit { get; set; }
        public double TotalAmount { get; set; }
    }
}
