using PaybillAPI.Data;
using PaybillAPI.Repositories.Service;

namespace PaybillAPI.Repositories
{
    public class PurchaseRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), IPurchaseRepository
    {
    }
}
