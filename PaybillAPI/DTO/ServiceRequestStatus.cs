using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Paybill.DTO;

[Table("service_request_status")]
[Index("ServiceRequestStatusName", Name = "ServiceRequestStatusName_UNIQUE", IsUnique = true)]
public partial class ServiceRequestStatus
{
    [Key]
    public int ServiceRequestStatusId { get; set; }

    [StringLength(30)]
    public string ServiceRequestStatusName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [InverseProperty("ServiceRequestStatus")]
    public virtual ICollection<JobCard> JobCards { get; set; } = new List<JobCard>();
}
