using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.ViewModel;
using System.Collections;
using System.Collections.Immutable;

namespace PaybillAPI.Repositories
{
    public class SharedRepository(ILogger<SharedRepository> logger, AppDBContext dbContext) : ISharedRepository
    {
        private static void DetachedEntries(DbUpdateException ex)
        {
            foreach (var entry in ex.Entries)
                entry.State = EntityState.Detached;
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                DetachedEntries(ex);
                logger.LogError(ex.InnerException != null ? ex.InnerException : ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                SharedMethod.ThrowError(ex);
            }
        }

        public async Task<bool> IsValidAccount(string ClientUniqueId, string clientId)
        {
            return await dbContext.Clients.Where(col => col.ClientUniqueId == ClientUniqueId && col.ClientId == clientId).AnyAsync();
        }

        public async Task<string> CreateUserIfNotExists(UserVM userVM)
        {
            User? user = await dbContext.Users.Where(col => col.UserId == userVM.UserId).FirstOrDefaultAsync();
            if (user != null)
            {
                await dbContext.Users.AddAsync(new User()
                {
                    UserId = userVM.UserId,
                    Password = userVM.Password,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    Address = userVM.Address,
                    Mobile = userVM.Mobile,
                    IsAdmin = (sbyte)userVM.IsAdmin.GetHashCode(),
                    IsActive = (sbyte)userVM.IsActive.GetHashCode(),
                });
                await SaveChangesAsync();
                return AppConstants.SUCCESS;
            }
            else
                return "User account has already been created with the same Id.";
        }

        public async Task<string> CreateAccountIfNotExists(ClientVM clientVM)
        {
            Client? client = await dbContext.Clients.Where(col => col.ClientUniqueId == clientVM.ClientUniqueId).FirstOrDefaultAsync();
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
                    SecurityKey = SharedMethod.GenerateUniqueID()
                };
                await dbContext.Clients.AddAsync(client);
                await SaveChangesAsync();
                clientVM.SecurityKey = client.SecurityKey;
                return AppConstants.SUCCESS;
            }
            else
                return AppConstants.SUCCESS;
        }

        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            return await dbContext.Users.Select(row => new UserVM { 
                UserId = row.UserId,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Mobile = row.Mobile,
                IsAdmin = row.IsAdmin == 1,
                IsActive = row.IsActive == 1
            }).OrderBy(ord => ord.FirstName).ToListAsync();
        }

        public async Task UserAuthentication(AuthRequestVM authRequest)
        {
            
        }
    }
}
