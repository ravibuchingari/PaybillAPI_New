using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System.Data;

namespace PaybillAPI.Repositories
{
    public class SalesRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), ISalesRepository
    {
        public async Task<ResponseMessage> SaveSalesInvoice(SalesVM salesVM, int userRowId)
        {
            Setting setting = await dbContext.Settings.FirstOrDefaultAsync() ?? throw new Exception("The application settings have not been updated. You cannot perform any actions until the settings are updated.");

            using var dbTrans = await dbContext.Database.BeginTransactionAsync();
            try
            {
                Sale? sale = new()
                {
                    PartyId = salesVM.PartyModel?.PartyId,
                    InvoiceNo = salesVM.InvoiceNo,
                    InvoiceDate = DateTime.Parse(salesVM.InvoiceDate),
                    SalesType = salesVM.SalesType,
                    PaymentMode = salesVM.PaymentMode,
                    UpiType = salesVM.UpiType,
                    Remarks = salesVM.Remarks,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userRowId
                };

                await dbContext.Sales.AddAsync(sale);
                await SaveChangesAsync();
                double totalSalesAmount = 0.0;

                foreach (SalesItemVM salesItemVM in salesVM.SalesItems)
                {
                    totalSalesAmount += salesItemVM.TotalAmount;
                    await dbContext.SalesItems.AddAsync(new SalesItem()
                    {
                        SalesId = sale.SalesId,
                        ItemId = salesItemVM.ItemModel!.ItemId,
                        Quantity = salesItemVM.Quantity,
                        Rate = salesItemVM.Rate,
                        Amount = salesItemVM.Amount,
                        DiscountInRs = salesItemVM.DiscountInRs,
                        TaxableAmount = salesItemVM.TaxableAmount,
                        CgstPer = salesItemVM.CgstPer,
                        SgstPer = salesItemVM.SgstPer,
                        IgstPer = salesItemVM.IgstPer,
                        GstPer = salesItemVM.GstPer,
                        CgstRs = salesItemVM.CgstRs,
                        SgstRs = salesItemVM.SgstRs,
                        IgstRs = salesItemVM.IgstRs,
                        GstAmount = salesItemVM.GstAmount,
                        TotalAmount = salesItemVM.TotalAmount,
                        PurchasePrice = salesItemVM.ItemModel!.PurchasePrice,
                        CreatedDate = DateTime.Now
                    });
                }

                if (salesVM.PartyModel != null)
                {
                    Transaction transaction = new()
                    {
                        PartyId = salesVM.PartyModel.PartyId,
                        TransactionDate = DateTime.Now.Date,
                        PaymentAmount = totalSalesAmount,
                        PaymentMode = salesVM.PaymentMode,
                        UpiType = salesVM.UpiType,
                        Remarks = salesVM.Remarks,
                        SalesId = sale.SalesId,
                        UpdatedBy = userRowId,
                        UpdatedDate = DateTime.Now
                    };

                    if (salesVM.SalesType.ToLower().Equals("cash"))
                    {
                        transaction.PaymentMode = PaymentMode.Cash.ToString();
                        transaction.ReceiptAmount = totalSalesAmount;
                        transaction.TransactionType = TransType.SALES_CASH.ToString();
                    }
                    else
                    {
                        transaction.PaymentMode = PaymentMode.Credit.ToString();
                        transaction.ReceiptAmount = 0;
                        transaction.TransactionType = TransType.SALES_CREDIT.ToString();
                    }

                    transaction.CreatedBy = userRowId;
                    transaction.CreatedDate = DateTime.Now;
                    await dbContext.AddAsync(transaction);
                }

                await SaveChangesAsync();
                await dbTrans.CommitAsync();
                return new ResponseMessage(isSuccess: true, message: "Sales invoice saved successfully.", data: sale.SalesId.ToString());
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

        public async Task<ResponseMessage> DeleteSalesItem(int salesItemId, string remarks, int userRowId)
        {
            SalesItem? salesItem = await dbContext.SalesItems.FirstOrDefaultAsync(col => col.SalesItemId == salesItemId);
            if (salesItem != null)
            {
                salesItem.DeletedBy = userRowId;
                salesItem.DeletedRemarks = remarks;
                await SaveChangesAsync();
                dbContext.SalesItems.Remove(salesItem);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "sales item"));
            }
            else
                return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Sales item"));
        }

        public async Task<IEnumerable<SalesVM>> GetSalesInvoices(DateTime fromDate, DateTime toDate)
        {
            return await dbContext.Sales.Include(itm => itm.SalesItems).Where(col => col.InvoiceDate.Date >= fromDate.Date && col.InvoiceDate.Date <= toDate.Date).Select(row => new SalesVM()
            {
                SalesId = row.SalesId,
                InvoiceNo = row.InvoiceNo,
                InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                SalesType = row.SalesType,
                PaymentMode = row.PaymentMode,
                UpiType = row.UpiType,
                Summary = new InvoiceSummary()
                {
                    TotalAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.Amount),
                    TotalDiscount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.DiscountInRs),
                    TotalTaxableAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.TaxableAmount),
                    TotalGSTAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.GstAmount),
                    TotalInvoiceAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.TotalAmount)
                },
                PartyModel = row.Party != null ? new PartyVM()
                {
                    PartyId = row.Party.PartyId,
                    PartyName = row.Party.PartyName
                } : null
            }).ToListAsync();
        }

        public async Task<SalesVM> GetSalesInvoiceDetails(int salesId)
        {
            SalesVM salesVM = await dbContext.Sales.Where(col => col.SalesId == salesId).Select(row => new SalesVM()
            {
                SalesId = row.SalesId,
                InvoiceNo = row.InvoiceNo,
                InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                SalesType = row.SalesType,
                PaymentMode = row.PaymentMode,
                UpiType = row.UpiType,
                Summary = new InvoiceSummary()
                {
                    TotalAmount = row.SalesItems.Sum(sm => sm.Amount),
                    TotalDiscount = row.SalesItems.Sum(sm => sm.DiscountInRs),
                    TotalTaxableAmount = row.SalesItems.Sum(sm => sm.TaxableAmount),
                    TotalGSTAmount = row.SalesItems.Sum(sm => sm.GstAmount),
                    TotalInvoiceAmount = row.SalesItems.Sum(sm => sm.TotalAmount)
                },
                PartyModel = row.Party != null ? new PartyVM()
                {
                    PartyId = row.Party.PartyId,
                    PartyName = row.Party.PartyName,
                    PartyAddress = row.Party.PartyAddress
                } : null

            }).FirstOrDefaultAsync() ?? throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Sales invoice"));

            List<SalesItemVM> list = await dbContext.SalesItems.Where(col => col.SalesId == salesId).Select(row => new SalesItemVM()
            {
                SalesItemId = row.SalesItemId,
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

            salesVM.SalesItems = list;

            return salesVM;

        }

        public async Task<ResponseMessage> DeleteSalesInvoice(int salesId)
        {
            Sale? sale = await dbContext.Sales.Include(itm => itm.SalesItems).Include(trn => trn.Transactions).FirstOrDefaultAsync(col => col.SalesId == salesId);
            if (sale != null)
            {
                if (sale.SalesItems.Count > 0)
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.SQL_DELETE_REFERENCE_MESSAGE, "sales invoice"));

                using var dbTrans = await dbContext.Database.BeginTransactionAsync();

                try
                {
                    if (sale.Transactions.Count > 0)
                        dbContext.Transactions.RemoveRange(sale.Transactions);
                    dbContext.Sales.Remove(sale);
                    await SaveChangesAsync();
                    await dbTrans.CommitAsync();
                    return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, "sales invoice"));
                }
                catch (DbUpdateException ex)
                {
                    await dbTrans.RollbackAsync();
                    DetachedEntries(ex);
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.SQL_DELETE_REFERENCE_MESSAGE, "sales invoice"));
                }
                catch (Exception ex)
                {
                    await dbTrans.RollbackAsync();
                    throw new Exception(ex.Message);
                }

            }
            else
                return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Sales invoice"));
        }

        public async Task<PrintHeader> GetPrintHeader()
        {
            Setting setting = await dbContext.Settings.FirstOrDefaultAsync() ?? throw new Exception("The application settings have not been updated. You cannot perform any actions until the settings are updated.");
            return new PrintHeader()
            {
                InvoiceTitle = setting.InvoiceTitle ?? "Estimation",
                CompanyName = setting.CompanyName,
                Header1 = setting.Header1 ?? "",
                Header2 = setting.Header2 ?? "",
                Header3 = setting.Header3 ?? "",
                GSTIN = setting.Gstin ?? "",
                GSTSlabRequired = setting.GstslabRequired == 1

            };
        }

        

        

    }
}
