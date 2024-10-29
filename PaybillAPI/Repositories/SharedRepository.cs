using Authentication.JWTAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System.Collections;
using System.Collections.Immutable;
using System.Reflection;
using System.Text;

namespace PaybillAPI.Repositories
{
    public class SharedRepository(AppDBContext context) : RootRepository(context ?? null), ISharedRepository
    {
        public async Task<bool> IsValidAccount(string ClientUniqueId, string clientId)
        {
            return await context.Clients.Where(col => col.ClientUniqueId == ClientUniqueId && col.ClientId == clientId).AnyAsync();
        }

        public async Task<bool> IsValidUser(int userRowId, string securityKey)
        {
            return await context.Users.Where(col => col.UserRowId == userRowId && col.SecurityKey == DataProtection.UrlDecode(securityKey,AppConstants.API_AES_KEY_AND_IV)).AnyAsync();
        }

        public async Task<string> CreateUserIfNotExists(UserVM userVM)
        {
            User? user = await context.Users.Where(col => col.UserId == userVM.UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                await context.Users.AddAsync(new User()
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

        public async Task<string> CreateAccountIfNotExists(ClientVM clientVM)
        {
            Client? client = await context.Clients.Where(col => col.ClientUniqueId == clientVM.ClientUniqueId).FirstOrDefaultAsync();
            if (client == null)
            {
                client = new Client { 
                    ClientUniqueId = clientVM.ClientUniqueId ,
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
                await context.Clients.AddAsync(client);
                await SaveChangesAsync();
                clientVM.SecurityKey = client.SecurityKey;
                return AppConstants.RESPONSE_SUCCESS;
            }
            else
                return AppConstants.RESPONSE_SUCCESS;
        }

        public async Task<ResponseMessage> UpdateProfile(ClientVM clientVM)
        {
            Client? client = await context.Clients.Where(col => col.ClientUniqueId == clientVM.ClientUniqueId).FirstOrDefaultAsync();
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
            return await context.Users.Select(row => new UserVM { 
                UserId = row.UserId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Mobile = row.Mobile,
                IsAdmin = row.IsAdmin == 1,
                IsActive = row.IsActive == 1
            }).OrderBy(ord => ord.FirstName).ToListAsync();
        }

        public async Task<AuthResponseVM> UserAuthentication(AuthRequestVM authRequest)
        {
            User? user = await context.Users.Where(col => col.UserId == authRequest.UserId && col.IsActive == 1).FirstOrDefaultAsync();
            if(user == null)
                return new AuthResponseVM() { IsSuccess = false, Message = "Security information failed!" };

            byte[] hashPassword = DataProtection.GetSaltHasPassword(Encoding.ASCII.GetBytes(authRequest.Password), Convert.FromBase64String(DataProtection.DecryptWithIV(user.UserSaltKey, AppConstants.API_AES_KEY_AND_IV)));

            if (!user.Password.Equals(DataProtection.EncryptWithIV(Convert.ToBase64String(hashPassword), AppConstants.API_AES_KEY_AND_IV)))
                return new AuthResponseVM() { IsSuccess = false, Message = "Security information failed!" };

            string securityKey = SharedMethod.GenerateUniqueID();

            user.SecurityKey = securityKey;
            user.UpdatedDate = DateTime.Now;
            await SaveChangesAsync();
            DashboardPref dashboardPref = await context.Settings.Select(row => new DashboardPref()
            {
                IsAutoEmail = row.IsAutoEmail == 1,
                IsBackupOnExit = row.IsBackupOnExit == 1,
                IsDiscountEnabled = row.IsDiscountEnabled == 1,
                AddItemOnSelected = row.AddItemOnSelected == 1,
                IsCreateContactOnParty = row.IsCreateContactOnParty == 1,
                IsCompressBackup = row.IsCompressBackup == 1,
                IsShadowMenuButton = row.IsShadowMenuButton == 1,
                IsAlertOnMinimumStock = row.IsAlertOnMinimumStock == 1,
                IsSettingsUpdated = true

            }).FirstOrDefaultAsync() ?? new DashboardPref() { IsSettingsUpdated = false };

            Client client = await context.Clients.Where(col => col.ClientUniqueId == authRequest.ClientUniqueId).FirstAsync();

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
                    Client = new ClientVM()
                    {
                        ClientUniqueId = client.ClientUniqueId,
                        ClientId = client.ClientId,
                        IsPremiumUser = client.IsPremiumUser == 1,
                        IsActivated = client.IsActivated == 1
                    }
                },
                Pref = dashboardPref
            };
        }

       
        
    }
}
