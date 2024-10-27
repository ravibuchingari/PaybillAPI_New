namespace PaybillAPI.ViewModel
{
    public class AuthRequestVM
    {
        public string ClientUniqueId { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
