using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Paybill.DTO;

[Table("order_items")]
[Index("ItemId", Name = "fk_order_items_item_id_idx")]
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

    [ForeignKey("ItemId")]
    [InverseProperty("OrderItems")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("OrderRowId")]
    [InverseProperty("OrderItems")]
    public virtual Order OrderRow { get; set; } = null!;
}
