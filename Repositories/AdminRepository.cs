using Microsoft.EntityFrameworkCore;
using Paybill.Data;
using Paybill.DTO;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;

namespace Paybill.Repositories
{
    public class AdminRepository(AppDBContext dbContext) : RootRepository(dbContext), IAdminRepository
    {
        private static ResponseMessage SendResponseMessage(string message, bool isSuccess = true, int id = 0) =>
            new(isSuccess: isSuccess, message: message, data: id > 0 ? id.ToString() : null);

        public async Task<ResponseMessage> UpdateSettings(int userRowId, SettingVM settingVM)
        {
            Setting? setting = await dbContext.Settings.FirstOrDefaultAsync();
            bool isUpdate = setting != null;
            setting ??= new Setting();
            if (!isUpdate)
            {
                setting.RowId = 1;
                setting.CreatedBy = userRowId;
            }
            setting.UpdatedBy = userRowId;
            setting.UpdatedDate = DateTime.Now;
            setting.CompanyName = settingVM.HeaderModel.CompanyName ?? string.Empty;
            setting.SmtpHost = settingVM.SmtpHost;
            setting.SmtpPort = settingVM.SmtpPort;
            setting.EmailFrom = settingVM.EmailFrom;
            setting.EmailTo = settingVM.EmailTo;
            setting.EmailPassword = settingVM.EmailPassword;
            setting.IsAutoEmail = (sbyte)(settingVM.IsAutoEmail ? 1 : 0);
            setting.IsBackupOnExit = (sbyte)(settingVM.IsBackupOnExit ? 1 : 0);
            setting.IsDiscountEnabled = (sbyte)(settingVM.IsDiscountEnabled ? 1 : 0);
            setting.InvoiceTitle = settingVM.HeaderModel.InvoiceTitle;
            setting.Header1 = settingVM.HeaderModel.Header1;
            setting.Header2 = settingVM.HeaderModel.Header2;
            setting.Header3 = settingVM.HeaderModel.Header3;
            setting.Gstin = settingVM.HeaderModel.Gstin;
            setting.GstslabRequired = (sbyte)(settingVM.HeaderModel.GstSlabRequired ? 1 : 0);
            setting.ItemWiseGstslabRequired = (sbyte)(settingVM.HeaderModel.ItemWiseGstSlabRequired ? 1 : 0);
            setting.AddItemOnSelected = (sbyte)(settingVM.AddItemOnSelected ? 1 : 0);
            setting.InvoicePrefix = settingVM.InvoicePrefix;
            setting.InvoiceLength = settingVM.InvoiceLength > 0 ? settingVM.InvoiceLength : (sbyte)6;
            setting.IsCreateContactOnParty = (sbyte)(settingVM.IsCreateContactOnParty ? 1 : 0);
            setting.IsCompressBackup = (sbyte)(settingVM.IsCompressBackup ? 1 : 0);
            setting.IsShadowMenuButton = (sbyte)(settingVM.IsShadowMenuButton ? 1 : 0);
            setting.IsBiometricAuthEnabled = (sbyte)(settingVM.IsBiometricAuthEnabled ? 1 : 0);
            setting.IsAlertOnMinimumStock = (sbyte)(settingVM.IsAlertOnMinimumStock ? 1 : 0);
            setting.ItemCodeAllowNumberOnly = (sbyte)(settingVM.ItemCodeAllowNumberOnly ? 1 : 0);
            setting.IsPaymentDetailsRequired = (sbyte)(settingVM.HeaderModel.IsPaymentDetailsRequired ? 1 : 0);
            setting.IsSavingDetailsRequired = (sbyte)(settingVM.HeaderModel.IsSavingDetailsRequired ? 1 : 0);
            setting.IsGstSummaryRequired = (sbyte)(settingVM.HeaderModel.IsGstSummaryRequired ? 1 : 0);
            setting.IsSoundEnabled = (sbyte)(settingVM.IsSoundEnabled ? 1 : 0);
            setting.IsSendSmsonInvoice = (sbyte)(settingVM.IsSendSmsonInvoice ? 1 : 0);
            setting.IsSendWhatsAppMessageOnInvoice = (sbyte)(settingVM.IsSendWhatsAppMessageOnInvoice ? 1 : 0);
            setting.IsShareInvoiceOnInvoice = (sbyte)(settingVM.IsShareInvoiceOnInvoice ? 1 : 0);
            setting.IsShareInvoice3C = (sbyte)(settingVM.IsShareInvoice3C ? 1 : 0);
            setting.SalesMessageId = settingVM.SalesMessageId == 0 ? null : settingVM.SalesMessageId;
            setting.ServiceMessageId = settingVM.ServiceMessageId == 0 ? null : settingVM.ServiceMessageId;
            setting.BalanceMessageId = settingVM.BalanceMessageId == 0 ? null : settingVM.BalanceMessageId;
            setting.FestivalMessageId = settingVM.FestivalMessageId == 0 ? null : settingVM.FestivalMessageId;
            setting.Upiid = settingVM.UPIId;
            setting.Upiname = settingVM.UPIName;
            setting.UpimerchantCode = settingVM.UPIMerchantCode;
            setting.IsServiceRequestEnabled = (sbyte)(settingVM.IsServiceRequestEnabled ? 1 : 0);
            setting.IsItemSearchImageVisible = (sbyte)(settingVM.IsItemSearchImageVisible ? 1 : 0);
            setting.IsBackupOnLogin = (sbyte)(settingVM.IsBackupOnLogin ? 1 : 0);
            setting.IsViewAllItemsOnSearch = (sbyte)(settingVM.IsViewAllItemsOnSearch ? 1 : 0);
            setting.EmailBodyForSalesInvoice = settingVM.EmailBodyForSalesInvoice;
            setting.IsSalesPriceEdited = (sbyte)(settingVM.IsSalesPriceEdited ? 1 : 0);
            setting.IsSalesInvoiceDateEnabled = (sbyte)(settingVM.IsSalesInvoiceDateEnabled ? 1 : 0);
            setting.IsCurrencyDecimalNotRequired = (sbyte)(settingVM.IsCurrencyDecimalNotRequired ? 1 : 0);
            setting.LocalLanguageCode = string.IsNullOrWhiteSpace(settingVM.LocalLanguageCode) ? "te" : settingVM.LocalLanguageCode;
            setting.IsPrintLocalLanguage = (sbyte)(settingVM.IsPrintLocalLanguage ? 1 : 0);
            setting.IsOnlineStoreEnabled = (sbyte)(settingVM.IsOnlineStoreEnabled ? 1 : 0);
            setting.BankDetails = settingVM.BankDetails;
            setting.IsAutoBackupWhatsAppEnabled = (sbyte)(settingVM.IsAutoBackupWhatsAppEnabled ? 1 : 0);
            setting.IsAutoBackupEmailEnabled = (sbyte)(settingVM.IsAutoBackupEmailEnabled ? 1 : 0);
            setting.PaymentGatewayName = settingVM.PaymentGatewayName ?? "None";
            setting.PaymentGatewayMerchantId = settingVM.PaymentGatewayMerchantId ?? string.Empty;
            setting.PaymentGatewayApiKey = settingVM.PaymentGatewayApiKey ?? string.Empty;
            setting.PaymentGatewayApiSecret = settingVM.PaymentGatewayApiSecret ?? string.Empty;
            setting.MaxItemImageDimension = settingVM.MaxItemImageDimension > 0 ? settingVM.MaxItemImageDimension : 256;

            // Rewards settings
            setting.IsRewardsEnabled = (sbyte)(settingVM.IsRewardsEnabled ? 1 : 0);
            setting.RewardEarningMethod = string.IsNullOrWhiteSpace(settingVM.RewardEarningMethod) ? "FIXED_POINTS" : settingVM.RewardEarningMethod;
            setting.RewardEarningPurchaseAmount = settingVM.RewardEarningPurchaseAmount;
            setting.RewardEarningPoints = settingVM.RewardEarningPoints;
            setting.RewardEarningPercentage = settingVM.RewardEarningPercentage;
            setting.RewardPointValue = settingVM.RewardPointValue;
            setting.RewardMinPurchaseForEarning = settingVM.RewardMinPurchaseForEarning;
            setting.RewardMinPointsForRedemption = settingVM.RewardMinPointsForRedemption;
            setting.RewardMinInvoiceForRedemption = settingVM.RewardMinInvoiceForRedemption;
            setting.RewardMaxRedemptionPercentage = settingVM.RewardMaxRedemptionPercentage;
            setting.RewardAllowPartialRedemption = (sbyte)(settingVM.RewardAllowPartialRedemption ? 1 : 0);
            setting.RewardAllowSameInvoiceRedemption = (sbyte)(settingVM.RewardAllowSameInvoiceRedemption ? 1 : 0);
            setting.RewardIsExpiryEnabled = (sbyte)(settingVM.RewardIsExpiryEnabled ? 1 : 0);
            setting.RewardExpiryDays = settingVM.RewardExpiryDays > 0 ? settingVM.RewardExpiryDays : 365;
            setting.RewardEligibleAmountType = string.IsNullOrWhiteSpace(settingVM.RewardEligibleAmountType) ? "TOTAL_WITH_TAX" : settingVM.RewardEligibleAmountType;
            setting.RewardStartDate = settingVM.RewardStartDate ?? string.Empty;
            setting.RewardEndDate = settingVM.RewardEndDate ?? string.Empty;

            if (!isUpdate)
            {
                await dbContext.Settings.AddAsync(setting);
            }
            await dbContext.SaveChangesAsync();

            return SendResponseMessage("The settings have been updated successfully.");
        }

