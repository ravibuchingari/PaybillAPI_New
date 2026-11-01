namespace Paybill.Models
{
    public class InventoryValuation
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public double SalesPrice { get; set; }
        public double PurchasePrice { get; set; }
        public string Measure { get; set; } = string.Empty;
        public double ClosingStock { get; set; }
        public double PurchaseValue { get; set; }
        public double SalesValue { get; set; }

        public double Stock => ClosingStock;
    }
}
