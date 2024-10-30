using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories
{
    public class PurchaseRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), IPurchaseRepository
    {
        public async Task<ResponseMessage> UpsertPurchase(PurchaseVM purchaseVM, int userRowId)
        {
            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                Purchase? purchase;
                if (purchaseVM.PurchaseId > 0)
                {
                    purchase = await dbContext.Purchases.Where(col => col.PurchaseId == purchaseVM.PurchaseId).FirstOrDefaultAsync();
                    if (purchase == null)
                        return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Purchase invoice"));
                }
                else
                    purchase = new Purchase();

                purchase.PartyId = purchaseVM.PartyModel.PartyId;
                purchase.InvoiceNo = purchaseVM.InvoiceNo;
                purchase.InvoiceDate = purchaseVM.InvoiceDate;
                purchase.PurchaseType = purchaseVM.PurchaseType;
                purchase.Remarks = purchaseVM.Remarks;
                purchase.UpdatedDate = DateTime.Now;
                purchase.UpdatedBy = userRowId;

                if (purchaseVM.PurchaseId == 0)
                {
                    purchase.CreatedDate = DateTime.Now;
                    purchase.CreatedBy = userRowId;
                    await dbContext.Purchases.AddAsync(purchase);
                }
                
                await SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (DbUpdateException ex)
            {
                await transaction.RollbackAsync();
                DetachedEntries(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }

            return new ResponseMessage(isSuccess: true, message: "");
        }

    }
}
