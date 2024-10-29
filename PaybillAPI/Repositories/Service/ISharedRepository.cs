using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface ISharedRepository
    {
        Task<string> CreateAccountIfNotExists(ClientVM client);
        Task<string> CreateUserIfNotExists(UserVM userVM);
        Task<IEnumerable<UserVM>> GetUsers();
        Task<bool> IsValidAccount(string ClientUniqueId, string clientId);
        Task<bool> IsValidUser(int userRowId, string securityKey);
        Task<ResponseMessage> UpdateProfile(ClientVM clientVM);
        Task<AuthResponseVM> UserAuthentication(AuthRequestVM authRequest);
    }
}
