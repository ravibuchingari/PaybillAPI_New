using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("job_card_items")]
public partial class JobCardItem
{
    [Key]
    public int ServiceRequestComplaintId { get; set; }

    public int ServiceRequestId { get; set; }

    public int ServiceTypeId { get; set; }

    public double ServiceCharge { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [ForeignKey("ServiceRequestId")]
    [InverseProperty("JobCardItems")]
    public virtual JobCard ServiceRequest { get; set; } = null!;

    [ForeignKey("ServiceTypeId")]
    public virtual ServiceType ServiceType { get; set; } = null!;
}

