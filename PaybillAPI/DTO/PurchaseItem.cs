using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("purchase_items")]
[Index("ItemId", Name = "fk_purchase_item_item_id_idx")]
[Index("PurchaseId", Name = "fk_purchase_item_purchase_id_idx")]
public partial class PurchaseItem
{
    [Key]
    public int PurchaseItemId { get; set; }

    public int PurchaseId { get; set; }

    public int ItemId { get; set; }

    public float Quantity { get; set; }

    public float Rate { get; set; }

    public double Amount { get; set; }

    public double DiscountInRs { get; set; }

    public float GstPer { get; set; }

    public double GstAmount { get; set; }

    public double TaxableAmount { get; set; }

    public double TotalAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("PurchaseItems")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("PurchaseId")]
    [InverseProperty("PurchaseItems")]
    public virtual Purchase Purchase { get; set; } = null!;
}
