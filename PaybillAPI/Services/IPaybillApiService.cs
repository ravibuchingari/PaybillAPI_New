using Paybill.Areas.Paybill.Models;
using Paybill.ViewModel;

namespace Paybill.Services
{
    public interface IPaybillApiService
    {
        UserParam GetCurrentUserParam();
        int GetCurrentUserRowId();
        string GetCurrentCompanyName();
        string GetCurrentCompanyGstin();
        bool IsAdminUser();

        // Home & Auth
        Task<ClientVM?> GetClientInfoAsync();
        Task<ResponseMessage> CreateAccountAsync(ClientVM client);
        Task<ResponseMessage> CreateInitialUserAsync(UserVM user, string tempJwtToken);
        Task<AuthResponseVM> AuthenticateAsync(AuthRequestVM request);

        // Admin & Settings & Common
        Task<SettingVM> GetSettingsAsync();
        Task<ResponseMessage> UpdateSettingsAsync(SettingVM setting);
        Task<ResponseMessage> UpdateClientProfileAsync(ClientVM client);
        Task<PrintHeader> GetPrintHeaderAsync();
        Task<List<UserVM>> GetUsersAsync();
        Task<ResponseMessage> UpsertUserAsync(UserVM user);
        Task<ResponseMessage> DeleteUserAsync(int targetUserRowId);
        Task<ResponseMessage> ChangePasswordAsync(string oldPassword, string newPassword);

        // Unlock Requests
        Task<ResponseMessage> InsertUnlockRequestAsync(UnlockRequestVM request);
        Task<ResponseMessage> CheckUnlockRequestStatusAsync(int? salesId, int? purchaseId);
        Task<List<UnlockRequestVM>> GetUnlockRequestsAsync();
        Task<ResponseMessage> UpdateUnlockRequestAsync(int unlockRequestId, bool isApproved, string remarks);

        // Message Templates & Custom Receipt Lines
        Task<List<MessageTemplateVM>> GetMessagesAsync();
        Task<ResponseMessage> SaveMessageTemplateAsync(string messageId, string description, string? messageType, bool isSelected);
        Task<ResponseMessage> SelectMessageTemplateAsync(int messageId, string messageType);
        Task<ResponseMessage> GetSelectedMessageAsync(string messageType);
        Task<ResponseMessage> DeleteMessageTemplateAsync(int messageId);
        Task<List<CustomReceiptLineVM>> GetAllCustomReceiptLinesAsync();
        Task<List<CustomReceiptLineVM>> GetActiveCustomReceiptLinesAsync();
        Task<ResponseMessage> UpsertCustomReceiptLineAsync(CustomReceiptLineVM line);
        Task<ResponseMessage> UpdateCustomReceiptLineStatusAsync(int customLineId, bool isActive);
        Task<ResponseMessage> DeleteCustomReceiptLineAsync(int customLineId);

        // Inventory: Categories, GST, Service Types, Items
        Task<List<CategoryVM>> GetCategoriesAsync();
        Task<CategoryVM?> GetCategoryDetailsAsync(int categoryId);
        Task<ResponseMessage> UpsertCategoryAsync(CategoryVM category);
        Task<ResponseMessage> CreateCategoryIfNotExistsAsync(string categoryName);
        Task<ResponseMessage> DeleteCategoryAsync(int categoryId);
        Task<List<CategoryVM>> GetCategoriesWithItemCountAsync();

        Task<List<GstVM>> GetGstListAsync(bool isActiveOnly = false);
        Task<GstVM?> GetGstDetailsAsync(int gstId);
        Task<ResponseMessage> UpsertGstAsync(GstVM gst);
        Task<ResponseMessage> CreateGstIfNotExistsAsync(GstVM gst);
        Task<ResponseMessage> DeleteGstAsync(int gstId);

