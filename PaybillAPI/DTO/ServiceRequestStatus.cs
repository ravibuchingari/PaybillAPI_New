using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("service_request_status")]
public partial class ServiceRequestStatus
{
    [Key]
    public int ServiceRequestStatusId { get; set; }

    [StringLength(30)]
    public string ServiceRequestStatusName { get; set; } = string.Empty;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

