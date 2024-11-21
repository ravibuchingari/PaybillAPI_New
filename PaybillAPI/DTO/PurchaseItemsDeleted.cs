using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("purchase_items_deleted")]
[Index("DeletedBy", Name = "fk_deleted_purchase_item_deleted_ny_idx")]
[Index("ItemId", Name = "fk_deleted_purchaseitem_item_id_idx")]
public partial class PurchaseItemsDeleted
{
    [Key]
    [Column("purchaseDeletedItemId")]
    public int PurchaseDeletedItemId { get; set; }

    public int PurchaseId { get; set; }

    public int ItemId { get; set; }

    public float Quantity { get; set; }

    public float Rate { get; set; }

    public double Amount { get; set; }

    public double DiscountInRs { get; set; }

    public double TaxableAmount { get; set; }

    public float CgstPer { get; set; }

    public float SgstPer { get; set; }

    public float IgstPer { get; set; }

    public float GstPer { get; set; }

    public double CgstRs { get; set; }

    public double SgstRs { get; set; }

    public double IgstRs { get; set; }

    public double GstAmount { get; set; }

    public double TotalAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DeletedDate { get; set; }

    public int DeletedBy { get; set; }

    [StringLength(250)]
    public string? DeletedRemarks { get; set; }

    [ForeignKey("DeletedBy")]
    [InverseProperty("PurchaseItemsDeleteds")]
    public virtual User DeletedByNavigation { get; set; } = null!;

    [ForeignKey("ItemId")]
    [InverseProperty("PurchaseItemsDeleteds")]
    public virtual Item Item { get; set; } = null!;
}
