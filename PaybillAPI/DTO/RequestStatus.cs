using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("request_status")]
[Index("RequestStatusDesc", Name = "RequestStatusDesc_UNIQUE", IsUnique = true)]
public partial class RequestStatus
{
    [Key]
    public sbyte RequestStatusId { get; set; }

    [StringLength(45)]
    public string RequestStatusDesc { get; set; } = null!;

    [InverseProperty("RequestStatus")]
    public virtual ICollection<UnlockRequest> UnlockRequests { get; set; } = new List<UnlockRequest>();
}
