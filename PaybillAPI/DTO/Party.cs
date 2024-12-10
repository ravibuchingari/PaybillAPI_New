using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("parties")]
[Index("CreatedBy", Name = "fk_parties_created_by_idx")]
[Index("UpdatedBy", Name = "fk_parties_updated_by_idx")]
public partial class Party
{
    [Key]
    public int PartyId { get; set; }

    [StringLength(100)]
    public string PartyName { get; set; } = null!;

    [StringLength(500)]
    public string PartyAddress { get; set; } = null!;

    [StringLength(500)]
    public string? PartyShippingAddress { get; set; }

    [StringLength(10)]
    public string? PartyMobile { get; set; }

    [StringLength(150)]
    public string? PartyEmail { get; set; }

    [StringLength(15)]
    public string? PartyGstNo { get; set; }

    [StringLength(500)]
    public string? PartyRemarks { get; set; }

    public sbyte IsVendor { get; set; }

    public sbyte IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PartyCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Party")]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    [InverseProperty("Party")]
    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    [InverseProperty("Party")]
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    [InverseProperty("Party")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [ForeignKey("UpdatedBy")]
    [InverseProperty("PartyUpdatedByNavigations")]
    public virtual User UpdatedByNavigation { get; set; } = null!;
}
