﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("purchase")]
[Index("CreatedBy", Name = "fk_purchase_created_by_idx")]
[Index("PurchaseOrderId", Name = "fk_purchase_order_id_idx")]
[Index("PartyId", Name = "fk_purchase_partry_id_idx")]
[Index("UpdatedBy", Name = "fk_purchase_updated_by_idx")]
public partial class Purchase
{
    [Key]
    public int PurchaseId { get; set; }

    public int PartyId { get; set; }

    [StringLength(20)]
    public string InvoiceNo { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime InvoiceDate { get; set; }

    [StringLength(20)]
    public string PurchaseType { get; set; } = null!;

    [StringLength(20)]
    public string PaymentMode { get; set; } = null!;

    [StringLength(12)]
    public string? UpiType { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }

    public sbyte IsLocked { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public int? PurchaseOrderId { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("PurchaseCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("PartyId")]
    [InverseProperty("Purchases")]
    public virtual Party Party { get; set; } = null!;

    [InverseProperty("Purchase")]
    public virtual ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();

    [ForeignKey("PurchaseOrderId")]
    [InverseProperty("Purchases")]
    public virtual PurchaseOrder? PurchaseOrder { get; set; }

    [InverseProperty("Purchase")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [InverseProperty("Purchase")]
    public virtual ICollection<UnlockRequest> UnlockRequests { get; set; } = new List<UnlockRequest>();

    [ForeignKey("UpdatedBy")]
    [InverseProperty("PurchaseUpdatedByNavigations")]
    public virtual User UpdatedByNavigation { get; set; } = null!;
}
