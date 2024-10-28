using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;

namespace PaybillAPI.Repositories
{
    public class ItemRepository(AppDBContext context) : RootRepository(context ?? null), IItemRepository
    {
       
    }
}
