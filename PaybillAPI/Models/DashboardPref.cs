namespace Paybill.Models
{
    public class DashboardPref
    {
        public bool IsAutoEmail { get; set; }
        public bool IsBackupOnExit { get; set; } = true;
        public bool IsBackupOnLogin { get; set; }
        public bool IsDiscountEnabled { get; set; }
        public bool AddItemOnSelected { get; set; }
        public bool IsCreateContactOnParty { get; set; }
        public bool IsCompressBackup { get; set; }
        public bool IsShadowMenuButton { get; set; } = true;
        public bool IsSettingsUpdated { get; set; }
        public bool IsAlertOnMinimumStock { get; set; } = true;
        public bool IsAlertOnNegativeBalance { get; set; } = true;
        public bool ItemCodeAllowNumberOnly { get; set; } = true;
        public string ServiceGSTCode { get; set; } = string.Empty;
        public bool IsBiometricAuthEnabled { get; set; }
        public bool IsSoundEnabled { get; set; } = true;
        public bool IsSendSmsonInvoice { get; set; }
        public bool IsSendWhatsAppMessageOnInvoice { get; set; }
        public bool IsShareInvoiceOnInvoice { get; set; }
        public bool IsShareInvoice3C { get; set; }
        public int? SalesMessageId { get; set; }
        public int? ServiceMessageId { get; set; }
        public int? BalanceMessageId { get; set; }
        public int? FestivalMessageId { get; set; }
        public string? UPIId { get; set; } = string.Empty;
        public string? UPIName { get; set; } = string.Empty;
        public string? UPIMerchantCode { get; set; } = string.Empty;
        public bool IsServiceRequestEnabled { get; set; }
        public bool IsItemSearchImageVisible { get; set; }
        public bool IsViewAllItemsOnSearch { get; set; }
        public string? EmailBodyForSalesInvoice { get; set; } = "Please find the attached copy of sales invoice";
        public bool IsSalesPriceEdited { get; set; }
        public bool IsSalesInvoiceDateEnabled { get; set; } = true;
        public bool IsCurrencyDecimalNotRequired { get; set; }
        public string LocalLanguageCode { get; set; } = string.Empty;
        public bool IsPrintLocalLanguage { get; set; }
        public bool IsOnlineStoreEnabled { get; set; }
        public bool IsAutoBackupWhatsAppEnabled { get; set; }
        public bool IsAutoBackupEmailEnabled { get; set; }
        public string PaymentGatewayName { get; set; } = "None";
        public string PaymentGatewayMerchantId { get; set; } = string.Empty;
        public string PaymentGatewayApiKey { get; set; } = string.Empty;
        public string PaymentGatewayApiSecret { get; set; } = string.Empty;
        public int MaxItemImageDimension { get; set; } = 512;
        public bool IsRewardsEnabled { get; set; }
        public PrintHeader HeaderModel { get; set; } = new PrintHeader();
    }
}
