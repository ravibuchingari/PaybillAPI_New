using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("sales")]
[Index("InvoiceNo", Name = "InvoiceNo_UNIQUE", IsUnique = true)]
[Index("CreatedBy", Name = "fk_sales_created_by_idx")]
[Index("PartyId", Name = "fk_sales_party_id_idx")]
public partial class Sale
{
    [Key]
    public int SalesId { get; set; }

    public int? PartyId { get; set; }

    [StringLength(20)]
    public string InvoiceNo { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime InvoiceDate { get; set; }

    [StringLength(20)]
    public string SalesType { get; set; } = null!;

    [StringLength(20)]
    public string PaymentMode { get; set; } = null!;

    [StringLength(12)]
    public string? UpiType { get; set; }

    public double PaidAmount { get; set; }

    public double BalanceAmount { get; set; }

    [StringLength(250)]
    public string? Remarks { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("Sales")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("PartyId")]
    [InverseProperty("Sales")]
    public virtual Party? Party { get; set; }

    [InverseProperty("Sales")]
    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    [InverseProperty("Sales")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
