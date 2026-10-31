using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("custom_receipt_lines")]
public partial class CustomReceiptLine
{
    [Key]
    public int CustomLineId { get; set; }

    [StringLength(50)]
    public string CustomLineTitle { get; set; } = string.Empty;

    [StringLength(100)]
    public string CustomLineDescription { get; set; } = string.Empty;

    public sbyte IsActive { get; set; } = 1;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

