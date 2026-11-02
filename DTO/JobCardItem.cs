using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Paybill.DTO;

[Table("job_card_items")]
[Index("ServiceRequestId", Name = "fk_job_card_items_req_id_idx")]
[Index("ServiceTypeId", Name = "fk_job_card_items_stype_id_idx")]
public partial class JobCardItem
{
    [Key]
    public int ServiceRequestComplaintId { get; set; }

    public int ServiceRequestId { get; set; }

    public int ServiceTypeId { get; set; }

    public double ServiceCharge { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [ForeignKey("ServiceRequestId")]
    [InverseProperty("JobCardItems")]
    public virtual JobCard ServiceRequest { get; set; } = null!;

    [ForeignKey("ServiceTypeId")]
    [InverseProperty("JobCardItems")]
    public virtual ServiceType ServiceType { get; set; } = null!;
}
