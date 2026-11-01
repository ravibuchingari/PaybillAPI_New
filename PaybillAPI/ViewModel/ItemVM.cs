namespace Paybill.ViewModel
{
    public class ItemVM
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string ItemLocalName { get; set; } = string.Empty;
        public string? AliasName { get; set; } = string.Empty;
        public float Mrp { get; set; }
        public float SalesPrice { get; set; }
        public float PurchasePrice { get; set; }
        public string? HSncode { get; set; } = string.Empty;
        public string? Measure { get; set; } = "PCS";
        public double OpeningStock { get; set; }
        public double ClosingStock { get; set; }
        public double MinimumStock { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Shelf { get; set; } = string.Empty;
        public CategoryVM? CategoryModel { get; set; }
        public GstVM? GstModel { get; set; }
        public string? UpdatedDate { get; set; }
        public int Age { get; set; }
        public float DiscountPer { get; set; }
        public float DiscountRs { get; set; }
        public bool IsGstInclusive { get; set; }

        public string? Barcode
        {
            get => AliasName;
            set => AliasName = value;
        }
        public string? HsnCode
        {
            get => HSncode;
            set => HSncode = value;
        }
        public double Stock
        {
            get => ClosingStock;
            set => ClosingStock = value;
        }
        public double MinStock
        {
            get => MinimumStock;
            set => MinimumStock = value;
        }
        public CategoryVM? Category
        {
            get => CategoryModel;
            set => CategoryModel = value;
        }
        public int CategoryId
        {
            get => CategoryModel?.CategoryId ?? 0;
            set
            {
                CategoryModel ??= new CategoryVM();
                CategoryModel.CategoryId = value;
            }
        }
        public GstVM? Gst
        {
            get => GstModel;
            set => GstModel = value;
        }
        public int GstId
        {
            get => GstModel?.GstId ?? 0;
            set
            {
                GstModel ??= new GstVM();
                GstModel.GstId = value;
            }
        }
    }
}
