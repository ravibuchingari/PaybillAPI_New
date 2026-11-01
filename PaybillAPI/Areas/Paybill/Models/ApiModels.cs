using Paybill.ViewModel;

namespace Paybill.Areas.Paybill.Models
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Data { get; set; }
    }

    public class CountryModel
    {
        public int CountryId { get; set; } = 28;
        public string CountryName { get; set; } = "India";
        public string CountryCurrencyCode { get; set; } = "INR";
        public string CountryCurrencySymbol { get; set; } = "â‚¹";
        public string CountryLocaleCode { get; set; } = "in";
        public int CountryMobileLength { get; set; } = 10;
    }

    //public class UserVM
    //{
    //    public int UserRowId { get; set; }
    //    public string UserId { get; set; } = string.Empty;
    //    public string Password { get; set; } = string.Empty;
    //    public string FirstName { get; set; } = string.Empty;
    //    public string LastName { get; set; } = string.Empty;
    //    public string Address { get; set; } = string.Empty;
    //    public string Mobile { get; set; } = string.Empty;
    //    public string? Email { get; set; } = string.Empty;
    //    public bool IsAdmin { get; set; }
    //    public bool IsActive { get; set; } = true;
    //    public string? JwtToken { get; set; }
    //    public string? SecurityKey { get; set; }
    //    public string? SaltKey { get; set; }
    //    public string? BiometricAuthKey { get; set; }
    //    public ClientVM? Client { get; set; }
    //    public string FullName => $"{FirstName} {LastName}".Trim();
    //}

    public class AuthRequestVM
    {
        public string ClientUniqueId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? BiometricAuthKey { get; set; }
    }

    public class TokenParameter
    {
        public string UserRowId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string UserRole { get; set; } = null!;
        public string SecurityKey { get; set; } = null!;
        public string ClientName { get; set; } = null!;
    }

    public class PrintHeader
    {
        public string InvoiceTitle { get; set; } = "Tax Invoice";
        public string CompanyName { get; set; } = string.Empty;
        public string Header1 { get; set; } = string.Empty;
        public string Header2 { get; set; } = string.Empty;
        public string Header3 { get; set; } = string.Empty;
        public string Gstin { get; set; } = string.Empty;
        public bool GstSlabRequired { get; set; } = true;
        public bool IsPaymentDetailsRequired { get; set; } = true;
        public bool IsSavingDetailsRequired { get; set; } = true;
        public bool IsGstSummaryRequired { get; set; } = true;
        public bool ItemWiseGstSlabRequired { get; set; } = true;
        public string BankDetails { get; set; } = string.Empty;
        public string FooterLine1 { get; set; } = "Thank you for your business!";
        public string FooterLine2 { get; set; } = string.Empty;

        public string HeaderLine1
        {
            get => CompanyName;
            set => CompanyName = value;
        }
        public string HeaderLine2
        {
            get => Header1;
            set => Header1 = value;
        }
        public string HeaderLine3
        {
            get => Header2;
            set => Header2 = value;
        }
        public string HeaderLine4
        {
            get => Header3;
            set => Header3 = value;
        }
        public string HeaderLine5
        {
            get => Gstin;
            set => Gstin = value;
        }
    }

    public class DashboardPref
    {
        public bool IsAutoEmail { get; set; }
        public bool IsBackupOnExit { get; set; } = true;
        public bool IsBackupOnLogin { get; set; }
        public bool IsDiscountEnabled { get; set; } = true;
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
        public bool IsServiceRequestEnabled { get; set; } = true;
        public bool IsItemSearchImageVisible { get; set; }
        public bool IsViewAllItemsOnSearch { get; set; } = true;
        public string? EmailBodyForSalesInvoice { get; set; } = "Please find the attached copy of sales invoice";
        public bool IsSalesPriceEdited { get; set; } = true;
        public bool IsSalesInvoiceDateEnabled { get; set; } = true;
        public bool IsCurrencyDecimalNotRequired { get; set; }
        public string LocalLanguageCode { get; set; } = "te";
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
        public PrintHeader HeaderModel { get; set; } = new();
    }

    public class MessageTemplateVM
    {
        public int MessageId { get; set; }
        public string MessageType { get; set; } = "Sales Invoice";
        public string MessageDescription { get; set; } = string.Empty;
        public bool IsSelected { get; set; }

        public string Description
        {
            get => MessageDescription;
            set => MessageDescription = value;
        }
    }

    public class AuthResponseVM
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsBiometricAuthentication { get; set; }
        public UserVM User { get; set; } = new();
        public DashboardPref Pref { get; set; } = new();
        public IEnumerable<MessageTemplateVM>? MessageTemplates { get; set; }
    }

    //public class SettingVM
    //{
    //    public int SettingId { get; set; }
    //    public string? SmtpHost { get; set; } = string.Empty;
    //    public string? SmtpPort { get; set; } = string.Empty;
    //    public string? EmailFrom { get; set; } = string.Empty;
    //    public string? EmailTo { get; set; } = string.Empty;
    //    public string? EmailPassword { get; set; } = string.Empty;
    //    public bool IsAutoEmail { get; set; }
    //    public bool IsBackupOnExit { get; set; } = true;
    //    public bool IsDiscountEnabled { get; set; } = true;
    //    public bool AddItemOnSelected { get; set; }
    //    public string? InvoicePrefix { get; set; } = "INV-";
    //    public sbyte InvoiceLength { get; set; } = 6;
    //    public bool IsCreateContactOnParty { get; set; }
    //    public bool IsCompressBackup { get; set; }
    //    public bool IsShadowMenuButton { get; set; }
    //    public bool IsBiometricAuthEnabled { get; set; } = true;
    //    public bool IsAlertOnMinimumStock { get; set; } = true;
    //    public bool IsSettingsUpdated { get; set; }
    //    public bool ItemCodeAllowNumberOnly { get; set; } = true;
    //    public bool IsSoundEnabled { get; set; } = true;
    //    public bool IsSendSmsonInvoice { get; set; }
    //    public bool IsSendWhatsAppMessageOnInvoice { get; set; }
    //    public bool IsShareInvoiceOnInvoice { get; set; }
    //    public bool IsShareInvoice3C { get; set; }
    //    public int BackupDuration { get; set; } = 30;
    //    public int? SalesMessageId { get; set; }
    //    public int? ServiceMessageId { get; set; }
    //    public int? BalanceMessageId { get; set; }
    //    public int? FestivalMessageId { get; set; }
    //    public string? UPIId { get; set; } = string.Empty;
    //    public string? UPIName { get; set; } = string.Empty;
    //    public string? UPIMerchantCode { get; set; } = string.Empty;
    //    public bool IsServiceRequestEnabled { get; set; } = true;
    //    public bool IsItemSearchImageVisible { get; set; } = true;
    //    public bool PurchaseOrderItemCodeRequired { get; set; }
    //    public bool IsBackupOnLogin { get; set; }
    //    public bool IsViewAllItemsOnSearch { get; set; } = true;
    //    public string? EmailBodyForSalesInvoice { get; set; } = "Please find the attached copy of sales invoice";
    //    public bool IsSalesPriceEdited { get; set; } = true;
    //    public bool IsSalesInvoiceDateEnabled { get; set; } = true;
    //    public bool IsCurrencyDecimalNotRequired { get; set; }
    //    public string LocalLanguageCode { get; set; } = "te";
    //    public string? BankDetails { get; set; } = string.Empty;
    //    public bool IsOnlineStoreEnabled { get; set; }
    //    public bool IsPrintLocalLanguage { get; set; }
    //    public bool IsAutoBackupWhatsAppEnabled { get; set; } = true;
    //    public bool IsAutoBackupEmailEnabled { get; set; }
    //    public string PaymentGatewayName { get; set; } = "None";
    //    public string PaymentGatewayMerchantId { get; set; } = string.Empty;
    //    public string PaymentGatewayApiKey { get; set; } = string.Empty;
    //    public string PaymentGatewayApiSecret { get; set; } = string.Empty;
    //    public int MaxItemImageDimension { get; set; } = 256;

    //    // Customer Rewards Points Settings
    //    public bool IsRewardsEnabled { get; set; }
    //    public string RewardEarningMethod { get; set; } = "FIXED_POINTS";
    //    public double RewardEarningPurchaseAmount { get; set; } = 100.0;
    //    public double RewardEarningPoints { get; set; } = 1.0;
    //    public double RewardEarningPercentage { get; set; } = 2.0;
    //    public double RewardPointValue { get; set; } = 1.0;
    //    public double RewardMinPurchaseForEarning { get; set; } = 100.0;
    //    public double RewardMinPointsForRedemption { get; set; } = 0.0;
    //    public double RewardMinInvoiceForRedemption { get; set; } = 0.0;
    //    public double RewardMaxRedemptionPercentage { get; set; } = 20.0;
    //    public bool RewardAllowPartialRedemption { get; set; } = true;
    //    public bool RewardAllowSameInvoiceRedemption { get; set; } = false;
    //    public bool RewardIsExpiryEnabled { get; set; } = false;
    //    public int RewardExpiryDays { get; set; } = 365;
    //    public string RewardEligibleAmountType { get; set; } = "TOTAL_WITH_TAX";
    //    public string RewardStartDate { get; set; } = string.Empty;
    //    public string RewardEndDate { get; set; } = string.Empty;

    //    public PrintHeader HeaderModel { get; set; } = new();

    //    // Convenience bindings for Razor views
    //    public string ReceiptHeaderLine1
    //    {
    //        get => HeaderModel.CompanyName;
    //        set => HeaderModel.CompanyName = value ?? string.Empty;
    //    }
    //    public string ReceiptHeaderLine2
    //    {
    //        get => HeaderModel.Header1;
    //        set => HeaderModel.Header1 = value ?? string.Empty;
    //    }
    //    public string ReceiptHeaderLine3
    //    {
    //        get => HeaderModel.Header2;
    //        set => HeaderModel.Header2 = value ?? string.Empty;
    //    }
    //    public string ReceiptHeaderLine4
    //    {
    //        get => HeaderModel.Header3;
    //        set => HeaderModel.Header3 = value ?? string.Empty;
    //    }
    //    public string ReceiptHeaderLine5
    //    {
    //        get => HeaderModel.Gstin;
    //        set => HeaderModel.Gstin = value ?? string.Empty;
    //    }
    //    public string ReceiptFooterLine1
    //    {
    //        get => HeaderModel.FooterLine1;
    //        set => HeaderModel.FooterLine1 = value ?? string.Empty;
    //    }
    //    public string ReceiptFooterLine2
    //    {
    //        get => HeaderModel.FooterLine2;
    //        set => HeaderModel.FooterLine2 = value ?? string.Empty;
    //    }
    //    public bool IsGstInvoice
    //    {
    //        get => HeaderModel.GstSlabRequired;
    //        set => HeaderModel.GstSlabRequired = value;
    //    }
    //    public bool ResetInvoiceNumberFinancialYear { get; set; } = true;
    //    public bool DisplayItemStockOnSales
    //    {
    //        get => IsViewAllItemsOnSearch;
    //        set => IsViewAllItemsOnSearch = value;
    //    }
    //    public bool AllowNegativeStock { get; set; } = true;
    //    public bool PrintQrCode { get; set; } = true;
    //    public bool PrintTotalSavings
    //    {
    //        get => HeaderModel.IsSavingDetailsRequired;
    //        set => HeaderModel.IsSavingDetailsRequired = value;
    //    }
    //    public string? UpiId
    //    {
    //        get => UPIId;
    //        set => UPIId = value;
    //    }
    //    public string? BankName
    //    {
    //        get => BankDetails;
    //        set => BankDetails = value;
    //    }
    //    public string? BankAccountNumber { get; set; } = string.Empty;
    //    public string? BankIfscCode { get; set; } = string.Empty;
    //    public string PaymentGatewayKeyId
    //    {
    //        get => PaymentGatewayApiKey;
    //        set => PaymentGatewayApiKey = value ?? string.Empty;
    //    }
    //    public bool EnableCustomerRewards
    //    {
    //        get => IsRewardsEnabled;
    //        set => IsRewardsEnabled = value;
    //    }
    //    public double RewardPointsPerHundredRupees
    //    {
    //        get => RewardEarningPoints;
    //        set => RewardEarningPoints = value;
    //    }
    //    public double RewardMinInvoiceAmount
    //    {
    //        get => RewardMinPurchaseForEarning;
    //        set => RewardMinPurchaseForEarning = value;
    //    }
    //    public int RewardPointsExpiryDays
    //    {
    //        get => RewardExpiryDays;
    //        set
    //        {
    //            RewardExpiryDays = value;
    //            RewardIsExpiryEnabled = value > 0;
    //        }
    //    }
    //    public string? SenderEmail
    //    {
    //        get => EmailFrom;
    //        set => EmailFrom = value;
    //    }
    //    public string? SenderPassword
    //    {
    //        get => EmailPassword;
    //        set => EmailPassword = value;
    //    }
    //}

    //public class CustomReceiptLineVM
    //{
    //    public int CustomLineId { get; set; }
    //    public string CustomLineTitle { get; set; } = string.Empty;
    //    public string CustomLineDescription { get; set; } = string.Empty;
    //    public bool IsActive { get; set; } = true;
    //    public int DisplayOrder { get; set; } = 1;
    //    public bool IsBold { get; set; }
    //    public bool IsItalic { get; set; }

    //    public string LineText
    //    {
    //        get => !string.IsNullOrWhiteSpace(CustomLineDescription) ? CustomLineDescription : CustomLineTitle;
    //        set
    //        {
    //            CustomLineDescription = value ?? string.Empty;
    //            if (string.IsNullOrWhiteSpace(CustomLineTitle))
    //                CustomLineTitle = value ?? string.Empty;
    //        }
    //    }
    //}

    //public class CategoryVM
    //{
    //    public int CategoryId { get; set; }
    //    public string CategoryName { get; set; } = string.Empty;
    //    public int ItemCount { get; set; }
    //}

    //public class GstVM
    //{
    //    public int GstId { get; set; }
    //    public float CgstPer { get; set; }
    //    public float SgstPer { get; set; }
    //    public float IgstPer { get; set; }
    //    public bool IsActive { get; set; } = true;
    //}

    //public class ServiceTypeVM
    //{
    //    public int ServiceTypeId { get; set; }
    //    public string ServiceTypeName { get; set; } = string.Empty;
    //    public double ServiceCharge { get; set; }
    //    public string? ServiceDescription { get; set; } = string.Empty;
    //    public string? SacCode { get; set; } = string.Empty;
    //    public bool IsActive { get; set; } = true;
    //    public GstVM? GstModel { get; set; }

    //    public double Rate
    //    {
    //        get => ServiceCharge;
    //        set => ServiceCharge = value;
    //    }
    //    public GstVM? Gst
    //    {
    //        get => GstModel;
    //        set => GstModel = value;
    //    }
    //    public int GstId
    //    {
    //        get => GstModel?.GstId ?? 0;
    //        set
    //        {
    //            GstModel ??= new GstVM();
    //            GstModel.GstId = value;
    //        }
    //    }
    //}

    //public class ItemVM
    //{
    //    public int ItemId { get; set; }
    //    public string ItemCode { get; set; } = string.Empty;
    //    public string ItemName { get; set; } = string.Empty;
    //    public string ItemLocalName { get; set; } = string.Empty;
    //    public string? AliasName { get; set; } = string.Empty;
    //    public float Mrp { get; set; }
    //    public float SalesPrice { get; set; }
    //    public float PurchasePrice { get; set; }
    //    public string? HSncode { get; set; } = string.Empty;
    //    public string? Measure { get; set; } = "PCS";
    //    public double OpeningStock { get; set; }
    //    public double ClosingStock { get; set; }
    //    public double MinimumStock { get; set; }
    //    public bool IsActive { get; set; } = true;
    //    public string? Shelf { get; set; } = string.Empty;
    //    public CategoryVM? CategoryModel { get; set; }
    //    public GstVM? GstModel { get; set; }
    //    public string? UpdatedDate { get; set; }
    //    public int Age { get; set; }
    //    public float DiscountPer { get; set; }
    //    public float DiscountRs { get; set; }
    //    public bool IsGstInclusive { get; set; }

    //    public string? Barcode
    //    {
    //        get => AliasName;
    //        set => AliasName = value;
    //    }
    //    public string? HsnCode
    //    {
    //        get => HSncode;
    //        set => HSncode = value;
    //    }
    //    public double Stock
    //    {
    //        get => ClosingStock;
    //        set => ClosingStock = value;
    //    }
    //    public double MinStock
    //    {
    //        get => MinimumStock;
    //        set => MinimumStock = value;
    //    }
    //    public CategoryVM? Category
    //    {
    //        get => CategoryModel;
    //        set => CategoryModel = value;
    //    }
    //    public int CategoryId
    //    {
    //        get => CategoryModel?.CategoryId ?? 0;
    //        set
    //        {
    //            CategoryModel ??= new CategoryVM();
    //            CategoryModel.CategoryId = value;
    //        }
    //    }
    //    public GstVM? Gst
    //    {
    //        get => GstModel;
    //        set => GstModel = value;
    //    }
    //    public int GstId
    //    {
    //        get => GstModel?.GstId ?? 0;
    //        set
    //        {
    //            GstModel ??= new GstVM();
    //            GstModel.GstId = value;
    //        }
    //    }
    //}

    //public class PartyVM
    //{
    //    public int PartyId { get; set; }
    //    public string PartyName { get; set; } = string.Empty;
    //    public string PartyAddress { get; set; } = string.Empty;
    //    public string PartyShippingAddress { get; set; } = string.Empty;
    //    public string? PartyMobile { get; set; } = string.Empty;
    //    public string? PartyEmail { get; set; } = string.Empty;
    //    public string? PartyGstNo { get; set; } = string.Empty;
    //    public string? PartyRemarks { get; set; } = string.Empty;
    //    public bool IsVendor { get; set; }
    //    public bool IsActive { get; set; } = true;
    //    public double OpeningBalance { get; set; }
    //    public string? Phone { get; set; } = string.Empty;

    //    public string? Mobile
    //    {
    //        get => PartyMobile;
    //        set => PartyMobile = value;
    //    }
    //    public string? Email
    //    {
    //        get => PartyEmail;
    //        set => PartyEmail = value;
    //    }
    //    public string? Gstin
    //    {
    //        get => PartyGstNo;
    //        set => PartyGstNo = value;
    //    }
    //    public string Address
    //    {
    //        get => PartyAddress;
    //        set => PartyAddress = value ?? string.Empty;
    //    }
    //    public string? Remarks
    //    {
    //        get => PartyRemarks;
    //        set => PartyRemarks = value;
    //    }
    //}

    public class InvoiceSummary
    {
        public double TotalAmount { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalTaxableAmount { get; set; }
        public double TotalGSTAmount { get; set; }
        public double TotalInvoiceAmount { get; set; }
    }

    //public class SalesItemVM
    //{
    //    public int SalesItemId { get; set; }
    //    public int SalesId { get; set; }
    //    public float Quantity { get; set; }
    //    public float Rate { get; set; }
    //    public float Mrp { get; set; }
    //    public double Amount { get; set; }
    //    public double DiscountInRs { get; set; }
    //    public double TaxableAmount { get; set; }
    //    public float CgstPer { get; set; }
    //    public float SgstPer { get; set; }
    //    public float IgstPer { get; set; }
    //    public float GstPer { get; set; }
    //    public double CgstRs { get; set; }
    //    public double SgstRs { get; set; }
    //    public double IgstRs { get; set; }
    //    public double GstAmount { get; set; }
    //    public double TotalAmount { get; set; }
    //    public ItemVM? ItemModel { get; set; }
    //    public ServiceTypeVM? ServiceTypeModel { get; set; }
    //    public string? CreatedDate { get; set; }
    //    public string? DeletedDate { get; set; }
    //    public string? DeletedBy { get; set; }
    //    public string? DeletedRemarks { get; set; }
    //    public float DiscountPer { get; set; }
    //    public int GstId { get; set; }
    //    public string? InvoiceNumber { get; set; }

    //    public ItemVM? Item
    //    {
    //        get => ItemModel;
    //        set => ItemModel = value;
    //    }
    //    public int? ItemId
    //    {
    //        get => ItemModel?.ItemId;
    //        set
    //        {
    //            if (value.HasValue && value.Value > 0)
    //            {
    //                ItemModel ??= new ItemVM();
    //                ItemModel.ItemId = value.Value;
    //            }
    //        }
    //    }
    //    public ServiceTypeVM? ServiceType
    //    {
    //        get => ServiceTypeModel;
    //        set => ServiceTypeModel = value;
    //    }
    //    public int? ServiceTypeId
    //    {
    //        get => ServiceTypeModel?.ServiceTypeId;
    //        set
    //        {
    //            if (value.HasValue && value.Value > 0)
    //            {
    //                ServiceTypeModel ??= new ServiceTypeVM();
    //                ServiceTypeModel.ServiceTypeId = value.Value;
    //            }
    //        }
    //    }
    //    public float SalesPrice
    //    {
    //        get => Rate;
    //        set
    //        {
    //            Rate = value;
    //            if (Amount == 0 && Quantity > 0)
    //                Amount = Math.Round(Quantity * value, 2);
    //        }
    //    }
    //    public double DiscountRs
    //    {
    //        get => DiscountInRs;
    //        set => DiscountInRs = value;
    //    }
    //    public double CgstAmount
    //    {
    //        get => CgstRs;
    //        set
    //        {
    //            CgstRs = value;
    //            GstAmount = CgstRs + SgstRs + IgstRs;
    //        }
    //    }
    //    public double SgstAmount
    //    {
    //        get => SgstRs;
    //        set
    //        {
    //            SgstRs = value;
    //            GstAmount = CgstRs + SgstRs + IgstRs;
    //        }
    //    }
    //    public double IgstAmount
    //    {
    //        get => IgstRs;
    //        set
    //        {
    //            IgstRs = value;
    //            GstAmount = CgstRs + SgstRs + IgstRs;
    //        }
    //    }
    //    public string? SalesDate
    //    {
    //        get => CreatedDate;
    //        set => CreatedDate = value;
    //    }
    //    public string? Remarks
    //    {
    //        get => DeletedRemarks;
    //        set => DeletedRemarks = value;
    //    }
    //}

    //public class SalesVM
    //{
    //    public int SalesId { get; set; }
    //    public string InvoiceNo { get; set; } = string.Empty;
    //    public string InvoiceDate { get; set; } = string.Empty;
    //    public string SalesType { get; set; } = "Cash";
    //    public string PaymentMode { get; set; } = "Cash";
    //    public string? UpiType { get; set; } = string.Empty;
    //    public double PaidAmount { get; set; }
    //    public double BalanceAmount { get; set; }
    //    public string? Remarks { get; set; } = string.Empty;
    //    public string? CreatedDate { get; set; } = string.Empty;
    //    public int CreatedBy { get; set; }
    //    public bool IsLocked { get; set; }
    //    public string? EndUserMobile { get; set; } = string.Empty;
    //    public int ServiceRequestId { get; set; }
    //    public double RewardPointsEarned { get; set; }
    //    public double RewardPointsRedeemed { get; set; }
    //    public double RewardDiscountAmount { get; set; }
    //    public PartyVM? PartyModel { get; set; }
    //    public List<SalesItemVM> SalesItems { get; set; } = [];
    //    public InvoiceSummary? Summary { get; set; }
    //    public JobCardVM? JobCard { get; set; }

    //    public bool IsCashSales { get; set; } = true;
    //    public double TotalSavings { get; set; }
    //    public double RoundOff { get; set; }

    //    public string InvoiceNumber
    //    {
    //        get => InvoiceNo;
    //        set => InvoiceNo = value ?? string.Empty;
    //    }
    //    public string SalesDate
    //    {
    //        get => InvoiceDate;
    //        set => InvoiceDate = value ?? string.Empty;
    //    }
    //    public PartyVM? Party
    //    {
    //        get => PartyModel;
    //        set => PartyModel = value;
    //    }
    //    public int? PartyId
    //    {
    //        get => PartyModel?.PartyId;
    //        set
    //        {
    //            if (value.HasValue && value.Value > 0)
    //            {
    //                PartyModel ??= new PartyVM();
    //                PartyModel.PartyId = value.Value;
    //            }
    //        }
    //    }

    //    private double? _totalTaxable;
    //    public double TotalTaxableAmount
    //    {
    //        get => _totalTaxable ?? Summary?.TotalTaxableAmount ?? SalesItems.Sum(i => i.TaxableAmount);
    //        set
    //        {
    //            _totalTaxable = value;
    //            Summary ??= new InvoiceSummary();
    //            Summary.TotalTaxableAmount = value;
    //        }
    //    }

    //    private double? _totalCgst;
    //    public double TotalCgst
    //    {
    //        get => _totalCgst ?? SalesItems.Sum(i => i.CgstRs);
    //        set => _totalCgst = value;
    //    }

    //    private double? _totalSgst;
    //    public double TotalSgst
    //    {
    //        get => _totalSgst ?? SalesItems.Sum(i => i.SgstRs);
    //        set => _totalSgst = value;
    //    }

    //    private double? _totalIgst;
    //    public double TotalIgst
    //    {
    //        get => _totalIgst ?? SalesItems.Sum(i => i.IgstRs);
    //        set => _totalIgst = value;
    //    }

    //    private double? _totalDiscount;
    //    public double TotalDiscount
    //    {
    //        get => _totalDiscount ?? Summary?.TotalDiscount ?? SalesItems.Sum(i => i.DiscountInRs);
    //        set
    //        {
    //            _totalDiscount = value;
    //            Summary ??= new InvoiceSummary();
    //            Summary.TotalDiscount = value;
    //        }
    //    }

    //    private double? _totalInvoiceAmount;
    //    public double TotalInvoiceAmount
    //    {
    //        get => _totalInvoiceAmount ?? Summary?.TotalInvoiceAmount ?? SalesItems.Sum(i => i.TotalAmount);
    //        set
    //        {
    //            _totalInvoiceAmount = value;
    //            Summary ??= new InvoiceSummary();
    //            Summary.TotalInvoiceAmount = value;
    //        }
    //    }

    //    public double ReceivedAmount
    //    {
    //        get => PaidAmount;
    //        set => PaidAmount = value;
    //    }
    //    public double PointsEarned
    //    {
    //        get => RewardPointsEarned;
    //        set => RewardPointsEarned = value;
    //    }
    //    public double PointsRedeemed
    //    {
    //        get => RewardPointsRedeemed;
    //        set => RewardPointsRedeemed = value;
    //    }
    //    public double PointsDiscount
    //    {
    //        get => RewardDiscountAmount;
    //        set => RewardDiscountAmount = value;
    //    }
    //}

    public class GSTData
    {
        public float GstPer { get; set; }
        public double Quantity { get; set; }
        public double TaxableAmount { get; set; }
        public float IgstPer { get; set; }
        public float CgstPer { get; set; }
        public float SgstPer { get; set; }
        public double IgstAmount { get; set; }
        public double CgstAmount { get; set; }
        public double SgstAmount { get; set; }
        public double GstAmount { get; set; }
    }

    public class PrintSalesItem
    {
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string Measure { get; set; } = string.Empty;
        public string HsnCode { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public double Mrp { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double DiscountInRs { get; set; }
        public double TaxableAmount { get; set; }
        public float CgstPer { get; set; }
        public float SgstPer { get; set; }
        public float IgstPer { get; set; }
        public float GstPer { get; set; }
        public double CgstRs { get; set; }
        public double SgstRs { get; set; }
        public double IgstRs { get; set; }
        public double GstAmount { get; set; }
        public double TotalAmount { get; set; }
        public double SavingAmount { get; set; }

        public double SalesPrice => Rate;
        public double DiscountRs => DiscountInRs;
        public double CgstAmount => CgstRs;
        public double SgstAmount => SgstRs;
        public double IgstAmount => IgstRs;
    }

    public class PrintSalesInvoice
    {
        public int SalesId { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string SalesType { get; set; } = string.Empty;
        public double PaidAmount { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string PaymentMode { get; set; } = string.Empty;
        public string UpiType { get; set; } = string.Empty;
        public string PartyName { get; set; } = string.Empty;
        public string PartyMobile { get; set; } = string.Empty;
        public string PartyAddress { get; set; } = string.Empty;
        public string Gstin { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string PrintedTime { get; set; } = string.Empty;
        public double RewardPointsEarned { get; set; }
        public double RewardPointsRedeemed { get; set; }
        public double RewardDiscountAmount { get; set; }
        public double CustomerAvailablePoints { get; set; }
        public List<GSTData> GstSummary { get; set; } = [];
        public List<PrintSalesItem> SalesItems { get; set; } = [];

        public string SalesDate => InvoiceDate;
        public string SalesTime => PrintedTime;
        public string Mobile => PartyMobile;
        public string Address => PartyAddress;
        public double TotalTaxableAmount => SalesItems.Sum(i => i.TaxableAmount);
        public double TotalCgst => SalesItems.Sum(i => i.CgstRs);
        public double TotalSgst => SalesItems.Sum(i => i.SgstRs);
        public double TotalIgst => SalesItems.Sum(i => i.IgstRs);
        public double TotalDiscount => SalesItems.Sum(i => i.DiscountInRs);
        public double TotalSavings => SalesItems.Sum(i => i.SavingAmount);
        public double RoundOff => 0;
        public double TotalInvoiceAmount => Math.Max(0, SalesItems.Sum(i => i.TotalAmount) - RewardDiscountAmount);
        public double ReceivedAmount => PaidAmount;
        public double BalanceAmount => Math.Max(0, TotalInvoiceAmount - PaidAmount);
        public double PointsEarned => RewardPointsEarned;
        public double PointsRedeemed => RewardPointsRedeemed;
        public double PointsDiscount => RewardDiscountAmount;
        public double AvailablePoints => CustomerAvailablePoints;
        public List<GSTData> GstSummaries => GstSummary;
    }

    public class TodaySalesSummary
    {
        public string InvoiceDate { get; set; } = string.Empty;
        public int TotalInvoiceCount { get; set; }
        public double TotalSalesAmount { get; set; }
        public double TotalDiscountAmount { get; set; }
        public double TotalGstAmount { get; set; }
        public double AmountCollected { get; set; }
        public double CashAmount { get; set; }
        public double CardAmount { get; set; }
        public double UpiAmount { get; set; }
        public double TotalCreditSalesAmount { get; set; }
        public double TodayPendingCreditAmount { get; set; }
        public double OverallPendingCreditAmount { get; set; }
    }

    public class DashboardSalesSummaryResponse
    {
        public TodaySalesSummary Today { get; set; } = new();
        public TodaySalesSummary Weekly { get; set; } = new();
        public TodaySalesSummary Monthly { get; set; } = new();
    }

    //public class PurchaseItemVM
    //{
    //    public int PurchaseItemId { get; set; }
    //    public int PurchaseId { get; set; }
    //    public float Quantity { get; set; }
    //    public float FreeQuantity { get; set; }
    //    public float Mrp { get; set; }
    //    public float Rate { get; set; }
    //    public float SalesPrice { get; set; }
    //    public double Amount { get; set; }
    //    public float DiscountPer { get; set; }
    //    public double DiscountInRs { get; set; }
    //    public int GstId { get; set; }
    //    public float CgstPer { get; set; }
    //    public float SgstPer { get; set; }
    //    public float IgstPer { get; set; }
    //    public float GstPer { get; set; }
    //    public double CgstRs { get; set; }
    //    public double SgstRs { get; set; }
    //    public double IgstRs { get; set; }
    //    public double GstAmount { get; set; }
    //    public double TaxableAmount { get; set; }
    //    public double TotalAmount { get; set; }
    //    public ItemVM ItemModel { get; set; } = new();
    //    public string? CreatedDate { get; set; }
    //    public string? DeletedDate { get; set; }
    //    public string? DeletedBy { get; set; }
    //    public string? DeletedRemarks { get; set; }
    //    public string? InvoiceNumber { get; set; }

    //    public ItemVM Item
    //    {
    //        get => ItemModel;
    //        set => ItemModel = value ?? new ItemVM();
    //    }
    //    public int ItemId
    //    {
    //        get => ItemModel.ItemId;
    //        set => ItemModel.ItemId = value;
    //    }
    //    public float PurchasePrice
    //    {
    //        get => Rate;
    //        set
    //        {
    //            Rate = value;
    //            if (Amount == 0 && Quantity > 0)
    //                Amount = Math.Round(Quantity * value, 2);
    //        }
    //    }
    //    public double DiscountRs
    //    {
    //        get => DiscountInRs;
    //        set => DiscountInRs = value;
    //    }
    //    public double CgstAmount
    //    {
    //        get => CgstRs;
    //        set
    //        {
    //            CgstRs = value;
    //            GstAmount = CgstRs + SgstRs + IgstRs;
    //        }
    //    }
    //    public double SgstAmount
    //    {
    //        get => SgstRs;
    //        set
    //        {
    //            SgstRs = value;
    //            GstAmount = CgstRs + SgstRs + IgstRs;
    //        }
    //    }
    //    public double IgstAmount
    //    {
    //        get => IgstRs;
    //        set
    //        {
    //            IgstRs = value;
    //            GstAmount = CgstRs + SgstRs + IgstRs;
    //        }
    //    }
    //    public string? PurchaseDate
    //    {
    //        get => CreatedDate;
    //        set => CreatedDate = value;
    //    }
    //    public string? Remarks
    //    {
    //        get => DeletedRemarks;
    //        set => DeletedRemarks = value;
    //    }
    //}

    //public class PurchaseVM
    //{
    //    public int PurchaseId { get; set; }
    //    public string InvoiceNo { get; set; } = string.Empty;
    //    public string InvoiceDate { get; set; } = string.Empty;
    //    public string PurchaseType { get; set; } = "Cash";
    //    public string PaymentMode { get; set; } = "Cash";
    //    public string? UpiType { get; set; } = string.Empty;
    //    public string? Remarks { get; set; } = string.Empty;
    //    public bool IsLocked { get; set; }
    //    public int? PurchaseOrderId { get; set; }
    //    public List<PurchaseItemVM> PurchaseItems { get; set; } = [];
    //    public InvoiceSummary? Summary { get; set; }
    //    public PartyVM PartyModel { get; set; } = new();

    //    public bool IsCashPurchase { get; set; } = true;
    //    public double RoundOff { get; set; }
    //    public double PaidAmount { get; set; }
    //    public double BalanceAmount { get; set; }

    //    public string InvoiceNumber
    //    {
    //        get => InvoiceNo;
    //        set => InvoiceNo = value ?? string.Empty;
    //    }
    //    public string PurchaseDate
    //    {
    //        get => InvoiceDate;
    //        set => InvoiceDate = value ?? string.Empty;
    //    }
    //    public PartyVM Party
    //    {
    //        get => PartyModel;
    //        set => PartyModel = value ?? new PartyVM();
    //    }
    //    public int PartyId
    //    {
    //        get => PartyModel.PartyId;
    //        set => PartyModel.PartyId = value;
    //    }

    //    private double? _totalTaxable;
    //    public double TotalTaxableAmount
    //    {
    //        get => _totalTaxable ?? Summary?.TotalTaxableAmount ?? PurchaseItems.Sum(i => i.TaxableAmount);
    //        set
    //        {
    //            _totalTaxable = value;
    //            Summary ??= new InvoiceSummary();
    //            Summary.TotalTaxableAmount = value;
    //        }
    //    }

    //    private double? _totalCgst;
    //    public double TotalCgst
    //    {
    //        get => _totalCgst ?? PurchaseItems.Sum(i => i.CgstRs);
    //        set => _totalCgst = value;
    //    }

    //    private double? _totalSgst;
    //    public double TotalSgst
    //    {
    //        get => _totalSgst ?? PurchaseItems.Sum(i => i.SgstRs);
    //        set => _totalSgst = value;
    //    }

    //    private double? _totalIgst;
    //    public double TotalIgst
    //    {
    //        get => _totalIgst ?? PurchaseItems.Sum(i => i.IgstRs);
    //        set => _totalIgst = value;
    //    }

    //    private double? _totalDiscount;
    //    public double TotalDiscount
    //    {
    //        get => _totalDiscount ?? Summary?.TotalDiscount ?? PurchaseItems.Sum(i => i.DiscountInRs);
    //        set
    //        {
    //            _totalDiscount = value;
    //            Summary ??= new InvoiceSummary();
    //            Summary.TotalDiscount = value;
    //        }
    //    }

    //    private double? _totalInvoiceAmount;
    //    public double TotalInvoiceAmount
    //    {
    //        get => _totalInvoiceAmount ?? Summary?.TotalInvoiceAmount ?? PurchaseItems.Sum(i => i.TotalAmount);
    //        set
    //        {
    //            _totalInvoiceAmount = value;
    //            Summary ??= new InvoiceSummary();
    //            Summary.TotalInvoiceAmount = value;
    //        }
    //    }
    //}

    public class PurchaseOrderItemVM
    {
        public int PurchaseOrderItemId { get; set; }
        public int PurchaseOrderId { get; set; }
        public float Quantity { get; set; }
        public float Rate { get; set; }
        public double Amount { get; set; }
        public ItemVM ItemModel { get; set; } = new();

        public ItemVM Item
        {
            get => ItemModel;
            set => ItemModel = value ?? new ItemVM();
        }
        public int ItemId
        {
            get => ItemModel.ItemId;
            set => ItemModel.ItemId = value;
        }
    }

    //public class PurchaseOrderVM
    //{
    //    public int PurchaseOrderId { get; set; }
    //    public string OrderDate { get; set; } = string.Empty;
    //    public string? PurchaseInvoiceNo { get; set; }
    //    public string? PurchaseInvoiceDate { get; set; }
    //    public string? Remarks { get; set; } = string.Empty;
    //    public double OrderAmount { get; set; }
    //    public PartyVM PartyModel { get; set; } = new();
    //    public List<PurchaseOrderItemVM> OrderItems { get; set; } = [];

    //    public PartyVM Party
    //    {
    //        get => PartyModel;
    //        set => PartyModel = value ?? new PartyVM();
    //    }
    //    public int PartyId
    //    {
    //        get => PartyModel.PartyId;
    //        set => PartyModel.PartyId = value;
    //    }
    //    public bool IsActive { get; set; } = true;
    //    public List<PurchaseOrderItemVM> PurchaseOrderItems
    //    {
    //        get => OrderItems;
    //        set => OrderItems = value ?? [];
    //    }
    //}

    //public class JobCardItemVM
    //{
    //    public int ServiceRequestComplaintId { get; set; }
    //    public int ServiceRequestId { get; set; }
    //    public double ServiceCharge { get; set; }
    //    public ServiceTypeVM ServiceTypeModel { get; set; } = new();
    //    public string? CustomerRemarks { get; set; } = string.Empty;
    //    public string? TechnicianRemarks { get; set; } = string.Empty;
    //    public double Quantity { get; set; } = 1;
    //    public double TaxableAmount { get; set; }
    //    public int GstId { get; set; }
    //    public float CgstPer { get; set; }
    //    public float SgstPer { get; set; }
    //    public float IgstPer { get; set; }
    //    public double CgstAmount { get; set; }
    //    public double SgstAmount { get; set; }
    //    public double IgstAmount { get; set; }
    //    public double DiscountRs { get; set; }
    //    public double TotalAmount { get; set; }

    //    public int ComplaintId
    //    {
    //        get => ServiceRequestComplaintId;
    //        set => ServiceRequestComplaintId = value;
    //    }
    //    public int ServiceTypeId
    //    {
    //        get => ServiceTypeModel.ServiceTypeId;
    //        set => ServiceTypeModel.ServiceTypeId = value;
    //    }
    //    public string ServiceTypeName
    //    {
    //        get => ServiceTypeModel.ServiceTypeName;
    //        set => ServiceTypeModel.ServiceTypeName = value ?? string.Empty;
    //    }
    //    public double Price
    //    {
    //        get => ServiceCharge;
    //        set => ServiceCharge = value;
    //    }
    //}

    
    

    //public class TransactionVM
    //{
    //    public int TransactionId { get; set; }
    //    public string TransactionDate { get; set; } = string.Empty;
    //    public string? TransactionRefNo { get; set; }
    //    public string PaymentMode { get; set; } = "Cash";
    //    public string? UpiType { get; set; } = string.Empty;
    //    public double ReceiptAmount { get; set; }
    //    public double PaymentAmount { get; set; }
    //    public double Balance { get; set; }
    //    public string? Remarks { get; set; } = string.Empty;
    //    public string TransactionType { get; set; } = string.Empty;
    //    public string? CreatedDate { get; set; }
    //    public PartyVM? PartyModel { get; set; } = new();

    //    public bool IsPayment { get; set; }
    //    public double InvoiceAmount { get; set; }
    //    public double Discount { get; set; }

    //    public PartyVM? Party
    //    {
    //        get => PartyModel;
    //        set => PartyModel = value;
    //    }
    //    public int PartyId
    //    {
    //        get => PartyModel?.PartyId ?? 0;
    //        set
    //        {
    //            PartyModel ??= new PartyVM();
    //            PartyModel.PartyId = value;
    //        }
    //    }
    //    public double ReceivedAmount
    //    {
    //        get => ReceiptAmount;
    //        set => ReceiptAmount = value;
    //    }
    //    public double PaidAmount
    //    {
    //        get => PaymentAmount;
    //        set => PaymentAmount = value;
    //    }
    //    public double BalanceAmount
    //    {
    //        get => Balance;
    //        set => Balance = value;
    //    }
    //}

    public class BalanceSheet
    {
        public double TotalReceiptAmount { get; set; }
        public double TotalPaymentAmount { get; set; }
        public double Balance { get; set; }
        public PartyVM PartyModel { get; set; } = new();

        public int PartyId => PartyModel.PartyId;
        public string PartyName => PartyModel.PartyName;
        public string? Mobile => PartyModel.PartyMobile;
        public string PartyType => PartyModel.IsVendor ? "Vendor" : "Customer";
        public double OpeningBalance => PartyModel.OpeningBalance;
        public double SalesAmount => TotalPaymentAmount;
        public double PurchaseAmount => TotalPaymentAmount;
        public double ReceivedAmount => TotalReceiptAmount;
        public double PaidAmount => TotalReceiptAmount;
        public double SalesDiscount => 0;
        public double PurchaseDiscount => 0;
        public double ClosingBalance => Balance;
    }

    //public class UnlockRequestVM
    //{
    //    public int UnlockRequestId { get; set; }
    //    public string Remarks { get; set; } = string.Empty;
    //    public string? RequestedBy { get; set; }
    //    public string? RequestedDate { get; set; }
    //    public string? RequestStatusDesc { get; set; }
    //    public double TotalAmount { get; set; }
    //    public SalesVM? SalesModel { get; set; }
    //    public PurchaseVM? PurchaseModel { get; set; }

    //    public int? SalesId
    //    {
    //        get => SalesModel?.SalesId;
    //        set
    //        {
    //            if (value.HasValue && value.Value > 0)
    //            {
    //                SalesModel ??= new SalesVM();
    //                SalesModel.SalesId = value.Value;
    //            }
    //        }
    //    }
    //    public int? PurchaseId
    //    {
    //        get => PurchaseModel?.PurchaseId;
    //        set
    //        {
    //            if (value.HasValue && value.Value > 0)
    //            {
    //                PurchaseModel ??= new PurchaseVM();
    //                PurchaseModel.PurchaseId = value.Value;
    //            }
    //        }
    //    }
    //    public string? InvoiceNumber => SalesModel?.InvoiceNo ?? PurchaseModel?.InvoiceNo;
    //}

    public class GSTReturnDetailed
    {
        public int SalesId { get; set; }
        public string? InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string? PartyName { get; set; } = string.Empty;
        public string? PartyGstin { get; set; } = string.Empty;
        public List<GSTData> Data { get; set; } = [];
        public bool IsHeader { get; set; }

        public string Type { get; set; } = "Sales";
        public string TransactionDate => InvoiceDate;
        public string? InvoiceNumber => InvoiceNo;
        public string? Gstin => PartyGstin;
        public double TaxableAmount => Data.Sum(d => d.TaxableAmount);
        public float GstPer => Data.FirstOrDefault()?.GstPer ?? 0;
        public double CgstAmount => Data.Sum(d => d.CgstAmount);
        public double SgstAmount => Data.Sum(d => d.SgstAmount);
        public double IgstAmount => Data.Sum(d => d.IgstAmount);
        public double InvoiceTotal => Data.Sum(d => d.TaxableAmount + d.GstAmount);
    }

    public class GSTHSNSummary
    {
        public string HsnCode { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public List<GSTData> Data { get; set; } = [];

        public string ItemName => $"HSN/SAC {HsnCode}";
        public string Measure => "NOS";
        public double TotalQuantity => Quantity;
        public double TotalTaxableAmount => Data.Sum(d => d.TaxableAmount);
        public float GstPer => Data.FirstOrDefault()?.GstPer ?? 0;
        public double TotalCgst => Data.Sum(d => d.CgstAmount);
        public double TotalSgst => Data.Sum(d => d.SgstAmount);
        public double TotalIgst => Data.Sum(d => d.IgstAmount);
        public double TotalValue => Data.Sum(d => d.TaxableAmount + d.GstAmount);
    }

    public class SalesSummary
    {
        public string Month { get; set; } = string.Empty;
        public string SalesType { get; set; } = string.Empty;
        public string PaymentMode { get; set; } = string.Empty;
        public double Cash { get; set; }
        public double Card { get; set; }
        public double Upi { get; set; }
        public double Credit { get; set; }
        public double TotalAmount { get; set; }

        public string InvoiceNumber => Month;
        public string SalesDate => Month;
        public string PartyName => SalesType;
        public string Gstin => string.Empty;
        public double TotalTaxableAmount => TotalAmount;
        public double TotalCgst => 0;
        public double TotalSgst => 0;
        public double TotalIgst => 0;
        public double TotalDiscount => 0;
        public double TotalInvoiceAmount => TotalAmount;
        public double BalanceAmount => Credit;
    }

    public class InventoryValuation
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public double SalesPrice { get; set; }
        public double PurchasePrice { get; set; }
        public string Measure { get; set; } = string.Empty;
        public double ClosingStock { get; set; }
        public double PurchaseValue { get; set; }
        public double SalesValue { get; set; }

        public double Stock => ClosingStock;
    }

    public class ProductMovementModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Measure { get; set; } = string.Empty;
        public double ClosingStock { get; set; }
        public int SalesFrequency { get; set; }
        public double TotalQuantitySold { get; set; }
        public double TotalRevenue { get; set; }

        public double TotalSoldQty => TotalQuantitySold;
        public double TotalSalesAmount => TotalRevenue;
        public double CurrentStock => ClosingStock;
        public double StockTurnoverRatio => ClosingStock > 0 ? Math.Round(TotalQuantitySold / ClosingStock, 2) : TotalQuantitySold;
        public string MovementCategory => SalesFrequency >= 5 ? "Fast Moving" : (SalesFrequency > 0 ? "Normal" : "Slow Moving");
    }

    public class ChartData
    {
        public float YAxis { get; set; }
        public string XLabel { get; set; } = string.Empty;
    }

    //public class RewardRedemptionDetailVM
    //{
    //    public int RewardTransId { get; set; }
    //    public int PartyId { get; set; }
    //    public string PartyName { get; set; } = string.Empty;
    //    public string PartyMobile { get; set; } = string.Empty;
    //    public int SalesId { get; set; }
    //    public string InvoiceNo { get; set; } = string.Empty;
    //    public string TransactionDate { get; set; } = string.Empty;
    //    public double PreDiscountAmount { get; set; }
    //    public double PointsRedeemed { get; set; }
    //    public double MonetaryValue { get; set; }
    //    public double RemainingPointsBalance { get; set; }
    //    public string Status { get; set; } = "SUCCESS";
    //    public double PointsEarned { get; set; }

    //    public string SalesDate => TransactionDate;
    //    public string InvoiceNumber => InvoiceNo;
    //    public string CustomerName => PartyName;
    //    public string CustomerPhone => PartyMobile;
    //    public double InvoiceAmount => PreDiscountAmount;
    //    public double PointsDiscount => MonetaryValue;
    //}


    public class UserParam
    {
        public int UserRowId { get; set; }
        public string SecurityKey { get; set; } = string.Empty;
        public string ClientUniqueId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string? remarks { get; set; } = string.Empty;
        public SettingVM? SettingModel { get; set; }
        public CategoryVM? CategoryModel { get; set; }
        public GstVM? GstModel { get; set; }
        public ItemVM? ItemModel { get; set; }
        public ServiceTypeVM? ServiceTypeModel { get; set; }
        public PartyVM? PartyModel { get; set; }
        public PurchaseVM? PurchaseModel { get; set; }
        public SalesVM? SalesModel { get; set; }
        public TransactionVM? TransactionModel { get; set; }
        public UserVM? UserModel { get; set; }
        public PurchaseOrderVM? PurchaseOrderModel { get; set; }
        public JobCardVM? JobCardModel { get; set; }
        public CustomReceiptLineVM? CustomReceiptLineModel { get; set; }
    }

    public class ReportParam
    {
        public int UserRowId { get; set; }
        public string SecurityKey { get; set; } = string.Empty;
        public string? FromDate { get; set; } = string.Empty;
        public string? ToDate { get; set; } = string.Empty;
        public string? TransactionType { get; set; } = string.Empty;
        public string? PaymentMode { get; set; } = string.Empty;
        public string? UpiType { get; set; } = string.Empty;
        public string? Id { get; set; } = string.Empty;

        public string? SalesType
        {
            get => TransactionType;
            set => TransactionType = value;
        }
        public string? PurchaseType
        {
            get => TransactionType;
            set => TransactionType = value;
        }
    }

    public class LoginViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ClientUniqueId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = "PayBill POS & ERP";
        public string BusinessType { get; set; } = "Complete Business Management Suite";
        public bool IsConfigured { get; set; } = true;
        public string? ReturnUrl { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class SetupAccountViewModel
    {
        public string ClientName { get; set; } = string.Empty;
        public string BusinessType { get; set; } = "Supermarket / Retail";
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AdminUserId { get; set; } = "admin";
        public string AdminFirstName { get; set; } = string.Empty;
        public string AdminLastName { get; set; } = string.Empty;
        public string AdminPassword { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
    }

    public class DashboardViewModel
    {
        public DashboardSalesSummaryResponse SalesSummary { get; set; } = new();
        public double TotalCustomerReceivables { get; set; }
        public double TotalVendorPayables { get; set; }
        public double TotalInventoryPurchaseValue { get; set; }
        public double TotalInventorySalesValue { get; set; }
        public int TotalActiveItemsCount { get; set; }
        public double TodayPaymentsOut { get; set; }
        public double TodayReceiptsIn { get; set; }
        public double MonthlyPurchaseTotal { get; set; }
        public int MonthlyPurchaseCount { get; set; }
        public List<ItemVM> LowStockItems { get; set; } = [];
        public List<SalesVM> RecentSales { get; set; } = [];
        public List<PurchaseVM> RecentPurchases { get; set; } = [];
        public List<JobCardVM> ActiveJobCards { get; set; } = [];
        public List<UnlockRequestVM> PendingUnlockRequests { get; set; } = [];
        public List<ChartData> DayWiseSalesChart { get; set; } = [];
        public List<ChartData> MonthWiseSalesChart { get; set; } = [];
        public List<ChartData> ItemWiseSalesChart { get; set; } = [];
        public List<ChartData> PaymentModeChart { get; set; } = [];
    }

    public class SalesInvoicePageViewModel
    {
        public SalesVM Invoice { get; set; } = new();
        public SettingVM Settings { get; set; } = new();
        public List<PartyVM> Customers { get; set; } = [];
        public List<CategoryVM> Categories { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public List<ServiceTypeVM> ServiceTypes { get; set; } = [];
        public List<ItemVM> InitialItems { get; set; } = [];
        public string CompanyGstin { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string? PendingUnlockMessage { get; set; }
    }

    public class SalesPrintViewModel
    {
        public PrintSalesInvoice Invoice { get; set; } = new();
        public SalesVM? RawInvoice { get; set; }
        public PrintHeader Header { get; set; } = new();
        public SettingVM Settings { get; set; } = new();
        public List<CustomReceiptLineVM> CustomLines { get; set; } = [];
        public string Format { get; set; } = "A4";
        public string AmountInWords { get; set; } = string.Empty;
        public string WhatsAppMessage { get; set; } = string.Empty;
    }

    public class PurchaseInvoicePageViewModel
    {
        public PurchaseVM Purchase { get; set; } = new();
        public SettingVM Settings { get; set; } = new();
        public List<PartyVM> Vendors { get; set; } = [];
        public List<PurchaseOrderVM> ActivePurchaseOrders { get; set; } = [];
        public List<CategoryVM> Categories { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public List<ItemVM> InitialItems { get; set; } = [];
        public string CompanyGstin { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string? PendingUnlockMessage { get; set; }
    }

    public class PurchaseOrderPageViewModel
    {
        public PurchaseOrderVM Order { get; set; } = new();
        public List<PartyVM> Vendors { get; set; } = [];
        public List<ItemVM> InitialItems { get; set; } = [];
        public PrintHeader Header { get; set; } = new();
    }

    public class JobCardPageViewModel
    {
        public JobCardVM JobCard { get; set; } = new();
        public string NextJobCardNumber { get; set; } = "1";
        public List<PartyVM> Customers { get; set; } = [];
        public List<ServiceTypeVM> ServiceTypes { get; set; } = [];
        public List<ItemVM> Items { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public PrintHeader Header { get; set; } = new();
        public string CompanyGstin { get; set; } = string.Empty;
    }

    public class InventoryPageViewModel
    {
        public List<ItemVM> Items { get; set; } = [];
        public List<CategoryVM> Categories { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public List<ServiceTypeVM> ServiceTypes { get; set; } = [];
        public List<ItemVM> MinStockItems { get; set; } = [];
        public int SelectedCategoryId { get; set; }
        public string? SearchFilter { get; set; }
        public string ActiveTab { get; set; } = "items";
    }

    public class PartyPageViewModel
    {
        public List<PartyVM> Parties { get; set; } = [];
        public Dictionary<int, BalanceSheet> BalanceMap { get; set; } = new();
        public bool IsVendor { get; set; }
    }

    public class TransactionPageViewModel
    {
        public List<TransactionVM> Transactions { get; set; } = [];
        public List<PartyVM> Parties { get; set; } = [];
        public bool IsPayment { get; set; }
        public int FilterMode { get; set; }
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
        public PrintHeader Header { get; set; } = new();
    }

    public class RewardsDashboardViewModel
    {
        public SettingVM Settings { get; set; } = new();
        public RewardOverallSummaryVM OverallSummary { get; set; } = new();
        public List<RewardCustomerSummaryVM> CustomerSummaries { get; set; } = [];
        public List<RewardTransactionVM> Transactions { get; set; } = [];
        public List<RewardRedemptionDetailVM> Redemptions { get; set; } = [];
        public List<PartyVM> Customers { get; set; } = [];
        public string ActiveTab { get; set; } = "summary";
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? SearchQuery { get; set; }
        public int? SelectedPartyId { get; set; }
    }

    public class SettingsPageViewModel
    {
        public SettingVM Settings { get; set; } = new();
        public ClientVM ClientProfile { get; set; } = new();
        public List<UserVM> Users { get; set; } = [];
        public List<MessageTemplateVM> MessageTemplates { get; set; } = [];
        public List<CustomReceiptLineVM> CustomReceiptLines { get; set; } = [];
        public List<UnlockRequestVM> UnlockRequests { get; set; } = [];
        public string ActiveTab { get; set; } = "company";
        public bool IsAdmin { get; set; }
    }
}

