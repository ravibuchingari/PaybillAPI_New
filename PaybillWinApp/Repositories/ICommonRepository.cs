using PaybillWinApp.Models;

namespace PaybillWinApp.Repositories
{
    public interface ICommonRepository
    {
        Task<AuthResponseVM> Authenticate(AuthRequestVM authRequest);
        Task<string> TestServer();
    }
}
