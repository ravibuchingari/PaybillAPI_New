using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Models
{
    public class UserVM
    {
        public int UserRowId { get; set; }
        public string UserId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string? JwtToken { get; set; }
        public string? SecurityKey { get; set; }
        public string? SaltKey { get; set; }
        public string? BiometricAuthKey { get; set; }
        public ClientVM? Client { get; set; }
    }
}
