using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Models
{
    public class AuthResponseVM
    {
        public bool IsSuccess { get; set; } = false;
        public bool IsBiometricAuthentication { get; set; } = false;
        public UserVM User { get; set; } = null!;
        public DashboardPrefVM Pref { get; set; } = null!;
        public List<MessageTemplateVM>? MessageTemplates { get; set; } = null;
    }
}
