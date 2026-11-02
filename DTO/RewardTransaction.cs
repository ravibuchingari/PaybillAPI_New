using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Paybill.DTO;

[Table("reward_transactions")]
[Index("TransactionDate", Name = "idx_reward_trans_date")]
[Index("PartyId", Name = "idx_reward_trans_party_id")]
[Index("SalesId", Name = "idx_reward_trans_sales_id")]
public partial class RewardTransaction
{
    [Key]
    public int RewardTransId { get; set; }

    public int PartyId { get; set; }

    public int? SalesId { get; set; }

    [StringLength(20)]
    public string TransactionType { get; set; } = null!;

    public double PointsCredited { get; set; }

    public double PointsDebited { get; set; }

    public double MonetaryValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }

    public int? RefTransId { get; set; }

    public int? CreatedBy { get; set; }

    [ForeignKey("PartyId")]
    [InverseProperty("RewardTransactions")]
    public virtual Party Party { get; set; } = null!;

    [ForeignKey("SalesId")]
    [InverseProperty("RewardTransactions")]
    public virtual Sale? Sales { get; set; }
}
