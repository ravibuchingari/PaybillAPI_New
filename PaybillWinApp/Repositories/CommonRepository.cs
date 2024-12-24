using PaybillWinApp.Models;

namespace PaybillWinApp.Repositories
{
    public class CommonRepository : BaseRepository, ICommonRepository
    {
        public async Task<string> TestServer() => await GetApiDataAsync(Controller.Home.ToString(), "server/test");

        public async Task<AuthenticationResponse> Authenticate(AuthRequestVM authRequest) => await PostApiDataAsync<AuthenticationResponse>(Controller.Home.ToString(), "authenticate", authRequest);
    }
}
