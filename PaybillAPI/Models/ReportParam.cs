namespace PaybillAPI.Models
{
    public class ReportParam
    {
        public int UserRowId { get; set; }
        public string SecurityKey { get; set; } = null!;
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? TransactionType { get; set; }
        public string? PaymentMode { get; set; }
        public string? UpiType { get; set; }
        public string? Id { get; set; }

    }
}
