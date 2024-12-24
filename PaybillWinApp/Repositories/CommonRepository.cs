namespace PaybillWinApp.Repositories
{
    public class CommonRepository : BaseRepository, ICommonRepository
    {
        public async Task<string> PingServer()
        {
            return await GetApiDataAsync("server/test");
        }

    }
}
