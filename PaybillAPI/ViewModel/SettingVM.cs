using PaybillAPI.Models;

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

        public bool AddItemOnSelected { get; set; }

        public string? InvoicePrefix { get; set; }
        public sbyte InvoiceLength { get; set; }

        public bool IsCreateContactOnParty { get; set; }

        public bool IsCompressBackup { get; set; }

        public bool IsShadowMenuButton { get; set; }

        public bool IsBiometricAuthEnabled { get; set; }

        public bool IsAlertOnMinimumStock { get; set; }
        public bool IsSettingsUpdated { get; set; }
        public bool ItemCodeAllowNumberOnly { get; set; }
        public bool IsSoundEnabled { get; set; }
        public bool IsSendSmsonInvoice { get; set; }
        public int? SalesMessageId { get; set; }
        public int? ServiceMessageId { get; set; }
        public int? BalanceMessageId { get; set; }
        public int? FestivalMessageId { get; set; }
        public bool IsServiceRequestEnabled { get; set; }
        public PrintHeader HeaderModel { get; set; } = new PrintHeader();

    }
}
