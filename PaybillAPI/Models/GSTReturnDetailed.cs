namespace PaybillAPI.Models
{
    public class GSTReturnDetailed
    {
        public int SalesId { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? PartyName { get; set; }
        public string? PartyGstin { get; set; }
        public List<GSTData> Data { get; set; } = [];
        public bool IsHeader { get; set; } = false;
    }
}