        Task<List<ServiceTypeVM>> GetServiceTypesAsync(bool isAll = true);
        Task<ServiceTypeVM?> GetServiceTypeDetailsAsync(int serviceTypeId);
        Task<ResponseMessage> UpsertServiceTypeAsync(ServiceTypeVM serviceType);
        Task<ResponseMessage> DeleteServiceTypeAsync(int serviceTypeId);

        Task<List<ItemVM>> GetItemsAsync(int categoryId = 0, string? filter = null);
        Task<List<ItemVM>> GetAllItemsOfflineAsync(bool isAllItems = true);
        Task<List<ItemVM>> SearchItemsAsync(string? filter);
        Task<List<ItemVM>> GetItemsByCodeAsync(string itemCode);
        Task<ItemVM?> GetItemDetailsAsync(int itemId);
        Task<ResponseMessage> UpsertItemAsync(ItemVM item);
        Task<ResponseMessage> DeleteItemAsync(int itemId);
        Task<ResponseMessage> UploadItemsBulkAsync(List<ItemVM> items);
        Task<List<ItemVM>> GetMinStockItemsAsync();
        Task<ResponseMessage> ResetStockAsync();

        // Parties & Rewards
        Task<List<PartyVM>> GetPartiesAsync(bool isVendor);
        Task<List<PartyVM>> GetActivePartiesAsync(bool isVendor, bool isAll = false);
        Task<PartyVM?> GetPartyDetailsAsync(int partyId);
        Task<ResponseMessage> UpsertPartyAsync(PartyVM party);
        Task<ResponseMessage> DeletePartyAsync(int partyId, bool isVendor);

        Task<double> GetCustomerAvailablePointsAsync(int partyId);
        Task<RewardCustomerSummaryVM?> GetCustomerRewardsSummaryAsync(int partyId);
        Task<string> GetCustomerEarliestExpiryDateAsync(int partyId);
        Task<List<RewardTransactionVM>> GetRewardsTransactionsAsync(int? partyId = null, int? salesId = null, string? fromDate = null, string? toDate = null, string? transType = null, string? searchQuery = null);
        Task<ResponseMessage> SaveManualRewardAdjustmentAsync(int partyId, double points, string reason);
        Task<List<RewardCustomerSummaryVM>> GetAllCustomerRewardsSummaryAsync(string? fromDate = null, string? toDate = null, string? searchQuery = null);
        Task<RewardOverallSummaryVM> GetOverallRewardsSummaryAsync();
        Task<ResponseMessage> ExpireOldPointsAsync();
        Task<List<RewardRedemptionDetailVM>> GetRedemptionDetailsAsync(string? specificDate = null, string? fromDate = null, string? toDate = null, string? searchQuery = null, string? filterInvoiceNo = null);

        // Sales & Job Cards
        Task<DashboardSalesSummaryResponse> GetDashboardSalesSummaryAsync();
        Task<ResponseMessage> SaveSalesInvoiceAsync(SalesVM sales);
        Task<List<SalesVM>> GetSalesInvoicesAsync(string fromDate, string toDate);
        Task<SalesVM?> GetSalesInvoiceDetailsAsync(int salesId);
        Task<ResponseMessage> DeleteSalesItemAsync(int salesItemId, string remarks);
        Task<ResponseMessage> DeleteSalesInvoiceAsync(int salesId);
        Task<PrintSalesInvoice?> GetSalesInvoiceToPrintAsync(int salesId);

        Task<string> GetNextJobCardNumberAsync();
        Task<ResponseMessage> SaveJobCardAsync(JobCardVM jobCard);
        Task<List<JobCardVM>> GetActiveJobCardsAsync();
        Task<JobCardVM?> GetJobCardDetailsAsync(int serviceRequestId);
        Task<ResponseMessage> DeleteJobCardAsync(int serviceRequestId);
        Task<ResponseMessage> DeleteJobCardItemAsync(int complaintId);
        Task<ResponseMessage> DeleteJobCardSpareAsync(int spareId);
        Task<ResponseMessage> UpdateJobCardStatusAsync(int serviceRequestId, int statusId);
        Task<ResponseMessage> GenerateJobCardInvoiceAsync(int jobCardId);
        Task<SalesVM?> GetJobCardSalesInvoiceAsync(int jobCardId);

