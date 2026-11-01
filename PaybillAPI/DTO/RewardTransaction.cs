using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paybill.DTO;

[Table("reward_transactions")]
public partial class RewardTransaction
{
    [Key]
    public int RewardTransId { get; set; }

    public int PartyId { get; set; }

    public int? SalesId { get; set; } = 0;

    [StringLength(20)]
    public string TransactionType { get; set; } = string.Empty;

    public double PointsCredited { get; set; }

    public double PointsDebited { get; set; }

    public double MonetaryValue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; } = DateTime.Now;

    [StringLength(250)]
    public string? Description { get; set; } = string.Empty;

    public int? RefTransId { get; set; } = 0;

    public int? CreatedBy { get; set; } = 0;

    [ForeignKey("PartyId")]
    public virtual Customer? Party { get; set; }

    [ForeignKey("SalesId")]
    public virtual Sale? Sales { get; set; }
}
