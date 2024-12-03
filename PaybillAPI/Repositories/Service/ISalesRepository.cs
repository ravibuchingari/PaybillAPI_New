using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface ISalesRepository
    {
        Task<ResponseMessage> DeleteSalesInvoice(int salesId);
        Task<ResponseMessage> DeleteSalesItem(int salesItemId, string remarks, int userRowId);
        Task<SalesVM> GetSalesInvoiceDetails(int salesId);
        Task<IEnumerable<SalesVM>> GetSalesInvoices(DateTime fromDate, DateTime toDate);
        Task<PrintSalesInvoice?> GetSalesInvoiceToPrint(int salesId);
        //Task<IEnumerable<MessageTemplate>> GetSalesMessages();
        Task<ResponseMessage> SaveSalesInvoice(SalesVM salesVM, int userRowId);
    }
}
