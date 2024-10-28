using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories
{
    public interface IAdminRepository
    {
        Task<SettingVM?> GetSettings();
        Task<ResponseMessage> UpdateSettings(int userRowId, SettingVM settingVM);
    }
}
