using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System.Text;

namespace PaybillAPI.Repositories
{
    public class SharedRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), ISharedRepository
    {
        public async Task<string> CheckDatabase(string logoUrl)
        {
            try
            {
                var isConnected = await dbContext.Database.CanConnectAsync();
                if (isConnected)
                {
                    return new StringBuilder().Append("<html><head><title>Player Server</title></head>")
                                                .Append("<body style='background-color: black;'><div><img style='position: absolute; left: 50%; top: 50%; transform: translate(-50%,-50%);' src='")
                                                .Append(logoUrl)
                                                .Append("'>")
                                                .Append("<div style='color: white; font-family: Verdana, Geneva, Tahoma;'>PayBill api server started</div>")
                                                .Append("</div></body></html>").ToString();
                }
                else
                    return new StringBuilder().Append("<html><body style='background-color: black;'>")
                        .Append("Error: The PayBill API service database is not configured.")
                        .Append('\n')
                        .Append("Steps to create database: ")
                        .Append('\n')
                        .Append("1. In MySQL server, create a database with any name. ex: paybill_api or custom name.")
                        .Append('\n')
                        .Append("2. Change the database name in appsettings -> ConnectionStrings->SqlConnection.")
                        .Append('\n')
                        .Append("3. Update the valid SQL Server connection string.")
                        .Append('\n')
                        .Append("4. And run the database script file from wwwroot->dbscript->script.sql")
                        .Append("</body></html>").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<bool> IsValidAccount(string ClientUniqueId, string clientId)
        {
            return await dbContext.Clients.Where(col => col.ClientUniqueId == ClientUniqueId && col.ClientId == clientId).AnyAsync();
        }

        public async Task<bool> IsValidUser(int userRowId, string securityKey, int identityId)
        {
            return await dbContext.Users.Where(col => col.IsActive == 1 && col.UserRowId == userRowId && col.SecurityKey == DataProtection.UrlDecode(securityKey, AppConstants.API_AES_KEY_AND_IV)).AnyAsync() && userRowId == identityId;
        }

        public async Task<bool> IsValidAdminUser(int userRowId, string securityKey, int identityId)
        {
            return await dbContext.Users.Where(col => col.IsActive == 1 && col.UserRowId == userRowId && col.IsAdmin == 1 && col.SecurityKey == DataProtection.UrlDecode(securityKey, AppConstants.API_AES_KEY_AND_IV)).AnyAsync() && userRowId == identityId;
        }

        public async Task<string> CreateUserIfNotExists(UserVM userVM)
        {
            User? user = await dbContext.Users.Where(col => col.UserId == userVM.UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                byte[] saltBytes = DataProtection.GenerateRandomNumber(20);
                byte[] hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(userVM.Password), saltBytes);
                userVM.Password = DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV);
                userVM.SaltKey = DataProtection.EncryptWithIV(Convert.ToBase64String(saltBytes), AppConstants.API_AES_KEY_AND_IV);

                await dbContext.Users.AddAsync(new User()
                {
                    UserId = userVM.UserId,
                    Password = userVM.Password,
                    UserSaltKey = userVM.SaltKey!,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    Address = userVM.Address,
                    Mobile = userVM.Mobile,
                    IsAdmin = (sbyte)userVM.IsAdmin.GetHashCode(),
                    IsActive = (sbyte)userVM.IsActive.GetHashCode(),
                });
                await SaveChangesAsync();
                return AppConstants.RESPONSE_SUCCESS;
            }
            else
                return "User account has already been created with the same Id.";
        }

        public async Task<ResponseMessage> UpsertUser(UserVM userVM, int userRowId)
        {
            if (userVM.UserRowId == 0)
            {
                User? user = await dbContext.Users.Where(col => col.UserId == userVM.UserId).FirstOrDefaultAsync();
                if (user != null)
                    return new ResponseMessage(isSuccess: false, message: "User account has already been created with the same Id.");

                byte[] saltBytes = DataProtection.GenerateRandomNumber(20);
                byte[] hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(userVM.Password), saltBytes);
                userVM.Password = DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV);
                userVM.SaltKey = DataProtection.EncryptWithIV(Convert.ToBase64String(saltBytes), AppConstants.API_AES_KEY_AND_IV);

                await dbContext.Users.AddAsync(new User()
                {
                    UserId = userVM.UserId,
                    Password = userVM.Password,
                    UserSaltKey = userVM.SaltKey!,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    Address = userVM.Address,
                    Mobile = userVM.Mobile,
                    IsAdmin = (sbyte)userVM.IsAdmin.GetHashCode(),
                    IsActive = (sbyte)userVM.IsActive.GetHashCode(),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = userRowId,
                    UpdatedBy = userRowId
                });

            }
            else
            {
                User? user = await dbContext.Users.Where(col => col.UserId == userVM.UserId).FirstOrDefaultAsync();
                if (user == null)
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "User"));

                if (!string.IsNullOrWhiteSpace(userVM.Password))
                {
                    byte[] saltBytes = DataProtection.GenerateRandomNumber(20);
                    byte[] hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(userVM.Password), saltBytes);
                    userVM.Password = DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV);
                    userVM.SaltKey = DataProtection.EncryptWithIV(Convert.ToBase64String(saltBytes), AppConstants.API_AES_KEY_AND_IV);
                    user.Password = userVM.Password;
                    user.UserSaltKey = userVM.SaltKey!;
                }
                user.FirstName = userVM.FirstName;
                user.LastName = userVM.LastName;
                user.Address = userVM.Address;
                user.Mobile = userVM.Mobile;
                user.IsActive = (sbyte)userVM.IsActive.GetHashCode();
                user.UpdatedDate = DateTime.Now;
                user.UpdatedBy = userRowId;
            }

            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: AppConstants.RESPONSE_SUCCESS);
        }

        public async Task<string> CreateAccountIfNotExists(ClientVM clientVM)
        {
            Client? client = await dbContext.Clients.Where(col => col.ClientUniqueId == clientVM.ClientUniqueId).FirstOrDefaultAsync();
            if (client == null)
            {
                client = new Client
                {
                    ClientUniqueId = clientVM.ClientUniqueId,
                    ClientId = clientVM.ClientId,
                    ClientName = clientVM.ClientName,
                    BusinessType = clientVM.BusinessType,
                    Mobile = clientVM.Mobile,
                    Email = clientVM.Email,
                    Address = clientVM.Address,
                    SubscriptionType = clientVM.SubscriptionType,
                    SubscriptionAmount = clientVM.SubscriptionAmount,
                    SubscriptionEndDate = DateTime.Parse(clientVM.SubscriptionEndDate),
                    IsPremiumUser = (sbyte)clientVM.IsPremiumUser.GetHashCode(),
                    IsActivated = (sbyte)clientVM.IsActivated.GetHashCode(),
                    SecurityKey = clientVM.SecurityKey,
                };
                await dbContext.Clients.AddAsync(client);
                await SaveChangesAsync();
                clientVM.SecurityKey = client.SecurityKey;
                return AppConstants.RESPONSE_SUCCESS;
            }
            else
                return AppConstants.RESPONSE_SUCCESS;
        }

        public async Task<ResponseMessage> UpdateProfile(ClientVM clientVM)
        {
            Client? client = await dbContext.Clients.Where(col => col.ClientUniqueId == clientVM.ClientUniqueId).FirstOrDefaultAsync();
            if (client != null)
            {
                client.ClientUniqueId = clientVM.ClientUniqueId;
                client.ClientId = clientVM.ClientId;
                client.ClientName = clientVM.ClientName;
                client.BusinessType = clientVM.BusinessType;
                client.Mobile = clientVM.Mobile;
                client.Email = clientVM.Email;
                client.Address = clientVM.Address;
                client.SubscriptionType = clientVM.SubscriptionType;
                client.SubscriptionAmount = clientVM.SubscriptionAmount;
                client.SubscriptionEndDate = DateTime.Parse(clientVM.SubscriptionEndDate);
                client.IsPremiumUser = (sbyte)clientVM.IsPremiumUser.GetHashCode();
                client.IsActivated = (sbyte)clientVM.IsActivated.GetHashCode();
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: "Profile has been updated successfully");
            }
            else
                return new ResponseMessage(isSuccess: false, message: "Client not found");
        }

        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            return await dbContext.Users.Select(row => new UserVM
            {
                UserRowId = row.UserRowId,
                UserId = row.UserId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Mobile = row.Mobile,
                Address = row.Address ?? string.Empty,
                IsAdmin = row.IsAdmin == 1,
                IsActive = row.IsActive == 1
            }).OrderBy(ord => ord.FirstName).ToListAsync();
        }

        public async Task<PrintHeader> GetPrintHeader()
        {
            PrintHeader printHeader = new();
            Setting? setting = await dbContext.Settings.FirstOrDefaultAsync();
            if (setting != null)
            {
                printHeader.InvoiceTitle = setting.InvoiceTitle ?? "Estimation";
                printHeader.CompanyName = setting.CompanyName;
                printHeader.Header1 = setting.Header1 ?? "";
                printHeader.Header2 = setting.Header2 ?? "";
                printHeader.Header3 = setting.Header3 ?? "";
                printHeader.Gstin = setting.Gstin ?? "";
                printHeader.GstSlabRequired = setting.GstslabRequired == 1;
                printHeader.ItemWiseGstSlabRequired = setting.ItemWiseGstslabRequired == 1;
            }
            return printHeader;
        }

        public async Task<AuthResponseVM> UserAuthentication(AuthRequestVM authRequest)
        {
            User? user = await dbContext.Users.Where(col => col.UserId == authRequest.UserId && col.IsActive == 1).FirstOrDefaultAsync();
            if (user == null)
                return new AuthResponseVM() { IsSuccess = false, Message = "Security information failed!" };

            byte[] hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(authRequest.Password), Convert.FromBase64String(DataProtection.DecryptWithIV(user.UserSaltKey!, AppConstants.API_AES_KEY_AND_IV)));

            if (!user.Password.Equals(DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV)))
                return new AuthResponseVM() { IsSuccess = false, Message = "Security information failed!" };

            string securityKey = SharedMethod.GenerateUniqueID();


            PrintHeader printHeader = await GetPrintHeader();
            DashboardPref dashboardPref = await dbContext.Settings.Select(row => new DashboardPref()
            {
                IsAutoEmail = row.IsAutoEmail == 1,
                IsBackupOnExit = row.IsBackupOnExit == 1,
                IsDiscountEnabled = row.IsDiscountEnabled == 1,
                AddItemOnSelected = row.AddItemOnSelected == 1,
                IsCreateContactOnParty = row.IsCreateContactOnParty == 1,
                IsCompressBackup = row.IsCompressBackup == 1,
                IsShadowMenuButton = row.IsShadowMenuButton == 1,
                IsAlertOnMinimumStock = row.IsAlertOnMinimumStock == 1,
                ItemCodeAllowNumberOnly = row.ItemCodeAllowNumberOnly == 1,
                ServiceGSTCode = !string.IsNullOrEmpty(row.Gstin) && row.Gstin.Length > 1 ? row.Gstin.Substring(0, 2) : "",
                IsBiometricAuthEnabled = row.IsBiometricAuthEnabled == 1,
                HeaderModel = printHeader,
                IsSettingsUpdated = true

            }).FirstOrDefaultAsync() ?? new DashboardPref() { IsSettingsUpdated = false };

            string biometricAuthKey = string.Empty;

            if (dashboardPref.IsBiometricAuthEnabled)
            {
                string authKey = JsonConvert.SerializeObject(
                new BiometricAuth()
                {
                    ClientId = authRequest.ClientId,
                    ClientUniqueId = authRequest.ClientUniqueId,
                    SecurityKey = securityKey,
                    UserRowId = user.UserRowId,
                    UserId = user.UserId,
                    BiometricAuthKeyValidity = 10,
                    BiometricAuthKeyDate = DateTime.Now.Date.ToString("dd-MMM-yyyy")
                });
                biometricAuthKey = DataProtection.EncryptWithIV(authKey, AppConstants.API_AES_KEY_AND_IV);
            }

            user.BiometricAuthKey = biometricAuthKey;
            user.SecurityKey = securityKey;
            user.UpdatedDate = DateTime.Now;
            await SaveChangesAsync();

            Client client = await dbContext.Clients.Where(col => col.ClientUniqueId == authRequest.ClientUniqueId).FirstAsync();

            return new AuthResponseVM()
            {
                IsSuccess = true,
                User = new UserVM()
                {
                    UserRowId = user.UserRowId,
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mobile = user.Mobile,
                    Address = user.Address ?? string.Empty,
                    IsAdmin = user.IsAdmin == 1,
                    SecurityKey = user.SecurityKey,
                    BiometricAuthKey = biometricAuthKey,
                    Client = new ClientVM()
                    {
                        ClientUniqueId = client.ClientUniqueId,
                        ClientId = client.ClientId,
                        IsPremiumUser = client.IsPremiumUser == 1,
                        IsActivated = client.IsActivated == 1
                    }
                },
                Pref = dashboardPref,
                IsBiometricAuthentication = false
            };
        }

        public async Task<AuthResponseVM> UserAuthenticationBiometric(BiometricAuth authRequest, string biometricAuthKey)
        {
            string error = "Biometric authentication could not be verified. Please logIn with your user credentials and try again.";

            User? user = await dbContext.Users.Where(col => col.UserRowId == authRequest.UserRowId && col.IsActive == 1 && col.BiometricAuthKey == biometricAuthKey && col.SecurityKey == authRequest.SecurityKey).FirstOrDefaultAsync();
            if (user == null)
                return new AuthResponseVM() { IsSuccess = false, Message = error };

            PrintHeader printHeader = await GetPrintHeader();
            DashboardPref dashboardPref = await dbContext.Settings.Select(row => new DashboardPref()
            {
                IsAutoEmail = row.IsAutoEmail == 1,
                IsBackupOnExit = row.IsBackupOnExit == 1,
                IsDiscountEnabled = row.IsDiscountEnabled == 1,
                AddItemOnSelected = row.AddItemOnSelected == 1,
                IsCreateContactOnParty = row.IsCreateContactOnParty == 1,
                IsCompressBackup = row.IsCompressBackup == 1,
                IsShadowMenuButton = row.IsShadowMenuButton == 1,
                IsAlertOnMinimumStock = row.IsAlertOnMinimumStock == 1,
                ItemCodeAllowNumberOnly = row.ItemCodeAllowNumberOnly == 1,
                ServiceGSTCode = !string.IsNullOrEmpty(row.Gstin) && row.Gstin.Length > 1 ? row.Gstin.Substring(0, 2) : "",
                IsBiometricAuthEnabled = row.IsBiometricAuthEnabled == 1,
                IsSoundEnabled = row.IsSoundEnabled == 1,
                HeaderModel = printHeader,
                IsSettingsUpdated = true

            }).FirstOrDefaultAsync() ?? new DashboardPref() { IsSettingsUpdated = false };


            Client client = await dbContext.Clients.Where(col => col.ClientUniqueId == authRequest.ClientUniqueId).FirstAsync();

            return new AuthResponseVM()
            {
                IsSuccess = true,
                User = new UserVM()
                {
                    UserRowId = user.UserRowId,
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Mobile = user.Mobile,
                    Address = user.Address ?? string.Empty,
                    IsAdmin = user.IsAdmin == 1,
                    SecurityKey = user.SecurityKey,
                    BiometricAuthKey = biometricAuthKey,
                    Client = new ClientVM()
                    {
                        ClientUniqueId = client.ClientUniqueId,
                        ClientId = client.ClientId,
                        IsPremiumUser = client.IsPremiumUser == 1,
                        IsActivated = client.IsActivated == 1
                    }
                },
                Pref = dashboardPref,
                IsBiometricAuthentication = true
            };
        }

        public async Task<ResponseMessage> ChangePassword(int userRowId, string oldPassword, string newPassword)
        {
            User? user = await dbContext.Users.FindAsync(userRowId);
            if (user == null)
                return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "User"));

            byte[] hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(oldPassword), Convert.FromBase64String(DataProtection.DecryptWithIV(user.UserSaltKey!, AppConstants.API_AES_KEY_AND_IV)));

            if (!user.Password.Equals(DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV)))
                return new ResponseMessage(isSuccess: false, message: "The old password cannot be matched.");

            byte[] saltBytes = DataProtection.GenerateRandomNumber(20);
            hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(newPassword), saltBytes);
            user.Password = DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV);
            user.UserSaltKey = DataProtection.EncryptWithIV(Convert.ToBase64String(saltBytes), AppConstants.API_AES_KEY_AND_IV);
            user.UpdatedDate = DateTime.Now;
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: AppConstants.RESPONSE_SUCCESS);
        }

        public async Task<ResponseMessage> InsUnlockRequest(UnlockRequestVM request, int userRowId)
        {
            await dbContext.UnlockRequests.AddAsync(new UnlockRequest()
            {
                SalesId = request.SalesModel != null ? request.SalesModel.SalesId : null,
                PurchaseId = request.PurchaseModel != null ? request.PurchaseModel.PurchaseId : null,
                Remarks = request.Remarks,
                IsApproved = 0,
                IsRejected = 0,
                RequestedDate = DateTime.Now,
                RequestedBy = userRowId
            });
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: "Invoice unlock request submitted successfully.");
        }

        public async Task<List<UnlockRequestVM>> GetUnlockRequests()
        {
            return await dbContext.UnlockRequests.Where(col => col.IsApproved == 0 && col.IsRejected == 0).OrderBy(ord => ord.RequestedDate).Select(row => new UnlockRequestVM()
            {
                UnlockRequestId = row.UnlockRequestId,
                Remarks = row.Remarks,
                RequestedDate = row.RequestedDate.ToString("dd-MMM-yyyy hh:mm tt"),
                RequestedBy = $"{row.RequestedByNavigation.FirstName} {row.RequestedByNavigation.LastName} ({row.RequestedByNavigation.UserId})",
                SalesModel = row.Sales != null ? new SalesVM()
                {
                    SalesId = row.Sales.SalesId,
                    InvoiceNo = row.Sales.InvoiceNo,
                    InvoiceDate = row.Sales.InvoiceDate.ToString("dd-MMM-yyyy"),
                    PartyModel = row.Sales.Party != null ? new PartyVM() { PartyName = row.Sales.Party.PartyName } : null
                } : null,
                PurchaseModel = row.Purchase != null ? new PurchaseVM()
                {
                    PurchaseId = row.Purchase.PurchaseId,
                    InvoiceNo = row.Purchase.InvoiceNo,
                    InvoiceDate = row.Purchase.InvoiceDate.ToString("dd-MMM-yyyy"),
                    PartyModel = new PartyVM() { PartyName = row.Purchase.Party.PartyName }
                } : null,
                TotalAmount = row.Sales != null ? row.Sales.SalesItems.Sum(x => x.TotalAmount) : row.Purchase!.PurchaseItems.Sum(x => x.TotalAmount)
            }).ToListAsync();
        }

        public async Task<ResponseMessage> UpdateUnlockRequest(int unlockRequestId, bool isApproved, string remarks, int userRowId)
        {
            UnlockRequest? unlockRequest = await dbContext.UnlockRequests.Where(col => col.UnlockRequestId == unlockRequestId && col.IsApproved == 0 && col.IsRejected == 0).FirstOrDefaultAsync();
            if (unlockRequest == null)
                return new ResponseMessage(isSuccess: false, message: "The unlock request was already processed.");
            unlockRequest.UpdatedDate = DateTime.Now;
            unlockRequest.UpdatedBy = userRowId;
            unlockRequest.IsApproved = (sbyte)isApproved.GetHashCode();
            unlockRequest.IsRejected = (sbyte)(!isApproved).GetHashCode();
            if (string.IsNullOrEmpty(remarks))
                unlockRequest.Remarks = $"{unlockRequest.Remarks}\n{remarks}";
            if (isApproved)
            {
                if (unlockRequest.SalesId != null)
                {
                    Sale? sale = await dbContext.Sales.FindAsync(unlockRequest.SalesId);
                    if (sale != null)
                        sale.IsLocked = 0;
                }

                if (unlockRequest.PurchaseId != null)
                {
                    Purchase? purchase = await dbContext.Purchases.FindAsync(unlockRequest.PurchaseId);
                    if (purchase != null)
                        purchase.IsLocked = 0;
                }
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: isApproved ? "The unlock request was approved successfully." : "The unlock request was rejected.");
        }

    }
}
