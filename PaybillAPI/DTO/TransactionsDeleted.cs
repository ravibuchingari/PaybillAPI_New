using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("transactions_deleted")]
public partial class TransactionsDeleted
{
    [Key]
    public int DeletedTransactionId { get; set; }

    public int? PartyId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? TransactionDate { get; set; }

    [StringLength(20)]
    public string? PaymentMode { get; set; }

    [StringLength(12)]
    public string? UpiType { get; set; }

    public double? ReceiptAmount { get; set; }

    public double? PaymentAmount { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }

    public int? SalesId { get; set; }

    public int? PurchaseId { get; set; }

    [StringLength(30)]
    public string? TransactionType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    [StringLength(250)]
    public string? DeletedRemarks { get; set; }
}
