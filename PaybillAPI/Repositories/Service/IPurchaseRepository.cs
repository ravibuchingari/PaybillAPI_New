using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IPurchaseRepository
    {
        Task<ResponseMessage> UpsertPurchase(PurchaseVM purchaseVM, int userRowId);
    }
}
