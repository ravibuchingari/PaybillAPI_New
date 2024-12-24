using PaybillWinApp.Models;

namespace PaybillWinApp.Repositories
{
    public interface ICommonRepository
    {
        Task<AuthenticationResponse> Authenticate(AuthRequestVM authRequest);
        Task<string> TestServer();
    }
}
