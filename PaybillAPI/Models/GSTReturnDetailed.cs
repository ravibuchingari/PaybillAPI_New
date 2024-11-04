namespace PaybillAPI.Models
{
    public class GSTReturnDetailed
    {
        public int SalesItemId { get; set; }
        public string InvoiceNo { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public string? HSNCode { get; set; } = string.Empty;
        public double PurchasePrice { get; set; }
        public double SalesPrice { get; set; }
        public double TaxableAmount { get; set; }
        public float GstPer { get; set; }
        public double GstValue { get; set; }
        

    }
}
