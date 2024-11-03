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
                purchase.InvoiceDate = DateTime.Parse(purchaseVM.InvoiceDate);
                purchase.PurchaseType = purchaseVM.PurchaseType;
                purchase.PaymentMode = purchaseVM.PaymentMode;
                purchase.UpiType = purchaseVM.UpiType;
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

                    if(purchaseItemVM.Rate > 0)
                    {
                        var item = await dbContext.Items.Where(col => col.ItemId == purchaseItemVM.ItemModel.ItemId).FirstAsync();
                        if(item.PurchasePrice != purchaseItemVM.Rate)
                            item.PurchasePrice = purchaseItemVM.Rate;
                    }
                }

                Transaction? transaction = null;
                bool isNewTransaction = false;

                if (purchaseVM.PurchaseId > 0)
                    transaction = await dbContext.Transactions.Where(col => col.PurchaseId == purchaseVM.PurchaseId).FirstOrDefaultAsync();

                if (transaction == null)
                {
                    isNewTransaction = true;
                    transaction = new Transaction();
                }

                transaction.PartyId = purchaseVM.PartyModel.PartyId;
                transaction.TransactionDate = DateTime.Now.Date;
                transaction.ReceiptAmount = totalPurchaseAmount;
                transaction.PaymentMode = purchaseVM.PaymentMode;
                transaction.UpiType = purchaseVM.UpiType;
                transaction.Remarks = purchaseVM.Remarks;
                transaction.PurchaseId = purchase.PurchaseId;
                transaction.UpdatedBy = userRowId;
                transaction.UpdatedDate = DateTime.Now;


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
                {
                    transaction.CreatedBy = userRowId;
                    transaction.CreatedDate = DateTime.Now;
                    await dbContext.AddAsync(transaction);
                }


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

        public async Task<ResponseMessage> DeletePurchaseItem(int purchaseItemId, string remarks, int userRowId)
        {
            PurchaseItem? purchaseItem = await dbContext.PurchaseItems.FirstOrDefaultAsync(col => col.PurchaseItemId == purchaseItemId);
            if (purchaseItem != null)
            {
                purchaseItem.DeletedBy = userRowId;
                purchaseItem.DeletedRemarks = remarks;
                await SaveChangesAsync();
                dbContext.PurchaseItems.Remove(purchaseItem);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "purchase item"));
            }
            else
                return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Purchase item"));
        }

        public async Task<IEnumerable<PurchaseVM>> GetPurchaseInvoices(DateTime fromDate, DateTime toDate)
        {
            return await dbContext.Purchases.Include(itm => itm.PurchaseItems).Where(col => col.InvoiceDate.Date >= fromDate.Date && col.InvoiceDate.Date <= toDate.Date).Select(row => new PurchaseVM()
            {
                PurchaseId = row.PurchaseId,
                InvoiceNo = row.InvoiceNo,
                InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                PurchaseType = row.PurchaseType,
                Summary = new InvoiceSummary()
                {
                    TotalAmount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.Amount),
                    TotalDiscount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.DiscountInRs),
                    TotalTaxableAmount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.TaxableAmount),
                    TotalGSTAmount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.GstAmount),
                    TotalInvoiceAmount = row.PurchaseItems.Where(c => c.PurchaseId == row.PurchaseId).Sum(sm => sm.TotalAmount)
                },
                PartyModel = new PartyVM()
                {
                    PartyId = row.PartyId,
                    PartyName = row.Party.PartyName
                }
            }).ToListAsync();
        }

        public async Task<ResponseMessage> DeletePurchaseInvoice(int purchaseId)
        {
            Purchase? purchase = await dbContext.Purchases.Include(itm => itm.PurchaseItems).Include(trn => trn.Transactions).FirstOrDefaultAsync(col => col.PurchaseId == purchaseId);
            if (purchase != null)
            {
                if (purchase.PurchaseItems.Count > 0)
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.SQL_DELETE_REFERENCE_MESSAGE, "purchase invoice"));

                using var dbTrans = await dbContext.Database.BeginTransactionAsync();

                try
                {
                    dbContext.Transactions.RemoveRange(purchase.Transactions);
                    dbContext.Purchases.Remove(purchase);
                    await SaveChangesAsync();
                    await dbTrans.CommitAsync();
                    return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "purchase invoice"));
                }
                catch (DbUpdateException ex)
                {
                    await dbTrans.RollbackAsync();
                    DetachedEntries(ex);
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.SQL_DELETE_REFERENCE_MESSAGE, "purchase invoice"));
                }
                catch (Exception ex)
                {
                    await dbTrans.RollbackAsync();
                    throw new Exception(ex.Message);
                }

            }
            else
                return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Purchase invoice"));
        }

        public async Task<PurchaseVM> GetPurchaseInvoiceDetails(int purchaseId)
        {
            PurchaseVM purchaseVM = await dbContext.Purchases.Where(col => col.PurchaseId == purchaseId).Select(row => new PurchaseVM()
            {
                PurchaseId = row.PurchaseId,
                InvoiceNo = row.InvoiceNo,
                InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                PurchaseType = row.PurchaseType,
                Summary = new InvoiceSummary()
                {
                    TotalAmount = row.PurchaseItems.Sum(sm => sm.Amount),
                    TotalDiscount = row.PurchaseItems.Sum(sm => sm.DiscountInRs),
                    TotalTaxableAmount = row.PurchaseItems.Sum(sm => sm.TaxableAmount),
                    TotalGSTAmount = row.PurchaseItems.Sum(sm => sm.GstAmount),
                    TotalInvoiceAmount = row.PurchaseItems.Sum(sm => sm.TotalAmount)
                },
                PartyModel = new PartyVM()
                {
                    PartyId = row.PartyId,
                    PartyName = row.Party.PartyName,
                    PartyAddress = row.Party.PartyAddress
                }

            }).FirstOrDefaultAsync() ?? throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Purchase invoice"));

            List<PurchaseItemVM> list = await dbContext.PurchaseItems.Where(col => col.PurchaseId == purchaseId).Select(row => new PurchaseItemVM()
            {
                PurchaseItemId = row.PurchaseItemId,
                ItemModel = new ItemVM()
                {
                    ItemId = row.ItemId,
                    ItemCode = row.Item.ItemCode,
                    ItemName = row.Item.ItemName,
                    Measure = row.Item.Measure
                },
                Quantity = row.Quantity,
                Rate = row.Rate,
                Amount = row.Amount,
                DiscountInRs = row.DiscountInRs,
                TaxableAmount = row.TaxableAmount,
                GstPer = row.GstPer,
                GstAmount = row.GstAmount,
                TotalAmount = row.TotalAmount,
                CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy")
            }).ToListAsync();

            purchaseVM.PurchaseItems = list;

            return purchaseVM;

        }


    }
}
