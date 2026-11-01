using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Paybill.DTO;

[Table("sales")]
[Index("InvoiceNo", Name = "InvoiceNo_UNIQUE", IsUnique = true)]
[Index("CreatedBy", Name = "fk_sales_created_by_idx")]
[Index("PartyId", Name = "fk_sales_party_id_idx")]
[Index("UpdatedBy", Name = "fk_sales_updated_by_idx")]
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

    public sbyte IsLocked { get; set; }

    [StringLength(250)]
    public string? Remarks { get; set; }

    public int CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    [StringLength(10)]
    public string? EndUserMobile { get; set; }

    public int? ServiceRequestId { get; set; }

    public double RewardPointsEarned { get; set; }

    public double RewardPointsRedeemed { get; set; }

    public double RewardDiscountAmount { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SaleCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [InverseProperty("Sales")]
    public virtual ICollection<JobCard> JobCards { get; set; } = new List<JobCard>();

    [ForeignKey("PartyId")]
    [InverseProperty("Sales")]
    public virtual Party? Party { get; set; }

    [InverseProperty("Sales")]
    public virtual ICollection<RewardTransaction> RewardTransactions { get; set; } = new List<RewardTransaction>();

    [InverseProperty("Sales")]
    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

    [InverseProperty("Sales")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [InverseProperty("Sales")]
    public virtual ICollection<UnlockRequest> UnlockRequests { get; set; } = new List<UnlockRequest>();

    [ForeignKey("UpdatedBy")]
    [InverseProperty("SaleUpdatedByNavigations")]
    public virtual User? UpdatedByNavigation { get; set; }
}
