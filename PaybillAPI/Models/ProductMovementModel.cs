namespace Paybill.Models
{
    public class ProductMovementModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Measure { get; set; } = string.Empty;
        public double ClosingStock { get; set; }
        public int SalesFrequency { get; set; }
        public double TotalQuantitySold { get; set; }
        public double TotalRevenue { get; set; }

        public double TotalSoldQty => TotalQuantitySold;
        public double TotalSalesAmount => TotalRevenue;
        public double CurrentStock => ClosingStock;
        public double StockTurnoverRatio => ClosingStock > 0 ? Math.Round(TotalQuantitySold / ClosingStock, 2) : TotalQuantitySold;
        public string MovementCategory => SalesFrequency >= 5 ? "Fast Moving" : (SalesFrequency > 0 ? "Normal" : "Slow Moving");
    }
}
