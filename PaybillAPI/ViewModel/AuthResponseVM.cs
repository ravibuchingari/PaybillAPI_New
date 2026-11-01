using Paybill.Models;

namespace Paybill.ViewModel
{
    public class AuthResponseVM
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsBiometricAuthentication { get; set; }
        public UserVM User { get; set; } = new();
        public DashboardPref Pref { get; set; } = new();
        public IEnumerable<MessageTemplateVM>? MessageTemplates { get; set; }
    }
}
