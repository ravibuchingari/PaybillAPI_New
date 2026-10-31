using PaybillAPI.Models;

namespace PaybillAPI.ViewModel
{
    public class SettingVM
    {
        public string? SmtpHost { get; set; } = string.Empty;
        public string? SmtpPort { get; set; } = string.Empty;
        public string? EmailFrom { get; set; } = string.Empty;
        public string? EmailTo { get; set; } = string.Empty;
        public string? EmailPassword { get; set; } = string.Empty;
        public bool IsAutoEmail { get; set; }
        public bool IsBackupOnExit { get; set; } = true;
        public bool IsDiscountEnabled { get; set; }
        public bool AddItemOnSelected { get; set; }
        public string? InvoicePrefix { get; set; } = string.Empty;
        public sbyte InvoiceLength { get; set; } = 6;
        public bool IsCreateContactOnParty { get; set; }
        public bool IsCompressBackup { get; set; }
        public bool IsShadowMenuButton { get; set; }
        public bool IsBiometricAuthEnabled { get; set; } = true;
        public bool IsAlertOnMinimumStock { get; set; } = true;
        public bool IsSettingsUpdated { get; set; }
        public bool ItemCodeAllowNumberOnly { get; set; } = true;
        public bool IsSoundEnabled { get; set; } = true;
        public bool IsSendSmsonInvoice { get; set; }
        public bool IsSendWhatsAppMessageOnInvoice { get; set; }
        public bool IsShareInvoiceOnInvoice { get; set; }
        public bool IsShareInvoice3C { get; set; }
        public int BackupDuration { get; set; } = 30;
        public int? SalesMessageId { get; set; }
        public int? ServiceMessageId { get; set; }
        public int? BalanceMessageId { get; set; }
        public int? FestivalMessageId { get; set; }
        public string? UPIId { get; set; } = string.Empty;
        public string? UPIName { get; set; } = string.Empty;
        public string? UPIMerchantCode { get; set; } = string.Empty;
        public bool IsServiceRequestEnabled { get; set; } = true;
        public bool IsItemSearchImageVisible { get; set; } = true;
        public bool PurchaseOrderItemCodeRequired { get; set; }
        public bool IsBackupOnLogin { get; set; }
        public bool IsViewAllItemsOnSearch { get; set; } = true;
        public string? EmailBodyForSalesInvoice { get; set; } = "Please find the attached copy of sales invoice";
        public bool IsSalesPriceEdited { get; set; }
        public bool IsSalesInvoiceDateEnabled { get; set; } = true;
        public bool IsCurrencyDecimalNotRequired { get; set; }
        public string LocalLanguageCode { get; set; } = "te";
        public string? BankDetails { get; set; } = string.Empty;
        public bool IsOnlineStoreEnabled { get; set; }
        public bool IsPrintLocalLanguage { get; set; }
        public bool IsAutoBackupWhatsAppEnabled { get; set; } = true;
        public bool IsAutoBackupEmailEnabled { get; set; }
        public string PaymentGatewayName { get; set; } = "None";
        public string PaymentGatewayMerchantId { get; set; } = string.Empty;
        public string PaymentGatewayApiKey { get; set; } = string.Empty;
        public string PaymentGatewayApiSecret { get; set; } = string.Empty;
        public int MaxItemImageDimension { get; set; } = 256;

        // Customer Rewards Points Settings
        public bool IsRewardsEnabled { get; set; }
        public string RewardEarningMethod { get; set; } = "FIXED_POINTS";
        public double RewardEarningPurchaseAmount { get; set; } = 100.0;
        public double RewardEarningPoints { get; set; } = 1.0;
        public double RewardEarningPercentage { get; set; } = 2.0;
        public double RewardPointValue { get; set; } = 1.0;
        public double RewardMinPurchaseForEarning { get; set; } = 100.0;
        public double RewardMinPointsForRedemption { get; set; } = 0.0;
        public double RewardMinInvoiceForRedemption { get; set; } = 0.0;
        public double RewardMaxRedemptionPercentage { get; set; } = 20.0;
        public bool RewardAllowPartialRedemption { get; set; } = true;
        public bool RewardAllowSameInvoiceRedemption { get; set; } = false;
        public bool RewardIsExpiryEnabled { get; set; } = false;
        public int RewardExpiryDays { get; set; } = 365;
        public string RewardEligibleAmountType { get; set; } = "TOTAL_WITH_TAX";
        public string RewardStartDate { get; set; } = string.Empty;
        public string RewardEndDate { get; set; } = string.Empty;

        public PrintHeader HeaderModel { get; set; } = new PrintHeader();
    }
}
