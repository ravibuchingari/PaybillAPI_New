using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Models
{
    public class DashboardPrefVM
    {
        public bool IsAutoEmail { get; set; } = false;
        public bool IsBackupOnExit { get; set; } = true;
        public bool IsBackupOnLogin { get; set; } = false;
        public bool IsDiscountEnabled { get; set; } = false;
        public bool AddItemOnSelected { get; set; } = false;
        public bool IsCreateContactOnParty { get; set; } = false;
        public bool IsCompressBackup { get; set; } = true;
        public bool IsShadowMenuButton { get; set; } = true;
        public bool IsSettingsUpdated { get; set; } = false;
        public bool IsAlertOnMinimumStock { get; set; } = true;
        public bool IsAlertOnNegativeBalance { get; set; } = true;
        public string ServiceGSTCode { get; set; } = "";
        public bool ItemCodeAllowNumberOnly { get; set; } = true;
        public bool IsBiometricAuthEnabled { get; set; } = false;
        public bool IsSoundEnabled { get; set; } = true;
        public bool IsSendSmsonInvoice { get; set; } = false;
        public bool IsSendWhatsAppMessageOnInvoice { get; set; } = false;
        public bool IsShareInvoiceOnInvoice { get; set; } = false;
        public int? SalesMessageId { get; set; } = null;
        public int? ServiceMessageId { get; set; } = null;
        public int? BalanceMessageId { get; set; } = null;
        public int? FestivalMessageId { get; set; } = null;
        public string UPIId { get; set; } = "";
        public string UPIName { get; set; } = "";
        public string UPIMerchantCode { get; set; } = "";
        public bool IsServiceRequestEnabled { get; set; } = false;
        public bool IsItemSearchImageVisible { get; set; } = false;
        public bool IsViewAllItemsOnSearch { get; set; } = false;
        public string EmailBodyForSalesInvoice { get; set; } = "";
        public PrintHeaderVM HeaderModel { get; set; } = new PrintHeaderVM();
    }
}
