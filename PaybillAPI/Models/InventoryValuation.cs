namespace PaybillAPI.Models
{
    public class InventoryValuation
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double SalesPrice { get; set; }
        public double PurchasePrice { get; set; }
        public string Measure { get; set; }
        public double ClosingStock { get; set; }
        public double PurchaseValue { get; set; }
        public double SalesValue { get; set; }
    }
}
