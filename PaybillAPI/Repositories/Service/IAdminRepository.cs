using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IAdminRepository
    {
        Task<ResponseMessage> DeleteUser(int userRowId);
        Task<SettingVM?> GetSettings();
        Task<IEnumerable<UserVM>> GetUsers();
        Task<ResponseMessage> UpdateSettings(int userRowId, SettingVM settingVM);
    }
}
