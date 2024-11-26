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

    [InverseProperty("BalanceMessage")]
    public virtual ICollection<Setting> SettingBalanceMessages { get; set; } = new List<Setting>();

    [InverseProperty("FestivalMessage")]
    public virtual ICollection<Setting> SettingFestivalMessages { get; set; } = new List<Setting>();

    [InverseProperty("SalesMessage")]
    public virtual ICollection<Setting> SettingSalesMessages { get; set; } = new List<Setting>();

    [InverseProperty("ServiceMessage")]
    public virtual ICollection<Setting> SettingServiceMessages { get; set; } = new List<Setting>();
}
