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
            using var dbTrans = await dbContext.Database.BeginTransactionAsync();
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
                double totalPurchaseAmount = 0.0;

                foreach (PurchaseItemVM purchaseItemVM in purchaseVM.PurchaseItems!)
                {
                    totalPurchaseAmount += purchaseItemVM.TotalAmount;
                    await dbContext.PurchaseItems.AddAsync(new PurchaseItem()
                    {
                        PurchaseId = purchase.PurchaseId,
                        ItemId = purchaseItemVM.ItemModel!.ItemId,
                        Quantity = purchaseItemVM.Quantity,
                        Rate = purchaseItemVM.Rate,
                        Amount = purchaseItemVM.Amount,
                        DiscountInRs = purchaseItemVM.DiscountInRs,
                        TaxableAmount = purchaseItemVM.TaxableAmount,
                        CgstPer = purchaseItemVM.CgstPer,
                        SgstPer = purchaseItemVM.SgstPer,
                        IgstPer = purchaseItemVM.IgstPer,
                        GstPer = purchaseItemVM.GstPer,
                        CgstRs = purchaseItemVM.CgstRs,
                        SgstRs = purchaseItemVM.SgstRs,
                        IgstRs = purchaseItemVM.IgstRs,
                        GstAmount = purchaseItemVM.GstAmount,
                        TotalAmount = purchaseItemVM.TotalAmount,
                        CreatedDate = DateTime.Now
                    });
                }

                Transaction? transaction = null;
                bool isNewTransaction = false;

                if (purchaseVM.PurchaseId > 0)
                    transaction = await dbContext.Transactions.Where(col => col.PurchaseId == purchaseVM.PurchaseId).FirstOrDefaultAsync();
                   
                if(transaction == null)
                {
                    isNewTransaction = true;
                    transaction = new Transaction()
                    {
                        PartyId = purchaseVM.PartyModel.PartyId,
                        TransactionDate = DateTime.Now.Date,
                        ReceiptAmount = totalPurchaseAmount,
                        PaymentMode = purchaseVM.PaymentMode,
                        UpiType = purchaseVM.UpiType,
                        Remarks = purchaseVM.Remarks,
                        PurchaseId = purchase.PurchaseId
                    };
                }
                

                if (purchaseVM.PurchaseType.ToLower().Equals("cash")) 
                {
                    transaction.PaymentMode = PaymentMode.Cash.ToString();
                    transaction.PaymentAmount = totalPurchaseAmount;
                    transaction.TransactionType = TransType.PURCHASE_CASH.ToString();
                }
                else
                {
                    transaction.PaymentMode = PaymentMode.Credit.ToString();
                    transaction.PaymentAmount = 0;
                    transaction.TransactionType = TransType.PURCHASE_CREDIT.ToString();
                }

                if (isNewTransaction)
                    await dbContext.AddAsync(transaction);

                await SaveChangesAsync();
                await dbTrans.CommitAsync();
                return new ResponseMessage(isSuccess: true, message: "Purchase invoice saved successfully.", data: purchase.PurchaseId.ToString());
            }
            catch (DbUpdateException ex)
            {
                await dbTrans.RollbackAsync();
                DetachedEntries(ex);
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                await dbTrans.RollbackAsync();
                throw new Exception(ex.Message);
            }

            
        }

    }
}
