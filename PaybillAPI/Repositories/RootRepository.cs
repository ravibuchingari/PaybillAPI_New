using Microsoft.EntityFrameworkCore;
using Paybill.Data;
using Paybill.Models;

namespace Paybill.Repositories
{
    public class RootRepository(AppDBContext? dbContext)
    {
        public void DetachedEntries(DbUpdateException ex)
        {
            foreach (var entry in ex.Entries)
                entry.State = EntityState.Detached;
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                if (dbContext != null)
                    await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                DetachedEntries(ex);
                SharedMethod.ThrowError(ex);
            }
        }
    }
}