        public async Task<SettingVM?> GetSettings()
        {
            var setting = await dbContext.Settings.AsNoTracking().FirstOrDefaultAsync();
            if (setting == null)
                return new SettingVM();

            return new SettingVM()
            {
                SmtpHost = setting.SmtpHost ?? string.Empty,
                SmtpPort = setting.SmtpPort ?? string.Empty,
                EmailFrom = setting.EmailFrom ?? string.Empty,
                EmailTo = setting.EmailTo ?? string.Empty,
                EmailPassword = setting.EmailPassword ?? string.Empty,
                IsAutoEmail = setting.IsAutoEmail == 1,
                IsBackupOnExit = setting.IsBackupOnExit == 1,
                IsDiscountEnabled = setting.IsDiscountEnabled == 1,
                AddItemOnSelected = setting.AddItemOnSelected == 1,
                InvoicePrefix = setting.InvoicePrefix ?? string.Empty,
                InvoiceLength = setting.InvoiceLength,
                IsCreateContactOnParty = setting.IsCreateContactOnParty == 1,
                IsCompressBackup = setting.IsCompressBackup == 1,
                IsShadowMenuButton = setting.IsShadowMenuButton == 1,
                IsBiometricAuthEnabled = setting.IsBiometricAuthEnabled == 1,
                IsAlertOnMinimumStock = setting.IsAlertOnMinimumStock == 1,
                ItemCodeAllowNumberOnly = setting.ItemCodeAllowNumberOnly == 1,
                IsSoundEnabled = setting.IsSoundEnabled == 1,
                IsSendSmsonInvoice = setting.IsSendSmsonInvoice == 1,
                IsSendWhatsAppMessageOnInvoice = setting.IsSendWhatsAppMessageOnInvoice == 1,
                IsShareInvoiceOnInvoice = setting.IsShareInvoiceOnInvoice == 1,
                IsShareInvoice3C = setting.IsShareInvoice3C == 1,
                SalesMessageId = setting.SalesMessageId ?? 0,
                ServiceMessageId = setting.ServiceMessageId ?? 0,
                BalanceMessageId = setting.BalanceMessageId ?? 0,
                FestivalMessageId = setting.FestivalMessageId ?? 0,
                UPIId = setting.Upiid ?? string.Empty,
                UPIName = setting.Upiname ?? string.Empty,
                UPIMerchantCode = setting.UpimerchantCode ?? string.Empty,
                IsServiceRequestEnabled = setting.IsServiceRequestEnabled == 1,
                IsItemSearchImageVisible = setting.IsItemSearchImageVisible == 1,
                IsBackupOnLogin = setting.IsBackupOnLogin == 1,
                IsViewAllItemsOnSearch = setting.IsViewAllItemsOnSearch == 1,
                EmailBodyForSalesInvoice = setting.EmailBodyForSalesInvoice ?? "Please find the attached copy of sales invoice",
                IsSalesPriceEdited = setting.IsSalesPriceEdited == 1,
                IsSalesInvoiceDateEnabled = setting.IsSalesInvoiceDateEnabled == 1,
                IsCurrencyDecimalNotRequired = setting.IsCurrencyDecimalNotRequired == 1,
                LocalLanguageCode = setting.LocalLanguageCode ?? "te",
                IsPrintLocalLanguage = setting.IsPrintLocalLanguage == 1,
                IsOnlineStoreEnabled = setting.IsOnlineStoreEnabled == 1,
                BankDetails = setting.BankDetails ?? string.Empty,
                IsAutoBackupWhatsAppEnabled = setting.IsAutoBackupWhatsAppEnabled == 1,
                IsAutoBackupEmailEnabled = setting.IsAutoBackupEmailEnabled == 1,
                PaymentGatewayName = setting.PaymentGatewayName ?? "None",
                PaymentGatewayMerchantId = setting.PaymentGatewayMerchantId ?? string.Empty,
                PaymentGatewayApiKey = setting.PaymentGatewayApiKey ?? string.Empty,
                PaymentGatewayApiSecret = setting.PaymentGatewayApiSecret ?? string.Empty,
                MaxItemImageDimension = setting.MaxItemImageDimension > 0 ? setting.MaxItemImageDimension : 256,

                // Rewards
                IsRewardsEnabled = setting.IsRewardsEnabled == 1,
                RewardEarningMethod = setting.RewardEarningMethod ?? "FIXED_POINTS",
                RewardEarningPurchaseAmount = setting.RewardEarningPurchaseAmount,
                RewardEarningPoints = setting.RewardEarningPoints,
                RewardEarningPercentage = setting.RewardEarningPercentage,
                RewardPointValue = setting.RewardPointValue,
                RewardMinPurchaseForEarning = setting.RewardMinPurchaseForEarning,
                RewardMinPointsForRedemption = setting.RewardMinPointsForRedemption,
                RewardMinInvoiceForRedemption = setting.RewardMinInvoiceForRedemption,
                RewardMaxRedemptionPercentage = setting.RewardMaxRedemptionPercentage,
                RewardAllowPartialRedemption = setting.RewardAllowPartialRedemption == 1,
                RewardAllowSameInvoiceRedemption = setting.RewardAllowSameInvoiceRedemption == 1,
                RewardIsExpiryEnabled = setting.RewardIsExpiryEnabled == 1,
                RewardExpiryDays = setting.RewardExpiryDays > 0 ? setting.RewardExpiryDays : 365,
                RewardEligibleAmountType = setting.RewardEligibleAmountType ?? "TOTAL_WITH_TAX",
                RewardStartDate = setting.RewardStartDate ?? string.Empty,
                RewardEndDate = setting.RewardEndDate ?? string.Empty,

                HeaderModel = new PrintHeader()
                {
                    CompanyName = setting.CompanyName ?? string.Empty,
                    InvoiceTitle = setting.InvoiceTitle ?? string.Empty,
                    Header1 = setting.Header1 ?? string.Empty,
                    Header2 = setting.Header2 ?? string.Empty,
                    Header3 = setting.Header3 ?? string.Empty,
                    Gstin = setting.Gstin ?? string.Empty,
                    GstSlabRequired = setting.GstslabRequired == 1,
                    ItemWiseGstSlabRequired = setting.ItemWiseGstslabRequired == 1,
                    IsPaymentDetailsRequired = setting.IsPaymentDetailsRequired == 1,
                    IsSavingDetailsRequired = setting.IsSavingDetailsRequired == 1,
                    IsGstSummaryRequired = setting.IsGstSummaryRequired == 1,
                    BankDetails = setting.BankDetails ?? string.Empty
                }
            };
        }

        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            return await dbContext.Users.AsNoTracking().Select(row => new UserVM()
            {
                UserRowId = row.UserRowId,
                UserId = row.UserId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Address = row.Address,
                Mobile = row.Mobile,
                IsAdmin = row.IsAdmin == 1,
                IsActive = row.IsActive == 1,
            }).ToListAsync();
        }

