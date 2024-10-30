using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("purchase_items_deleted")]
public partial class PurchaseItemsDeleted
{
    [Key]
    [Column("purchaseDeletedItemId")]
    public int PurchaseDeletedItemId { get; set; }

    public int PurchaseId { get; set; }

    public int ItemId { get; set; }

    public float Quantity { get; set; }

    public float Rate { get; set; }

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

    [StringLength(250)]
    public string Remarks { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DeletedDate { get; set; }
}
