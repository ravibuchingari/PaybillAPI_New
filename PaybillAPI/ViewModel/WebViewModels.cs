using Paybill.Models;

namespace Paybill.ViewModel
{
    public class LoginViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ClientUniqueId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = "PayBill POS & ERP";
        public string BusinessType { get; set; } = "Complete Business Management Suite";
        public bool IsConfigured { get; set; } = true;
        public string? ReturnUrl { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class SetupAccountViewModel
    {
        public string ClientName { get; set; } = string.Empty;
        public string BusinessType { get; set; } = "Supermarket / Retail";
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string AdminUserId { get; set; } = "admin";
        public string AdminFirstName { get; set; } = string.Empty;
        public string AdminLastName { get; set; } = string.Empty;
        public string AdminPassword { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; }
    }

    public class DashboardViewModel
    {
        public DashboardSalesSummaryResponse SalesSummary { get; set; } = new();
        public double TotalCustomerReceivables { get; set; }
        public double TotalVendorPayables { get; set; }
        public double TotalInventoryPurchaseValue { get; set; }
        public double TotalInventorySalesValue { get; set; }
        public int TotalActiveItemsCount { get; set; }
        public double TodayPaymentsOut { get; set; }
        public double TodayReceiptsIn { get; set; }
        public double MonthlyPurchaseTotal { get; set; }
        public int MonthlyPurchaseCount { get; set; }
        public List<ItemVM> LowStockItems { get; set; } = [];
        public List<SalesVM> RecentSales { get; set; } = [];
        public List<PurchaseVM> RecentPurchases { get; set; } = [];
        public List<JobCardVM> ActiveJobCards { get; set; } = [];
        public List<UnlockRequestVM> PendingUnlockRequests { get; set; } = [];
        public List<ChartData> DayWiseSalesChart { get; set; } = [];
        public List<ChartData> MonthWiseSalesChart { get; set; } = [];
        public List<ChartData> ItemWiseSalesChart { get; set; } = [];
        public List<ChartData> PaymentModeChart { get; set; } = [];
    }

    public class SalesInvoicePageViewModel
    {
        public SalesVM Invoice { get; set; } = new();
        public SettingVM Settings { get; set; } = new();
        public List<PartyVM> Customers { get; set; } = [];
        public List<CategoryVM> Categories { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public List<ServiceTypeVM> ServiceTypes { get; set; } = [];
        public List<ItemVM> InitialItems { get; set; } = [];
        public string CompanyGstin { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string? PendingUnlockMessage { get; set; }
    }

    public class SalesPrintViewModel
    {
        public PrintSalesInvoice Invoice { get; set; } = new();
        public SalesVM? RawInvoice { get; set; }
        public PrintHeader Header { get; set; } = new();
        public SettingVM Settings { get; set; } = new();
        public List<CustomReceiptLineVM> CustomLines { get; set; } = [];
        public string Format { get; set; } = "A4";
        public string AmountInWords { get; set; } = string.Empty;
        public string WhatsAppMessage { get; set; } = string.Empty;
    }

    public class PurchaseInvoicePageViewModel
    {
        public PurchaseVM Purchase { get; set; } = new();
        public SettingVM Settings { get; set; } = new();
        public List<PartyVM> Vendors { get; set; } = [];
        public List<PurchaseOrderVM> ActivePurchaseOrders { get; set; } = [];
        public List<CategoryVM> Categories { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public List<ItemVM> InitialItems { get; set; } = [];
        public string CompanyGstin { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public string? PendingUnlockMessage { get; set; }
    }

    public class PurchaseOrderPageViewModel
    {
        public PurchaseOrderVM Order { get; set; } = new();
        public List<PartyVM> Vendors { get; set; } = [];
        public List<ItemVM> InitialItems { get; set; } = [];
        public PrintHeader Header { get; set; } = new();
    }

    public class JobCardPageViewModel
    {
        public JobCardVM JobCard { get; set; } = new();
        public string NextJobCardNumber { get; set; } = "1";
        public List<PartyVM> Customers { get; set; } = [];
        public List<ServiceTypeVM> ServiceTypes { get; set; } = [];
        public List<ItemVM> Items { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public PrintHeader Header { get; set; } = new();
        public string CompanyGstin { get; set; } = string.Empty;
    }

    public class InventoryPageViewModel
    {
        public List<ItemVM> Items { get; set; } = [];
        public List<CategoryVM> Categories { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public List<ServiceTypeVM> ServiceTypes { get; set; } = [];
        public List<ItemVM> MinStockItems { get; set; } = [];
        public int SelectedCategoryId { get; set; }
        public string? SearchFilter { get; set; }
        public string ActiveTab { get; set; } = "items";
    }

    public class PartyPageViewModel
    {
        public List<PartyVM> Parties { get; set; } = [];
        public Dictionary<int, BalanceSheet> BalanceMap { get; set; } = new();
        public bool IsVendor { get; set; }
    }

    public class TransactionPageViewModel
    {
        public List<TransactionVM> Transactions { get; set; } = [];
        public List<PartyVM> Parties { get; set; } = [];
        public bool IsPayment { get; set; }
        public int FilterMode { get; set; }
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
        public PrintHeader Header { get; set; } = new();
    }

    public class RewardsDashboardViewModel
    {
        public SettingVM Settings { get; set; } = new();
        public RewardOverallSummaryVM OverallSummary { get; set; } = new();
        public List<RewardCustomerSummaryVM> CustomerSummaries { get; set; } = [];
        public List<RewardTransactionVM> Transactions { get; set; } = [];
        public List<RewardRedemptionDetailVM> Redemptions { get; set; } = [];
        public List<PartyVM> Customers { get; set; } = [];
        public string ActiveTab { get; set; } = "summary";
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? SearchQuery { get; set; }
        public int? SelectedPartyId { get; set; }
    }

    public class SettingsPageViewModel
    {
        public SettingVM Settings { get; set; } = new();
        public ClientVM ClientProfile { get; set; } = new();
        public List<UserVM> Users { get; set; } = [];
        public List<MessageTemplateVM> MessageTemplates { get; set; } = [];
        public List<CustomReceiptLineVM> CustomReceiptLines { get; set; } = [];
        public List<UnlockRequestVM> UnlockRequests { get; set; } = [];
        public string ActiveTab { get; set; } = "company";
        public bool IsAdmin { get; set; }
    }

    public class MasterHubViewModel
    {
        public int CategoriesCount { get; set; }
        public int GstSlabsCount { get; set; }
        public int ItemsCount { get; set; }
        public int LowStockCount { get; set; }
        public int CustomersCount { get; set; }
        public int VendorsCount { get; set; }
        public int UsersCount { get; set; }
        public int ServiceTypesCount { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class CategoryMasterViewModel
    {
        public CategoryVM EditCategory { get; set; } = new();
        public List<CategoryVM> Categories { get; set; } = [];
        public string? SearchFilter { get; set; }
    }

    public class GstMasterViewModel
    {
        public GstVM EditGst { get; set; } = new() { IsActive = true };
        public List<GstVM> GstSlabs { get; set; } = [];
        public string? SearchFilter { get; set; }
    }

    public class ItemMasterPageViewModel
    {
        public ItemVM Item { get; set; } = new() { IsActive = true, Measure = "Piece" };
        public List<CategoryVM> Categories { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
        public bool HasExistingImage { get; set; }
        public string ExistingImageUrl { get; set; } = string.Empty;
        public string LocalLanguageCode { get; set; } = "te";
    }

    public class PartyMasterPageViewModel
    {
        public PartyVM Party { get; set; } = new() { IsActive = true };
        public bool IsEditMode => Party.PartyId > 0;
        public SettingVM Settings { get; set; } = new();
        public RewardCustomerSummaryVM? RewardsSummary { get; set; }
        public double AvailableRewardPoints { get; set; }
        public double RewardPointMonetaryValue { get; set; }
        public List<RewardTransactionVM> RewardTransactions { get; set; } = [];
        public int TotalCustomersCount { get; set; }
        public int TotalVendorsCount { get; set; }
    }

    public class UserMasterPageViewModel
    {
        public UserVM EditUser { get; set; } = new() { IsActive = true };
        public List<UserVM> Users { get; set; } = [];
        public bool IsAdmin { get; set; }
    }

    public class ServiceTypeMasterViewModel
    {
        public ServiceTypeVM EditServiceType { get; set; } = new() { IsActive = true };
        public List<ServiceTypeVM> ServiceTypes { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
    }

    public class ImportDataPageViewModel
    {
        public int ExistingItemsCount { get; set; }
        public int ExistingCategoriesCount { get; set; }
        public List<CategoryVM> Categories { get; set; } = [];
        public List<GstVM> GstSlabs { get; set; } = [];
    }
}

