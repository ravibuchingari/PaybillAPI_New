using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaybillAPI.ViewModel
{
    public class UserVM
    {
        public int UserRowId { get; set; }
        public string UserId { get; set; } = null!;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string JwtToken { get; set; } = null!;
        public string SecurityKey { get; set; } = null!;
        public ClientVM Client { get; set; } = null!;

    }
}
