namespace Paybill.ViewModel
{

    public class UserVM
    {
        public int UserRowId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; } = true;
        public string? JwtToken { get; set; }
        public string? SecurityKey { get; set; }
        public string? SaltKey { get; set; }
        public string? BiometricAuthKey { get; set; }
        public ClientVM? Client { get; set; }
        public string FullName => $"{FirstName} {LastName}".Trim();
    }

    //public class UserVM
    //{
    //    public int UserRowId { get; set; }
    //    public string UserId { get; set; } = null!;
    //    public string Password { get; set; } = null!;
    //    public string FirstName { get; set; } = null!;
    //    public string LastName { get; set; } = null!;
    //    public string Address { get; set; } = null!;
    //    public string Mobile { get; set; } = null!;
    //    public bool IsAdmin { get; set; }
    //    public bool IsActive { get; set; }
    //    public string? JwtToken { get; set; }
    //    public string? SecurityKey { get; set; }
    //    public string? SaltKey { get; set; }
    //    public string? BiometricAuthKey { get; set; }
    //    public ClientVM? Client { get; set; }

    //}
}
