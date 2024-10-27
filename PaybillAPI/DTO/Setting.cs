using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaybillAPI.DTO;

[Keyless]
[Table("settings")]
[Index("CreatedBy", Name = "fk_settings_created_by_idx")]
[Index("UpdatedBy", Name = "fk_settings_updated_by_idx")]
public partial class Setting
{
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

    public int IsAutoEmail { get; set; }

    public int IsBackupOnExit { get; set; }

    public int IsDiscountEnabled { get; set; }

    [StringLength(48)]
    public string? CompanyName { get; set; }

    [StringLength(48)]
    public string? InvoiceTitle { get; set; }

    [StringLength(48)]
    public string? Header1 { get; set; }

    [StringLength(48)]
    public string? Header2 { get; set; }

    [StringLength(48)]
    public string? Header3 { get; set; }

    [Column("GSTIN")]
    [StringLength(20)]
    public string? Gstin { get; set; }

    [Column("GSTSlabRequired")]
    public int GstslabRequired { get; set; }

    public int AddItemOnSelected { get; set; }

    [StringLength(8)]
    public string? InvoicePrefix { get; set; }

    public int IsCreateContactOnParty { get; set; }

    public int IsCompressBackup { get; set; }

    public int IsShadowMenuButton { get; set; }

    public int IsBiometricAuthEnabled { get; set; }

    public int IsAlertOnMinimumStock { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    public virtual User CreatedByNavigation { get; set; } = null!;

    [ForeignKey("UpdatedBy")]
    public virtual User UpdatedByNavigation { get; set; } = null!;
}
