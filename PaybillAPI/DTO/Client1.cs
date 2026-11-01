using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paybill.DTO;

[Table("clients")]
[Index("MasterClientId", Name = "MasterClientId_UNIQUE", IsUnique = true)]
public partial class Client1
{
    [Key]
    public long ClientId { get; set; }

    [StringLength(50)]
    public string MasterClientId { get; set; } = null!;

    [StringLength(100)]
    public string ClientName { get; set; } = null!;

    [StringLength(500)]
    public string ClientAddress { get; set; } = null!;

    [StringLength(20)]
    public string ClientMobile { get; set; } = null!;

    [StringLength(150)]
    public string? ClientEmail { get; set; }

    public sbyte IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }
}
