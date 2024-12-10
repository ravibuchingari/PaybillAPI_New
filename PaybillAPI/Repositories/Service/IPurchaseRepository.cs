using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IPurchaseRepository
    {
        Task<ResponseMessage> DeletePurchaseInvoice(int purchaseId);
        Task<ResponseMessage> DeletePurchaseItem(int purchaseItemId, string remarks, int userRowId);
        Task<PurchaseVM> GetPurchaseInvoiceDetails(int purchaseId);
        Task<IEnumerable<PurchaseVM>> GetPurchaseInvoices(DateTime fromDate, DateTime toDate);
        Task<ResponseMessage> UpsertPurchase(PurchaseVM purchaseVM, int userRowId);
        Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderItems(int purchaseOrderId);
    }
}
