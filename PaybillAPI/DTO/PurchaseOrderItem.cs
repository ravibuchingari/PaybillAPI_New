using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("purchase_order_items")]
[Index("ItemId", Name = "fk_purchase_order_items_item_id_idx")]
[Index("PurchaseOrderId", Name = "fk_purchase_order_items_order_id_idx")]
public partial class PurchaseOrderItem
{
    [Key]
    public int PurchaseOrderItemId { get; set; }

    public int PurchaseOrderId { get; set; }

    [Column("quantity")]
    public float Quantity { get; set; }

    [Column("rate")]
    public float Rate { get; set; }

    [Column("amount")]
    public double Amount { get; set; }

    public int ItemId { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("PurchaseOrderItems")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("PurchaseOrderId")]
    [InverseProperty("PurchaseOrderItems")]
    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
