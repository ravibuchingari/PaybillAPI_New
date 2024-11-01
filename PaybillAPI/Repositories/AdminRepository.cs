using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories
{
    public class AdminRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), IAdminRepository
    {
        public async Task<SettingVM?> GetSettings()
        {
            return await dbContext.Settings.Select(row => new SettingVM()
            {
                SmtpHost = row.SmtpHost,
                SmtpPort = row.SmtpPort,
                EmailFrom = row.EmailFrom,
                EmailTo = row.EmailTo,
                EmailPassword = row.EmailPassword,
                IsAutoEmail = row.IsAutoEmail == 1,
                IsBackupOnExit = row.IsBackupOnExit == 1,
                IsDiscountEnabled = row.IsDiscountEnabled == 1,

                AddItemOnSelected = row.AddItemOnSelected == 1,
                InvoicePrefix = row.InvoicePrefix,
                InvoiceLength = row.InvoiceLength,
                IsCreateContactOnParty = row.IsCreateContactOnParty == 1,
                IsCompressBackup = row.IsCompressBackup == 1,
                IsShadowMenuButton = row.IsShadowMenuButton == 1,
                IsBiometricAuthEnabled = row.IsBiometricAuthEnabled == 1,
                IsAlertOnMinimumStock = row.IsAlertOnMinimumStock == 1,
                HeaderModel = new ReceiptHeader()
                {
                    CompanyName = row.CompanyName,
                    InvoiceTitle = row.InvoiceTitle,
                    Header1 = row.Header1,
                    Header2 = row.Header2,
                    Header3 = row.Header3,
                    GSTIN = row.Gstin,
                    GSTSlabRequired = row.GstslabRequired == 1,
                },
                IsSettingsUpdated = true

            }).FirstOrDefaultAsync();
        }

        private static Setting PrepareSettings(SettingVM settingVM, Setting setting)
        {
            setting.CompanyName = settingVM.HeaderModel?.CompanyName!;
            setting.SmtpHost = settingVM.SmtpHost;
            setting.SmtpPort = settingVM.SmtpPort;
            setting.EmailFrom = settingVM.EmailFrom;
            setting.EmailTo = settingVM.EmailTo;
            setting.EmailPassword = settingVM.EmailPassword;
            setting.IsAutoEmail = settingVM.IsAutoEmail.GetHashCode();
            setting.IsBackupOnExit = settingVM.IsBackupOnExit.GetHashCode();
            setting.IsDiscountEnabled = settingVM.IsDiscountEnabled.GetHashCode();
            setting.InvoiceTitle = settingVM.HeaderModel!.InvoiceTitle;
            setting.Header1 = settingVM.HeaderModel.Header1;
            setting.Header2 = settingVM.HeaderModel.Header2;
            setting.Header3 = settingVM.HeaderModel.Header3;
            setting.Gstin = settingVM.HeaderModel.GSTIN;
            setting.GstslabRequired = settingVM.HeaderModel.GSTSlabRequired.GetHashCode()!;
            setting.AddItemOnSelected = settingVM.AddItemOnSelected.GetHashCode();
            setting.InvoicePrefix = settingVM.InvoicePrefix;
            setting.InvoiceLength = settingVM.InvoiceLength;
            setting.IsCreateContactOnParty = settingVM.IsCreateContactOnParty.GetHashCode();
            setting.IsCompressBackup = settingVM.IsCompressBackup.GetHashCode();
            setting.IsShadowMenuButton = settingVM.IsShadowMenuButton.GetHashCode();
            setting.IsBiometricAuthEnabled = settingVM.IsBiometricAuthEnabled.GetHashCode();
            setting.IsAlertOnMinimumStock = settingVM.IsAlertOnMinimumStock.GetHashCode();
            return setting;
        }

        public async Task<ResponseMessage> UpdateSettings(int userRowId, SettingVM settingVM)
        {
            Setting? setting = await dbContext.Settings.FirstOrDefaultAsync();
            if (setting != null)
            {
                setting = PrepareSettings(settingVM, setting);
                setting.UpdatedDate = DateTime.Now;
                setting.UpdatedBy = userRowId;
            }
            else
            {
                setting = PrepareSettings(settingVM, new Setting());
                setting.CreatedDate = DateTime.Now;
                setting.CreatedBy = userRowId;
                setting.UpdatedDate = DateTime.Now;
                setting.UpdatedBy = userRowId;
                await dbContext.Settings.AddAsync(setting);
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: AppConstants.RESPONSE_SUCCESS);
        }

    }
}
