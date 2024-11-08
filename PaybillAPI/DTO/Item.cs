using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("items")]
[Index("CategoryId", Name = "fk_items_category_id_idx")]
[Index("CreatedBy", Name = "fk_items_created_by_idx")]
[Index("GstId", Name = "fk_items_gst_id_idx")]
[Index("UpdatedBy", Name = "fk_items_updated_by_idx")]
public partial class Item
{
    [Key]
    public int ItemId { get; set; }

    public int CategoryId { get; set; }

    public int? GstId { get; set; }

    [StringLength(50)]
    public string ItemCode { get; set; } = null!;

    [StringLength(100)]
    public string ItemName { get; set; } = null!;

    [StringLength(250)]
    public string? AliasName { get; set; }

    public float Mrp { get; set; }

    public float SalesPrice { get; set; }

    public float PurchasePrice { get; set; }

    [Column("HSNCode")]
    [StringLength(20)]
    public string? Hsncode { get; set; }

    [StringLength(20)]
    public string Measure { get; set; } = null!;

    public double OpeningStock { get; set; }

    public double ClosingStock { get; set; }

    public double MinimumStock { get; set; }

    public sbyte IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Items")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("CreatedBy")]
    [InverseProperty("ItemCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("GstId")]
    [InverseProperty("Items")]
    public virtual Gst? Gst { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    [InverseProperty("Item")]
    public virtual ICollection<PurchaseItemsDeleted> PurchaseItemsDeleteds { get; set; } = new List<PurchaseItemsDeleted>();

    [InverseProperty("Item")]
    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    [InverseProperty("Item")]
    public virtual ICollection<SalesItemsDeleted> SalesItemsDeleteds { get; set; } = new List<SalesItemsDeleted>();

    [ForeignKey("UpdatedBy")]
    [InverseProperty("ItemUpdatedByNavigations")]
    public virtual User UpdatedByNavigation { get; set; } = null!;
}
