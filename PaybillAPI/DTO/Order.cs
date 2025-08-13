using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("orders")]
[Index("OrderStatusId", Name = "fk_order_status_id_idx")]
[Index("CustomerRowId", Name = "fk_orders_customer_row_id_idx")]
public partial class Order
{
    [Key]
    public int OrderRowId { get; set; }

    public int CustomerRowId { get; set; }

    [Column(TypeName = "date")]
    public DateTime OrderDate { get; set; }

    public sbyte OrderStatusId { get; set; }

    public sbyte IsHomeDelivery { get; set; }

    [StringLength(100)]
    public string? PickupPointName { get; set; }

    [StringLength(500)]
    public string? PickupPointAddress { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int OrderId { get; set; }

    [ForeignKey("CustomerRowId")]
    [InverseProperty("Orders")]
    public virtual Customer CustomerRow { get; set; } = null!;

    [InverseProperty("OrderRow")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("OrderStatusId")]
    [InverseProperty("Orders")]
    public virtual OrderStatus OrderStatus { get; set; } = null!;
}
