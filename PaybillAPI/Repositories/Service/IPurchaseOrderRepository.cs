using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IPurchaseOrderRepository
    {
        Task<ResponseMessage> DeletePurchaseOrder(int purchaseOrderId);
        Task<ResponseMessage> DeletePurchaseOrderItem(int purchaseOrderItemId);
        Task<IEnumerable<PurchaseOrderVM>> GetPurchaseOrderActiveList();
        Task<PurchaseOrderVM> GetPurchaseOrderDetails(int purchaseOrderId);
        Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderItems(int purchaseOrderId);
        Task<ResponseMessage> UpsertPurchaseOrder(PurchaseOrderVM purchaseOrderVM, int userRowId);
    }
}
