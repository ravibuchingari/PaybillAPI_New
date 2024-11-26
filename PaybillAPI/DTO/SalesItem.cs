using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("sales_items")]
[Index("ItemId", Name = "fk_sales_item_item_id_idx")]
[Index("SalesId", Name = "fk_sales_item_sales_id_idx")]
[Index("ServiceTypeId", Name = "fk_sales_item_service_type_id_idx")]
[Index("UpdatedBy", Name = "fk_sales_item_updated_by_idx")]
public partial class SalesItem
{
    [Key]
    public int SalesItemId { get; set; }

    public int SalesId { get; set; }

    public int? ItemId { get; set; }

    public int? ServiceTypeId { get; set; }

    public float Quantity { get; set; }

    public float Rate { get; set; }

    public float Mrp { get; set; }

    public double Amount { get; set; }

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

    public double PurchasePrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int? DeletedBy { get; set; }

    [StringLength(250)]
    public string? DeletedRemarks { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("SalesItems")]
    public virtual Item? Item { get; set; }

    [ForeignKey("SalesId")]
    [InverseProperty("SalesItems")]
    public virtual Sale Sales { get; set; } = null!;

    [ForeignKey("ServiceTypeId")]
    [InverseProperty("SalesItems")]
    public virtual ServiceType? ServiceType { get; set; }

    [ForeignKey("UpdatedBy")]
    [InverseProperty("SalesItems")]
    public virtual User? UpdatedByNavigation { get; set; }
}