        public async Task<ResponseMessage> DeleteUser(int userRowId)
        {
            if (await dbContext.Categories.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Categories.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.Gsts.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Gsts.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.Items.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Items.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.Parties.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Parties.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.Purchases.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Purchases.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.PurchaseItemsDeleteds.AnyAsync(col => col.DeletedBy == userRowId) ||
                await dbContext.PurchaseOrders.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Sales.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Sales.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.SalesItemsDeleteds.AnyAsync(col => col.DeletedBy == userRowId) ||
                await dbContext.ServiceTypes.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.ServiceTypes.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.Settings.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Settings.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.Transactions.AnyAsync(col => col.CreatedBy == userRowId) ||
                await dbContext.Transactions.AnyAsync(col => col.UpdatedBy == userRowId) ||
                await dbContext.Transactions.AnyAsync(col => col.DeletedBy == userRowId) ||
                await dbContext.UnlockRequests.AnyAsync(col => col.RequestedBy == userRowId) ||
                await dbContext.UnlockRequests.AnyAsync(col => col.UpdatedBy == userRowId))
            {
                return SendResponseMessage("Since this user has already been linked to other transactions, you cannot delete them.", false);
            }
            var user = await dbContext.Users.FirstOrDefaultAsync(col => col.UserRowId == userRowId);
            if (user == null)
                return SendResponseMessage("User not found.", false);

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return SendResponseMessage("The user has been deleted successfully");
        }

