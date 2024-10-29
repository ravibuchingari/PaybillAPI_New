using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("sales_items")]
[Index("ItemId", Name = "fk_sales_item_item_id_idx")]
[Index("SalesId", Name = "fk_sales_item_sales_id_idx")]
public partial class SalesItem
{
    [Key]
    public int SalesItemId { get; set; }

    public int SalesId { get; set; }

    public int ItemId { get; set; }

    public float Quantity { get; set; }

    public float Rate { get; set; }

    public float Mrp { get; set; }

    public double Amount { get; set; }

    public double DiscountInRs { get; set; }

    public float GstPer { get; set; }

    public double GstAmount { get; set; }

    public double TaxableAmount { get; set; }

    public double TotalAmount { get; set; }

    public float CgstPer { get; set; }

    public float SgstPer { get; set; }

    public float IgstPer { get; set; }

    public double CgstRs { get; set; }

    public double SgstRs { get; set; }

    public double IgstRs { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("SalesItems")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("SalesId")]
    [InverseProperty("SalesItems")]
    public virtual Sale Sales { get; set; } = null!;
}
