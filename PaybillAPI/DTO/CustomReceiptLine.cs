using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paybill.DTO;

[Table("custom_receipt_lines")]
public partial class CustomReceiptLine
{
    [Key]
    public int CustomLineId { get; set; }

    [StringLength(50)]
    public string CustomLineTitle { get; set; } = null!;

    [StringLength(100)]
    public string CustomLineDescription { get; set; } = null!;

    public sbyte IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
