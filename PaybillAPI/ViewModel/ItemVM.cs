namespace PaybillAPI.ViewModel
{
    public class ItemVM
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string? AliasName { get; set; }
        public float Mrp { get; set; }
        public float SalesPrice { get; set; }
        public float PurchasePrice { get; set; }
        public string? HSncode { get; set; }
        public string? Measure { get; set; }
        public double OpeningStock { get; set; }
        public double ClosingStock { get; set; }
        public double MinimumStock { get; set; }
        public bool IsActive { get; set; }
        public CategoryVM? CategoryModel { get; set; }
        public GstVM? GstModel { get; set; }
        public string? UpdatedDate { get; set; }
        public int Age { get; set; }

    }
}
