using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("purchase_orders")]
[Index("CreatedBy", Name = "fk_purchase_order_created_by_idx")]
[Index("PartyId", Name = "fk_purchase_order_vendor_id_idx")]
public partial class PurchaseOrder
{
    [Key]
    public int PurchaseOrderId { get; set; }

    [Column(TypeName = "date")]
    public DateTime OrderDate { get; set; }

    public int PartyId { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PurchaseOrders")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("PartyId")]
    [InverseProperty("PurchaseOrders")]
    public virtual Party Party { get; set; } = null!;

    [InverseProperty("PurchaseOrder")]
    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    [InverseProperty("PurchaseOrder")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
