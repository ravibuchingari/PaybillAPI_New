using PaybillAPI.ViewModel;

namespace PaybillAPI.Models
{
    public class UserParam
    {
        public int UserRowId { get; set; }
        public string SecurityKey { get; set; } = null!;
        public string ClientUniqueId { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public string? remarks { get; set; } = string.Empty;
        public SettingVM? SettingModel { get; set; }
        public CategoryVM? CategoryModel { get; set; }
        public GstVM? GstModel { get; set; }
        public ItemVM? ItemModel { get; set; }
        public PartyVM? PartyModel { get; set; }
        public PurchaseVM? PurchaseModel { get; set; }
        public SalesVM? SalesModel { get; set; }
        public TransactionVM? TransactionModel { get; set; }
    }
}