        private async Task SeedDefaultMessagesIfEmptyAsync()
        {
            if (await dbContext.MessageTemplates.AnyAsync())
                return;

            var defaults = new List<MessageTemplate>
            {
                new() { MessageType = "Sales Invoice", MessageDescription = "Dear <PARTY>, thank you for shopping with us at <COMPANY>. Your invoice total is Rs.<AMOUNT>. <REMARKS>", IsSelected = 1 },
                new() { MessageType = "Service Invoice", MessageDescription = "Dear <PARTY>, thank you for choosing <COMPANY> for your service. Your service invoice total is Rs.<AMOUNT>. <REMARKS>", IsSelected = 1 },
                new() { MessageType = "Sales Invoice", MessageDescription = "Dear <PARTY>, we have received your payment of Rs.<AMOUNT> for <COMPANY>. Thank you! <REMARKS>", IsSelected = 0 },
                new() { MessageType = "Sales Invoice", MessageDescription = "Dear <PARTY>, this is a friendly reminder from <COMPANY> regarding your invoice amount of Rs.<AMOUNT>. <REMARKS>", IsSelected = 0 },
                new() { MessageType = "Sales Invoice", MessageDescription = "Dear <PARTY>, warm greetings from <COMPANY>! Thank you for your continued support. Have a great day! <REMARKS>", IsSelected = 0 },
                new() { MessageType = "Sales Invoice", MessageDescription = "Dear <PARTY>, your bill total at <COMPANY> is Rs.<AMOUNT>. Thank you for visiting us! <REMARKS>", IsSelected = 0 },
                new() { MessageType = "Service Request", MessageDescription = "Dear <PARTY>, your service request at <COMPANY> is completed. Amount payable: Rs.<AMOUNT>. <REMARKS>", IsSelected = 1 },
                new() { MessageType = "Balance Message", MessageDescription = "Dear <PARTY>, your current outstanding balance with <COMPANY> is Rs.<AMOUNT>. Kindly clear the dues at your earliest convenience. <REMARKS>", IsSelected = 1 },
                new() { MessageType = "Festival Message", MessageDescription = "Diwali: Dear <PARTY>, <COMPANY> wishes you and your family a joyous Diwali filled with light, happiness, and prosperity!", IsSelected = 1 },
                new() { MessageType = "Festival Message", MessageDescription = "Sankranti: Dear <PARTY>, <COMPANY> wishes you a happy and prosperous Sankranti / Pongal! May your life be filled with sweetness and success.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Ugadi: Dear <PARTY>, <COMPANY> wishes you a Happy Ugadi! May this new year bring joy, peace, and good health to you and your loved ones.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Holi: Dear <PARTY>, <COMPANY> wishes you a vibrant and Happy Holi! May your life be filled with colors of joy, peace, and health.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Dussehra: Dear <PARTY>, <COMPANY> wishes you a Happy Dussehra! May good triumph over evil and bring success and happiness to your family.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Ganesh Chaturthi: Dear <PARTY>, <COMPANY> wishes you a blessed Ganesh Chaturthi! May Lord Ganesha bless you with health, wealth, and happiness.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Christmas: Dear <PARTY>, <COMPANY> wishes you a Merry Christmas! May this festive season bring warmth, love, and joy to your family.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Eid: Dear <PARTY>, <COMPANY> wishes you and your family a blessed Eid Mubarak! May peace, health, and happiness fill your home.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Onam: Dear <PARTY>, <COMPANY> wishes you a Happy Onam! May the spirit of Onam fill your life with joy, peace, and prosperity.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Raksha Bandhan: Dear <PARTY>, <COMPANY> wishes you a Happy Raksha Bandhan! May this day strengthen the bonds of love, happiness, and health.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "New Year: Dear <PARTY>, <COMPANY> wishes you a Happy New Year! May the coming year bring new opportunities, success, and prosperity.", IsSelected = 0 },
                new() { MessageType = "Festival Message", MessageDescription = "Pongal: Dear <PARTY>, <COMPANY> wishes you and your family a bountiful and Happy Pongal! May your home be blessed with abundance.", IsSelected = 0 }
            };

            await dbContext.MessageTemplates.AddRangeAsync(defaults);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ResponseMessage> InsMessage(int messageId, string messageDescription, string? messageType = null, bool isSelected = false)
        {
            var resolvedType = string.IsNullOrWhiteSpace(messageType) ? "Sales Invoice" : messageType;
            var message = await dbContext.MessageTemplates.FirstOrDefaultAsync(col => col.MessageId == messageId);

            if (isSelected)
            {
                var others = await dbContext.MessageTemplates.Where(m => m.MessageType == resolvedType).ToListAsync();
                foreach (var other in others)
                {
                    other.IsSelected = 0;
                }
            }

            if (message == null)
            {
                bool anyInType = await dbContext.MessageTemplates.AnyAsync(m => m.MessageType == resolvedType && m.IsSelected == 1);
                var newMsg = new MessageTemplate()
                {
                    MessageType = resolvedType,
                    MessageDescription = messageDescription.Trim(),
                    IsSelected = (sbyte)((isSelected || !anyInType) ? 1 : 0)
                };
                await dbContext.MessageTemplates.AddAsync(newMsg);
                await dbContext.SaveChangesAsync();
                return SendResponseMessage("The message has been saved successfully.", true, newMsg.MessageId);
            }
            else
            {
                message.MessageType = resolvedType;
                message.MessageDescription = messageDescription.Trim();
                if (isSelected)
                {
                    message.IsSelected = 1;
                }
                await dbContext.SaveChangesAsync();
                return SendResponseMessage("The message has been updated successfully.", true, message.MessageId);
            }
        }

        public async Task<ResponseMessage> SelectMessageTemplate(int messageId, string messageType)
        {
            var templates = await dbContext.MessageTemplates.Where(m => m.MessageType == messageType).ToListAsync();
            foreach (var t in templates)
            {
                t.IsSelected = (sbyte)(t.MessageId == messageId ? 1 : 0);
            }
            var target = await dbContext.MessageTemplates.FirstOrDefaultAsync(m => m.MessageId == messageId);
            if (target != null)
            {
                target.IsSelected = 1;
                if (!string.IsNullOrWhiteSpace(messageType))
                    target.MessageType = messageType;
            }
            await dbContext.SaveChangesAsync();
            return SendResponseMessage("Message template selected successfully.");
        }

        public async Task<ResponseMessage> GetSelectedMessageDescription(string messageType)
        {
            await SeedDefaultMessagesIfEmptyAsync();
            var selected = await dbContext.MessageTemplates.AsNoTracking()
                .Where(m => m.MessageType == messageType)
                .OrderByDescending(m => m.IsSelected)
                .ThenBy(m => m.MessageId)
                .FirstOrDefaultAsync();

            return SendResponseMessage(selected?.MessageDescription ?? string.Empty);
        }

        public async Task<ResponseMessage> DeleteMessage(int messageId)
        {
            if (await dbContext.Settings.AnyAsync(col => col.SalesMessageId == messageId) ||
                await dbContext.Settings.AnyAsync(col => col.ServiceMessageId == messageId) ||
                await dbContext.Settings.AnyAsync(col => col.BalanceMessageId == messageId) ||
                await dbContext.Settings.AnyAsync(col => col.FestivalMessageId == messageId))
                return SendResponseMessage("Since this message has already been linked in the settings, you cannot delete it.", false);

            var message = await dbContext.MessageTemplates.FirstOrDefaultAsync(col => col.MessageId == messageId);
            if (message == null)
                return SendResponseMessage("Message not found.", false);

            string msgType = message.MessageType;
            bool wasSelected = message.IsSelected == 1;

            dbContext.MessageTemplates.Remove(message);
            await dbContext.SaveChangesAsync();

            if (wasSelected)
            {
                var nextMsg = await dbContext.MessageTemplates.Where(m => m.MessageType == msgType).OrderBy(m => m.MessageId).FirstOrDefaultAsync();
                if (nextMsg != null)
                {
                    nextMsg.IsSelected = 1;
                    await dbContext.SaveChangesAsync();
                }
            }

            return SendResponseMessage("The message has been deleted successfully");
        }

        public async Task<IEnumerable<MessageTemplateVM>> GetMessages()
        {
            await SeedDefaultMessagesIfEmptyAsync();
            return await dbContext.MessageTemplates.AsNoTracking()
                .OrderByDescending(m => m.IsSelected)
                .ThenBy(m => m.MessageId)
                .Select(m => new MessageTemplateVM
                {
                    MessageId = m.MessageId,
                    MessageType = string.IsNullOrEmpty(m.MessageType) ? "Sales Invoice" : m.MessageType,
                    MessageDescription = m.MessageDescription,
                    IsSelected = m.IsSelected == 1
                })
                .ToListAsync();
        }

        // Custom Receipt Lines
        public async Task<List<CustomReceiptLineVM>> GetAllCustomLines()
        {
            return await dbContext.CustomReceiptLines.AsNoTracking()
                .OrderBy(c => c.CustomLineId)
                .Select(c => new CustomReceiptLineVM
                {
                    CustomLineId = c.CustomLineId,
                    CustomLineTitle = c.CustomLineTitle,
                    CustomLineDescription = c.CustomLineDescription,
                    IsActive = c.IsActive == 1
                })
                .ToListAsync();
        }

        public async Task<List<CustomReceiptLineVM>> GetActiveCustomLines()
        {
            return await dbContext.CustomReceiptLines.AsNoTracking()
                .Where(c => c.IsActive == 1)
                .OrderBy(c => c.CustomLineId)
                .Select(c => new CustomReceiptLineVM
                {
                    CustomLineId = c.CustomLineId,
                    CustomLineTitle = c.CustomLineTitle,
                    CustomLineDescription = c.CustomLineDescription,
                    IsActive = true
                })
                .ToListAsync();
        }

        public async Task<ResponseMessage> UpsertCustomLine(CustomReceiptLineVM line)
        {
            var desc = (line.CustomLineDescription ?? string.Empty).Trim();
            var title = (line.CustomLineTitle ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(desc))
                return SendResponseMessage("Footer line cannot be empty.", false);
            if (desc.Length > 48)
                return SendResponseMessage("Footer line cannot exceed 48 characters.", false);
            if (title.Length > 30)
                return SendResponseMessage("Title cannot exceed 30 characters.", false);

            if (line.CustomLineId == 0)
            {
                int count = await dbContext.CustomReceiptLines.CountAsync();
                if (count >= 10)
                    return SendResponseMessage("Maximum of 10 custom receipt footer lines are allowed.", false);

                var entity = new CustomReceiptLine
                {
                    CustomLineTitle = title,
                    CustomLineDescription = desc,
                    IsActive = (sbyte)(line.IsActive ? 1 : 0),
                    CreatedDate = DateTime.Now
                };
                await dbContext.CustomReceiptLines.AddAsync(entity);
                await dbContext.SaveChangesAsync();
                return SendResponseMessage("Custom receipt line added successfully.", true, entity.CustomLineId);
            }
            else
            {
                var entity = await dbContext.CustomReceiptLines.FirstOrDefaultAsync(c => c.CustomLineId == line.CustomLineId);
                if (entity == null)
                    return SendResponseMessage("Custom receipt line not found.", false);

                entity.CustomLineTitle = title;
                entity.CustomLineDescription = desc;
                entity.IsActive = (sbyte)(line.IsActive ? 1 : 0);
                await dbContext.SaveChangesAsync();
                return SendResponseMessage("Custom receipt line updated successfully.", true, entity.CustomLineId);
            }
        }

        public async Task<ResponseMessage> UpdateCustomLineActiveStatus(int customLineId, bool isActive)
        {
            var entity = await dbContext.CustomReceiptLines.FirstOrDefaultAsync(c => c.CustomLineId == customLineId);
            if (entity == null)
                return SendResponseMessage("Failed to update status.", false);

            entity.IsActive = (sbyte)(isActive ? 1 : 0);
            await dbContext.SaveChangesAsync();
            return SendResponseMessage("Status updated successfully.");
        }

        public async Task<ResponseMessage> DeleteCustomLine(int customLineId)
        {
            var entity = await dbContext.CustomReceiptLines.FirstOrDefaultAsync(c => c.CustomLineId == customLineId);
            if (entity == null)
                return SendResponseMessage("Failed to delete custom line.", false);

            dbContext.CustomReceiptLines.Remove(entity);
            await dbContext.SaveChangesAsync();
            return SendResponseMessage("Custom receipt line deleted successfully.");
        }
    }
}