        // Purchases & Purchase Orders
        Task<ResponseMessage> UpsertPurchaseAsync(PurchaseVM purchase);
        Task<List<PurchaseVM>> GetPurchaseInvoicesAsync(string fromDate, string toDate);
        Task<PurchaseVM?> GetPurchaseInvoiceDetailsAsync(int purchaseId);
        Task<ResponseMessage> DeletePurchaseItemAsync(int purchaseItemId, string remarks);
        Task<ResponseMessage> DeletePurchaseInvoiceAsync(int purchaseId);
        Task<List<PurchaseItemVM>> GetPurchaseOrderItemsForPurchaseAsync(int purchaseOrderId);

        Task<ResponseMessage> UpsertPurchaseOrderAsync(PurchaseOrderVM order);
        Task<PurchaseOrderVM?> GetPurchaseOrderDetailsAsync(int purchaseOrderId);
        Task<List<PurchaseOrderVM>> GetActivePurchaseOrdersAsync();
        Task<ResponseMessage> DeletePurchaseOrderItemAsync(int purchaseOrderItemId);
        Task<ResponseMessage> DeletePurchaseOrderAsync(int purchaseOrderId);

        // Transactions
        Task<ResponseMessage> InsertTransactionAsync(TransactionVM transaction);
        Task<ResponseMessage> DeleteTransactionAsync(int transactionId, string remarks);
        Task<List<TransactionVM>> GetTodayTransactionsAsync(bool isPayment);
        Task<List<TransactionVM>> GetTransactionsAsync(string fromDate, string toDate, int isPayment);

        // Reports
        Task<List<GSTReturnDetailed>> GetGSTReturnDetailedAsync(string fromDate, string toDate, string? returnType = null);
        Task<List<GSTHSNSummary>> GetGSTHSNSummaryAsync(string fromDate, string toDate);
        Task<List<GSTHSNSummary>> GetGSTSACSummaryAsync(string fromDate, string toDate);
        Task<List<SalesVM>> GetSalesDetailsReportAsync(ReportParam param);
        Task<byte[]?> DownloadSalesDetailsExcelAsync(ReportParam param);
        Task<List<SalesSummary>> GetSalesSummaryReportAsync(ReportParam param);
        Task<byte[]?> DownloadSalesSummaryExcelAsync(ReportParam param);
        Task<List<PurchaseVM>> GetPurchaseDetailsReportAsync(ReportParam param);
        Task<List<TransactionVM>> GetPartyLedgerAsync(int partyId, string fromDate, string toDate);
        Task<List<BalanceSheet>> GetBalanceSheetAsync();
        Task<List<TransactionVM>> GetDaybookAsync(string fromDate, string toDate);
        Task<List<SalesItemVM>> GetDeletedSalesItemsAsync(string fromDate, string toDate);
        Task<List<PurchaseItemVM>> GetDeletedPurchaseItemsAsync(string fromDate, string toDate);
        Task<List<PurchaseOrderVM>> GetPurchaseOrderReportListAsync();
        Task<List<InventoryValuation>> GetInventoryValuationAsync(string? filter = null);
        Task<List<ItemVM>> GetAgedInventoryAsync(int inventoryAge);
        Task<List<ProductMovementModel>> GetProductMovementAnalysisAsync(string fromDate, string toDate);
        Task<List<ChartData>> GetDayWiseSalesChartAsync(string fromDate, string toDate);
        Task<List<ChartData>> GetMonthWiseSalesChartAsync(string fromDate, string toDate);
        Task<List<ChartData>> GetItemWiseSalesChartAsync(string fromDate, string toDate);
        Task<List<ChartData>> GetPaymentModeChartAsync(string fromDate, string toDate);
    }
}


