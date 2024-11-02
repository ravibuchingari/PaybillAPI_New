namespace PaybillAPI.Models
{
    public class GSTReturnModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public string? HSNcode { get; set; } = string.Empty;
        public double PurchasePrice { get; set; }
        public double SalesPrice { get; set; }
        public double TaxableAmount { get; set; }
        public double GSTPer { get; set; }
        public double GSTValue { get; set; }
        public DateTime InvoiceDate { get; set; } 

    }
}
