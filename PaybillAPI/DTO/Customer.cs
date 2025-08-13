using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("customers")]
public partial class Customer
{
    [Key]
    public int CustomerRowId { get; set; }

    [StringLength(100)]
    public string CustomerName { get; set; } = null!;

    [StringLength(10)]
    public string Mobile { get; set; } = null!;

    [StringLength(500)]
    public string Address { get; set; } = null!;

    [StringLength(150)]
    public string? Email { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public sbyte IsActive { get; set; }

    [InverseProperty("CustomerRow")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
