using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Paybill.DTO;

[Table("job_cards")]
[Index("CreatedBy", Name = "fk_job_cards_created_by_idx")]
[Index("PartyId", Name = "fk_job_cards_party_id_idx")]
[Index("SalesId", Name = "fk_job_cards_sales_id_idx")]
[Index("ServiceRequestStatusId", Name = "fk_job_cards_status_id_idx")]
[Index("UpdatedBy", Name = "fk_job_cards_updated_by_idx")]
public partial class JobCard
{
    [Key]
    public int ServiceRequestId { get; set; }

    public int? SalesId { get; set; }

    public int PartyId { get; set; }

    [Column(TypeName = "date")]
    public DateTime ServiceRequestDate { get; set; }

    [StringLength(500)]
    public string? ServiceRequestDescription { get; set; }

    public int ServiceRequestStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("JobCardCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("ServiceRequest")]
    public virtual ICollection<JobCardItem> JobCardItems { get; set; } = new List<JobCardItem>();

    [InverseProperty("ServiceRequest")]
    public virtual ICollection<JobCardSpare> JobCardSpares { get; set; } = new List<JobCardSpare>();

    [ForeignKey("PartyId")]
    [InverseProperty("JobCards")]
    public virtual Party Party { get; set; } = null!;

    [ForeignKey("SalesId")]
    [InverseProperty("JobCards")]
    public virtual Sale? Sales { get; set; }

    [ForeignKey("ServiceRequestStatusId")]
    [InverseProperty("JobCards")]
    public virtual ServiceRequestStatus ServiceRequestStatus { get; set; } = null!;

    [ForeignKey("UpdatedBy")]
    [InverseProperty("JobCardUpdatedByNavigations")]
    public virtual User UpdatedByNavigation { get; set; } = null!;
}
