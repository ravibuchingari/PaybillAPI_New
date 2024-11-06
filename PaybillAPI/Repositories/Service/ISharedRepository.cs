using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface ISharedRepository
    {
        Task<string> CheckDatabase();
        Task<string> CreateAccountIfNotExists(ClientVM client);
        Task<string> CreateUserIfNotExists(UserVM userVM);
        Task<IEnumerable<UserVM>> GetUsers();
        Task<bool> IsValidAccount(string ClientUniqueId, string clientId);
        Task<bool> IsValidUser(int userRowId, string securityKey, int identityId);
        Task<bool> IsValidAdminUser(int userRowId, string securityKey, int identityId);
        Task<ResponseMessage> UpdateProfile(ClientVM clientVM);
        Task<PrintHeader> GetPrintHeader();
        Task<AuthResponseVM> UserAuthentication(AuthRequestVM authRequest);
        Task<ResponseMessage> ChangePassword(int userRowId, string oldPassword, string newPassword);
        Task<ResponseMessage> UpsertUser(UserVM userVM, int userRowId);
    }
}
