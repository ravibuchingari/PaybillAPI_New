using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("message_templates")]
public partial class MessageTemplate
{
    [Key]
    public int MessageId { get; set; }

    [StringLength(500)]
    public string MessageDescription { get; set; } = null!;
}
