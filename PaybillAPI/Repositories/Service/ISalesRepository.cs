using PaybillAPI.Models;
using PaybillAPI.ViewModel;
using System.Data;

namespace PaybillAPI.Repositories.Service
{
    public interface ISalesRepository
    {
        Task<ResponseMessage> DeleteSalesInvoice(int salesId);
        Task<ResponseMessage> DeleteSalesItem(int salesItemId, string remarks, int userRowId);
        Task<PrintHeader> GetPrintHeader();
        Task<SalesVM> GetSalesInvoiceDetails(int salesId);
        Task<IEnumerable<SalesVM>> GetSalesInvoices(DateTime fromDate, DateTime toDate);
        Task<ResponseMessage> SaveSalesInvoice(SalesVM salesVM, int userRowId);
    }
}
