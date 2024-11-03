using PaybillAPI.Models;
using PaybillAPI.ViewModel;
using System.Data;

namespace PaybillAPI.Repositories.Service
{
    public interface IReportRepository
    {
        Task<List<GSTReturnModel>> GetGSTReturns(DateTime fromDate, DateTime toDate);
        Task<DataTable> GetGSTSummary(DateTime fromDate, DateTime toDate);
        Task<List<SalesVM>> GetSalesDetails(ReportParam reportParam);
        Task<List<SalesSummary>> GetSalesSummary(ReportParam reportParam);
    }
}
