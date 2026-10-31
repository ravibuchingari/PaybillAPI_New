namespace PaybillAPI.Models
{
    public class ReportParam
    {
        public int UserRowId { get; set; }
        public string SecurityKey { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public string? TransactionType { get; set; } = string.Empty;
        public string? PaymentMode { get; set; } = string.Empty;
        public string? UpiType { get; set; } = string.Empty;
        public string? Id { get; set; } = string.Empty;
    }
}
