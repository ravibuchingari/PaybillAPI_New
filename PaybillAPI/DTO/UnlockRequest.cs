using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("unlock_requests")]
[Index("PurchaseId", Name = "fk_request_purchase_id_idx")]
[Index("RequestedBy", Name = "fk_request_requested_by_idx")]
[Index("SalesId", Name = "fk_request_sales_id_idx")]
[Index("RequestStatusId", Name = "fk_request_status_id_idx")]
public partial class UnlockRequest
{
    [Key]
    public int UnlockRequestId { get; set; }

    public int? SalesId { get; set; }

    public int? PurchaseId { get; set; }

    [StringLength(250)]
    public string Remarks { get; set; } = null!;

    public int RequestedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestedDate { get; set; }

    public sbyte RequestStatusId { get; set; }

    [ForeignKey("PurchaseId")]
    [InverseProperty("UnlockRequests")]
    public virtual Purchase? Purchase { get; set; }

    [ForeignKey("RequestStatusId")]
    [InverseProperty("UnlockRequests")]
    public virtual RequestStatus RequestStatus { get; set; } = null!;

    [ForeignKey("RequestedBy")]
    [InverseProperty("UnlockRequests")]
    public virtual User RequestedByNavigation { get; set; } = null!;

    [ForeignKey("SalesId")]
    [InverseProperty("UnlockRequests")]
    public virtual Sale? Sales { get; set; }
}
