using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("client")]
public partial class Client
{
    [Key]
    [StringLength(150)]
    public string ClientUniqueId { get; set; } = null!;

    [StringLength(60)]
    public string ClientId { get; set; } = null!;

    [StringLength(60)]
    public string? BusinessType { get; set; }

    [StringLength(100)]
    public string ClientName { get; set; } = null!;

    [StringLength(10)]
    public string Mobile { get; set; } = null!;

    [StringLength(500)]
    public string Address { get; set; } = null!;

    [StringLength(150)]
    public string? Email { get; set; }

    [StringLength(50)]
    public string? SubscriptionType { get; set; }

    public double SubscriptionAmount { get; set; }

    [Column(TypeName = "date")]
    public DateTime? SubscriptionEndDate { get; set; }

    public sbyte IsPremiumUser { get; set; }

    public sbyte IsActivated { get; set; }

    [StringLength(60)]
    public string? SecurityKey { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
