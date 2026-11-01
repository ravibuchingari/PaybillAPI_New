using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paybill.DTO;

[Table("job_cards")]
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

    public int ServiceRequestStatusId { get; set; } = 1;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; } = DateTime.Now;

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    [ForeignKey("PartyId")]
    public virtual Party Party { get; set; } = null!;

    [InverseProperty("ServiceRequest")]
    public virtual ICollection<JobCardItem> JobCardItems { get; set; } = new List<JobCardItem>();

    [InverseProperty("ServiceRequest")]
    public virtual ICollection<JobCardSpare> JobCardSpares { get; set; } = new List<JobCardSpare>();
}

