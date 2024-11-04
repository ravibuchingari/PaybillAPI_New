using PaybillAPI.Models;
using PaybillAPI.ViewModel;
using System.Data;

namespace PaybillAPI.Repositories.Service
{
    public interface IReportRepository
    {
        Task<List<GSTReturnDetailed>> GetGSTReturnDetailed(DateTime fromDate, DateTime toDate);
        Task<List<GSTReturnStatement>> GetGSTReturnStatement(DateTime fromDate, DateTime toDate);
        Task<List<SalesVM>> GetSalesDetails(ReportParam reportParam);
        Task<List<SalesSummary>> GetSalesSummary(ReportParam reportParam);
    }
}
