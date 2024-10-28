using PaybillAPI.ViewModel;

namespace PaybillAPI.Models
{
    public class UserParam
    {
        public int UserRowId { get; set; }
        public string SecurityKey { get; set; } = null!;
        public string ClientUniqueId { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public SettingVM? Setting { get; set; }
    }
}
