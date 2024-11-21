using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("service_types")]
[Index("CreatedBy", Name = "fk_service_type_createdby_idx")]
[Index("UpdatedBy", Name = "fk_service_type_updatedby_idx")]
[Index("GstId", Name = "fk_service_types_gst_id_idx")]
public partial class ServiceType
{
    [Key]
    public int ServiceTypeId { get; set; }

    [StringLength(100)]
    public string ServiceTypeName { get; set; } = null!;

    public double ServiceCharge { get; set; }

    [StringLength(500)]
    public string? ServiceDescription { get; set; }

    [StringLength(20)]
    public string? SacCode { get; set; }

    public int? GstId { get; set; }

    public sbyte IsActive { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("ServiceTypeCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("GstId")]
    [InverseProperty("ServiceTypes")]
    public virtual Gst? Gst { get; set; }

    [InverseProperty("ServiceType")]
    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    [ForeignKey("UpdatedBy")]
    [InverseProperty("ServiceTypeUpdatedByNavigations")]
    public virtual User UpdatedByNavigation { get; set; } = null!;
}
