using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IReportRepository
    {
        Task<List<GSTReturnDetailed>> GetGSTReturnDetailed(DateTime fromDate, DateTime toDate);
        Task<List<GSTHSNSummary>> GetGSTHSNSummary(DateTime fromDate, DateTime toDate);
        Task<List<SalesVM>> GetSalesDetails(ReportParam reportParam);
        Task<List<SalesSummary>> GetSalesSummary(ReportParam reportParam);
        Task<List<PurchaseVM>> GetPurchaseDetails(ReportParam reportParam);
        //Task<List<TransactionVM>> GetPartyLedger(ReportParam reportParam);
    }
}
