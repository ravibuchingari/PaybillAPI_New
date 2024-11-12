﻿using Microsoft.EntityFrameworkCore;
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
                HeaderModel = new PrintHeader()
                {
                    CompanyName = row.CompanyName,
                    InvoiceTitle = row.InvoiceTitle ?? "",
                    Header1 = row.Header1 ?? "",
                    Header2 = row.Header2 ?? "",
                    Header3 = row.Header3 ?? "",
                    Gstin = row.Gstin ?? "",
                    GstSlabRequired = row.GstslabRequired == 1,
                    ItemWiseGstSlabRequired = row.ItemWiseGstslabRequired == 1,
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
            setting.IsAutoEmail = (sbyte)settingVM.IsAutoEmail.GetHashCode();
            setting.IsBackupOnExit = (sbyte)settingVM.IsBackupOnExit.GetHashCode();
            setting.IsDiscountEnabled = (sbyte)settingVM.IsDiscountEnabled.GetHashCode();
            setting.InvoiceTitle = settingVM.HeaderModel!.InvoiceTitle;
            setting.Header1 = settingVM.HeaderModel.Header1;
            setting.Header2 = settingVM.HeaderModel.Header2;
            setting.Header3 = settingVM.HeaderModel.Header3;
            setting.Gstin = settingVM.HeaderModel.Gstin;
            setting.GstslabRequired = (sbyte)settingVM.HeaderModel.GstSlabRequired.GetHashCode()!;
            setting.ItemWiseGstslabRequired = (sbyte)settingVM.HeaderModel.ItemWiseGstSlabRequired.GetHashCode()!;
            setting.AddItemOnSelected = (sbyte)settingVM.AddItemOnSelected.GetHashCode();
            setting.InvoicePrefix = settingVM.InvoicePrefix;
            setting.InvoiceLength = settingVM.InvoiceLength;
            setting.IsCreateContactOnParty = (sbyte)settingVM.IsCreateContactOnParty.GetHashCode();
            setting.IsCompressBackup = (sbyte)settingVM.IsCompressBackup.GetHashCode();
            setting.IsShadowMenuButton = (sbyte)settingVM.IsShadowMenuButton.GetHashCode();
            setting.IsBiometricAuthEnabled = (sbyte)settingVM.IsBiometricAuthEnabled.GetHashCode();
            setting.IsAlertOnMinimumStock = (sbyte)settingVM.IsAlertOnMinimumStock.GetHashCode();
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

        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            return await dbContext.Users.Select(row => new UserVM()
            {
                UserRowId = row.UserRowId,
                UserId = row.UserId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Mobile = row.Mobile,
                Address = row.Address ?? string.Empty,
                IsAdmin = row.IsAdmin == 1,
                IsActive = row.IsActive == 1
            }).ToListAsync();
        }

        public async Task<ResponseMessage> DeleteUser(int userRowId)
        {
            User user = await dbContext.Users.FindAsync(userRowId) ?? throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "User"));
            if (user.IsAdmin == 1)
                return new ResponseMessage(isSuccess: false, message: "You cannot delete the administrator account.");
            dbContext.Users.Remove(user);
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: "User account has been deleted successfully.");
        }

    }
}
