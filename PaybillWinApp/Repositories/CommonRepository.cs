using PaybillWinApp.Models;

namespace PaybillWinApp.Repositories
{
    public class CommonRepository : BaseRepository, ICommonRepository
    {
        public async Task<string> TestServer() => await GetApiDataAsync(Controller.Home.ToString(), "server/test");

        public async Task<AuthResponseVM> Authenticate(AuthRequestVM authRequest) => await PostApiDataAsync<AuthResponseVM>(Controller.Home.ToString(), "authenticate", authRequest);
    }
}
