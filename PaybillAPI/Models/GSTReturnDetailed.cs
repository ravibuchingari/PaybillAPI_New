namespace Paybill.Models
{
    public class GSTReturnDetailed
    {
        public int SalesId { get; set; }
        public string? InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string? PartyName { get; set; } = string.Empty;
        public string? PartyGstin { get; set; } = string.Empty;
        public List<GSTData> Data { get; set; } = [];
        public bool IsHeader { get; set; } = false;
    }
}
