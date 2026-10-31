namespace PaybillAPI.Models
{
    public class TodaySalesSummary
    {
        public string InvoiceDate { get; set; } = string.Empty;
        public int TotalInvoiceCount { get; set; }
        public double TotalSalesAmount { get; set; }
        public double TotalDiscountAmount { get; set; }
        public double TotalGstAmount { get; set; }
        public double AmountCollected { get; set; }
        public double CashAmount { get; set; }
        public double CardAmount { get; set; }
        public double UpiAmount { get; set; }
        public double TotalCreditSalesAmount { get; set; }
        public double TodayPendingCreditAmount { get; set; }
        public double OverallPendingCreditAmount { get; set; }
    }

    public class DashboardSalesSummaryResponse
    {
        public TodaySalesSummary Today { get; set; } = new TodaySalesSummary();
        public TodaySalesSummary Weekly { get; set; } = new TodaySalesSummary();
        public TodaySalesSummary Monthly { get; set; } = new TodaySalesSummary();
    }
}

