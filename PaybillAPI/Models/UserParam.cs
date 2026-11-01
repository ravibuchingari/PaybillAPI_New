using Paybill.ViewModel;

namespace Paybill.Models
{
    public class UserParam
    {
        public int UserRowId { get; set; }
        public string SecurityKey { get; set; } = string.Empty;
        public string ClientUniqueId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string? remarks { get; set; } = string.Empty;
        public SettingVM? SettingModel { get; set; }
        public CategoryVM? CategoryModel { get; set; }
        public GstVM? GstModel { get; set; }
        public ItemVM? ItemModel { get; set; }
        public ServiceTypeVM? ServiceTypeModel { get; set; }
        public PartyVM? PartyModel { get; set; }
        public PurchaseVM? PurchaseModel { get; set; }
        public SalesVM? SalesModel { get; set; }
        public TransactionVM? TransactionModel { get; set; }
        public UserVM? UserModel { get; set; }
        public PurchaseOrderVM? PurchaseOrderModel { get; set; }
        public JobCardVM? JobCardModel { get; set; }
        public CustomReceiptLineVM? CustomReceiptLineModel { get; set; }
    }
}
