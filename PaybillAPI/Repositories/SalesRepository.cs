using PaybillAPI.Data;
using PaybillAPI.Repositories.Service;

namespace PaybillAPI.Repositories
{
    public class SalesRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), ISalesRepository
    {
    }
}
