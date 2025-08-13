using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("order_items")]
[Index("OrderRowId", Name = "fk_order_items_order_row_id_idx")]
public partial class OrderItem
{
    [Key]
    public int OrderItemRowId { get; set; }

    public int OrderRowId { get; set; }

    public int OrderId { get; set; }

    public int ItemId { get; set; }

    public double Quantity { get; set; }

    public sbyte IsProcessed { get; set; }

    [ForeignKey("OrderRowId")]
    [InverseProperty("OrderItems")]
    public virtual Order OrderRow { get; set; } = null!;
}
