using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaybillAPI.DTO;

[Table("settings")]
[Index("CreatedBy", Name = "fk_settings_created_by_idx")]
[Index("UpdatedBy", Name = "fk_settings_updated_by_idx")]
public partial class Setting
{
    [Key]
    public sbyte RowId { get; set; }

    [StringLength(48)]
    public string CompanyName { get; set; } = null!;

    [StringLength(100)]
    public string? SmtpHost { get; set; }

    [StringLength(10)]
    public string? SmtpPort { get; set; }

    [StringLength(150)]
    public string? EmailFrom { get; set; }

    [StringLength(150)]
    public string? EmailTo { get; set; }

    [StringLength(250)]
    public string? EmailPassword { get; set; }

    public sbyte IsAutoEmail { get; set; }

    public sbyte IsBackupOnExit { get; set; }

    public sbyte IsDiscountEnabled { get; set; }

    [StringLength(48)]
    public string? InvoiceTitle { get; set; }

    [StringLength(48)]
    public string? Header1 { get; set; }

    [StringLength(48)]
    public string? Header2 { get; set; }

    [StringLength(48)]
    public string? Header3 { get; set; }

    [Column("GSTIN")]
    [StringLength(15)]
    public string? Gstin { get; set; }

    [Column("GSTSlabRequired")]
    public sbyte GstslabRequired { get; set; }

    [Column("ItemWiseGSTSlabRequired")]
    public sbyte ItemWiseGstslabRequired { get; set; }

    public sbyte AddItemOnSelected { get; set; }

    [StringLength(8)]
    public string? InvoicePrefix { get; set; }

    public sbyte InvoiceLength { get; set; }

    public sbyte IsCreateContactOnParty { get; set; }

    public sbyte IsCompressBackup { get; set; }

    public sbyte IsShadowMenuButton { get; set; }

    public sbyte IsBiometricAuthEnabled { get; set; }

    public sbyte IsAlertOnMinimumStock { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public sbyte ItemCodeAllowNumberOnly { get; set; }

    public sbyte IsPaymentDetailsRequired { get; set; }

    public sbyte IsSavingDetailsRequired { get; set; }

    public sbyte IsGstSummaryRequired { get; set; }

    public sbyte IsSoundEnabled { get; set; }

    [ForeignKey("CreatedBy")]
    [InverseProperty("SettingCreatedByNavigations")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("UpdatedBy")]
    [InverseProperty("SettingUpdatedByNavigations")]
    public virtual User UpdatedByNavigation { get; set; } = null!;
}
