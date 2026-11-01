using Paybill.Models;
using Paybill.ViewModel;

namespace Paybill.Repositories.Service
{
    public interface ISalesRepository
    {
        Task<ResponseMessage> DeleteSalesInvoice(int salesId, int userRowId = 1);
        Task<ResponseMessage> DeleteSalesItem(int salesItemId, string remarks, int userRowId);
        Task<SalesVM> GetSalesInvoiceDetails(int salesId);
        Task<IEnumerable<SalesVM>> GetSalesInvoices(DateTime fromDate, DateTime toDate);
        Task<PrintSalesInvoice?> GetSalesInvoiceToPrint(int salesId);
        Task<ResponseMessage> SaveSalesInvoice(SalesVM salesVM, int userRowId);
        Task<DashboardSalesSummaryResponse> GetDashboardSalesSummary();

        // Job Cards / Service Requests
        Task<ResponseMessage> CreateJobCard(JobCardVM serviceRequest, int userRowId);
        Task<List<JobCardVM>> GetActiveJobCards();
        Task<JobCardVM?> GetJobCardDetails(int serviceRequestId);
        Task<ResponseMessage> GetNextJobCardNumber();
        Task<ResponseMessage> DeleteJobCard(int serviceRequestId);
        Task<ResponseMessage> DeleteJobCardItem(int serviceRequestComplaintId);
        Task<ResponseMessage> DeleteJobCardSpare(int jobCardSpareId);
        Task<ResponseMessage> UpdateJobCardStatus(int serviceRequestId, int statusId);
        Task<ResponseMessage> GenerateOrGetSalesInvoiceForJobCard(int jobCardId, int userRowId);
        Task<SalesVM> GetJobCardSalesInvoice(int jobCardId);
    }
}
