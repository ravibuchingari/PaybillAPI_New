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

        public int IsAutoEmail { get; set; }

        public int IsBackupOnExit { get; set; }

        public int IsDiscountEnabled { get; set; }

        public string? CompanyName { get; set; }

        public string? InvoiceTitle { get; set; }

        public string? Header1 { get; set; }

        public string? Header2 { get; set; }

        public string? Header3 { get; set; }

        public string? Gstin { get; set; }

        public int GstslabRequired { get; set; }

        public int AddItemOnSelected { get; set; }

        public string? InvoicePrefix { get; set; }

        public int IsCreateContactOnParty { get; set; }

        public int IsCompressBackup { get; set; }

        public int IsShadowMenuButton { get; set; }

        public int IsBiometricAuthEnabled { get; set; }

        public int IsAlertOnMinimumStock { get; set; }
        public bool IsSettingsUpdated { get; set; }
    }
}
