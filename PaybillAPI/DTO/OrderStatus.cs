using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("order_status")]
[Index("OrderStatusDesc", Name = "OrderStatusDesc_UNIQUE", IsUnique = true)]
public partial class OrderStatus
{
    [Key]
    public sbyte OrderStatusId { get; set; }

    [StringLength(45)]
    public string OrderStatusDesc { get; set; } = null!;

    [InverseProperty("OrderStatus")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
