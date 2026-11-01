using Paybill.Models;
using Paybill.ViewModel;

namespace Paybill.Repositories.Service
{
    public class MessageTemplateVM
    {
        public int MessageId { get; set; }
        public string MessageType { get; set; } = "Sales Invoice Message";
        public string MessageDescription { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }

    public interface IAdminRepository
    {
        Task<ResponseMessage> DeleteMessage(int messageId);
        Task<ResponseMessage> DeleteUser(int userRowId);
        Task<IEnumerable<MessageTemplateVM>> GetMessages();
        Task<SettingVM?> GetSettings();
        Task<IEnumerable<UserVM>> GetUsers();
        Task<ResponseMessage> InsMessage(int messageId, string messageDescription, string? messageType = null, bool isSelected = false);
        Task<ResponseMessage> SelectMessageTemplate(int messageId, string messageType);
        Task<ResponseMessage> GetSelectedMessageDescription(string messageType);
        Task<ResponseMessage> UpdateSettings(int userRowId, SettingVM settingVM);

        // Custom Receipt Lines
        Task<List<CustomReceiptLineVM>> GetAllCustomLines();
        Task<List<CustomReceiptLineVM>> GetActiveCustomLines();
        Task<ResponseMessage> UpsertCustomLine(CustomReceiptLineVM line);
        Task<ResponseMessage> UpdateCustomLineActiveStatus(int customLineId, bool isActive);
        Task<ResponseMessage> DeleteCustomLine(int customLineId);
    }
}
