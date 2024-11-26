using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IAdminRepository
    {
        Task<ResponseMessage> DeleteMessage(int messageId);
        Task<ResponseMessage> DeleteUser(int userRowId);
        Task<IEnumerable<MessageTemplate>> GetMessages();
        Task<SettingVM?> GetSettings();
        Task<IEnumerable<UserVM>> GetUsers();
        Task<ResponseMessage> InsMessage(string messageDescription);
        Task<ResponseMessage> UpdateSettings(int userRowId, SettingVM settingVM);
    }
}
