using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("sales_service_items")]
[Index("ServiceTypeId", Name = "fk_sales_service_item_id_idx")]
[Index("SalesId", Name = "fk_sales_service_item_sales_id_idx")]
public partial class SalesServiceItem
{
    [Key]
    public int SalesServiceId { get; set; }

    public int SalesId { get; set; }

    public int ServiceTypeId { get; set; }

    public float Rate { get; set; }

    public double DiscountInRs { get; set; }

    public double TaxableAmount { get; set; }

    public float CgstPer { get; set; }

    public float SgstPer { get; set; }

    public float IgstPer { get; set; }

    public float GstPer { get; set; }

    public double CgstRs { get; set; }

    public double SgstRs { get; set; }

    public double IgstRs { get; set; }

    public double GstAmount { get; set; }

    public double TotalAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int? DeletedBy { get; set; }

    [StringLength(250)]
    public string? DeletedRemarks { get; set; }

    [ForeignKey("SalesId")]
    [InverseProperty("SalesServiceItems")]
    public virtual Sale Sales { get; set; } = null!;

    [ForeignKey("ServiceTypeId")]
    [InverseProperty("SalesServiceItems")]
    public virtual ServiceType ServiceType { get; set; } = null!;
}
