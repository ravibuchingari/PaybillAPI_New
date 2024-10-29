using PaybillAPI.Data;
using PaybillAPI.Repositories.Service;

namespace PaybillAPI.Repositories
{
    public class TransactionRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), ITransactionRepository
    {
    }
}
