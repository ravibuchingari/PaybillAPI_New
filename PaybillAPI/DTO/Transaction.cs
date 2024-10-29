using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("transactions")]
[Index("CreatedBy", Name = "fk_transaction_created_by_idx")]
[Index("PartyId", Name = "fk_transaction_party_id_idx")]
[Index("PurchaseId", Name = "fk_transaction_purchase_id_idx")]
[Index("SalesId", Name = "fk_transaction_sales_id_idx")]
[Index("UpdatedBy", Name = "fk_transaction_updated_by_idx")]
public partial class Transaction
{
    [Key]
    public int TransactionId { get; set; }

    public int PartyId { get; set; }

    [Column(TypeName = "date")]
    public DateTime TransactionDate { get; set; }

    [StringLength(20)]
    public string? PaymentMode { get; set; }

    [StringLength(12)]
    public string? UpiType { get; set; }

    public double ReceiptAmount { get; set; }

    public double PaymentAmount { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }

    public int? SalesId { get; set; }

    public int? PurchaseId { get; set; }

    [StringLength(30)]
    public string TransactionType { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("TransactionCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("PartyId")]
    [InverseProperty("Transactions")]
    public virtual Party Party { get; set; } = null!;

    [ForeignKey("PurchaseId")]
    [InverseProperty("Transactions")]
    public virtual Purchase? Purchase { get; set; }

    [ForeignKey("SalesId")]
    [InverseProperty("Transactions")]
    public virtual Sale? Sales { get; set; }

    [ForeignKey("UpdatedBy")]
    [InverseProperty("TransactionUpdatedByNavigations")]
    public virtual User UpdatedByNavigation { get; set; } = null!;
}
