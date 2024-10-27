using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaybillAPI.ViewModel
{
    public class SettingVM
    {
        public string? SmtpHost { get; set; }

        public string? SmtpPort { get; set; }

        public string? EmailFrom { get; set; }

        public string? EmailTo { get; set; }

        public string? EmailPassword { get; set; }

        public bool IsAutoEmail { get; set; }

        public bool IsBackupOnExit { get; set; }

        public bool IsDiscountEnabled { get; set; }

        public string? CompanyName { get; set; }

        public string? InvoiceTitle { get; set; }

        public string? Header1 { get; set; }

        public string? Header2 { get; set; }

        public string? Header3 { get; set; }

        public string? Gstin { get; set; }

        public int GstslabRequired { get; set; }

        public bool AddItemOnSelected { get; set; }

        public string? InvoicePrefix { get; set; }

        public bool IsCreateContactOnParty { get; set; }

        public bool IsCompressBackup { get; set; }

        public bool IsShadowMenuButton { get; set; }

        public bool IsBiometricAuthEnabled { get; set; }

        public bool IsAlertOnMinimumStock { get; set; }
        public bool IsSettingsUpdated { get; set; }
    }
}
