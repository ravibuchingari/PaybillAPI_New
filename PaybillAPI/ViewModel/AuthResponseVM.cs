using Paybill.Models;
using Paybill.Repositories.Service;

namespace Paybill.ViewModel
{
    public class AuthResponseVM
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsBiometricAuthentication { get; set; }
        public UserVM User { get; set; } = null!;
        public DashboardPref Pref { get; set; } = null!;
        public IEnumerable<MessageTemplateVM>? MessageTemplates { get; set; }
    }
}
