namespace PaybillWinApp.Repositories
{
    public interface ICommonRepository
    {
        Task<string> PingServer();
    }
}
