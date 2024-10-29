using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaybillAPI.ViewModel
{
    public class ItemVM
    {
        public int ItemId { get; set; }

        public int CategoryId { get; set; }

        public int? GstId { get; set; }

        public string ItemCode { get; set; } = null!;

        public string ItemName { get; set; } = null!;

        public string? AliasName { get; set; }

        public float Mrp { get; set; }

        public float SalesPrice { get; set; }

        public float PurchasePrice { get; set; }

        public string? HSncode { get; set; }

        public string Measure { get; set; } = null!;

        public double OpeningStock { get; set; }

        public double ClosingStock { get; set; }

        public double MinimumStock { get; set; }

        public bool IsActive { get; set; }

    }
}
