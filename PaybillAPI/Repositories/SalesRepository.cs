﻿using Microsoft.EntityFrameworkCore;
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
                Sale? sale;
                if (salesVM.SalesId == 0)
                {
                    sale = new()
                    {
                        PartyId = salesVM.PartyModel?.PartyId,
                        InvoiceNo = salesVM.InvoiceNo,
                        InvoiceDate = DateTime.Parse(salesVM.InvoiceDate),
                        SalesType = salesVM.SalesType,
                        PaymentMode = salesVM.PaymentMode,
                        UpiType = salesVM.UpiType,
                        Remarks = salesVM.Remarks,
                        PaidAmount = salesVM.PaidAmount,
                        BalanceAmount = salesVM.BalanceAmount,
                        IsLocked = 1,
                        EndUserMobile = salesVM.EndUserMobile,
                        CreatedDate = DateTime.Now,
                        CreatedBy = userRowId,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = userRowId
                    };
                    await dbContext.Sales.AddAsync(sale);
                    await SaveChangesAsync();
                }
                else
                {
                    sale = dbContext.Sales.Include(prt => prt.Party).Where(col => col.SalesId == salesVM.SalesId).FirstOrDefault();
                    if (sale == null)
                    {
                        await dbTrans.RollbackAsync();
                        return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Sales invoice"));
                    }

                    if (sale.IsLocked == 1)
                    {
                        await dbTrans.RollbackAsync();
                        return new ResponseMessage(isSuccess: false, message: AppConstants.INVOICE_LOCKED_MESSAGE);
                    }

                    if (salesVM.PartyModel?.PartyId != sale.Party?.PartyId)
                    {
                        await dbTrans.RollbackAsync();
                        return new ResponseMessage(isSuccess: false, message: "Party cannot be modified.");
                    }

                    sale.InvoiceDate = DateTime.Parse(salesVM.InvoiceDate);
                    sale.SalesType = salesVM.SalesType;
                    sale.PaymentMode = salesVM.PaymentMode;
                    sale.UpiType = salesVM.UpiType;
                    sale.Remarks = salesVM.Remarks;
                    sale.PaidAmount = salesVM.PaidAmount;
                    sale.BalanceAmount = salesVM.BalanceAmount;
                    sale.IsLocked = 1;
                    sale.EndUserMobile = salesVM.EndUserMobile;
                    sale.UpdatedDate = DateTime.Now;
                    sale.UpdatedBy = userRowId;
                }


                double totalSalesAmount = 0.0;
                SalesItem? salesItem = null;
                foreach (SalesItemVM salesItemVM in salesVM.SalesItems)
                {
                    if (salesItemVM.SalesItemId > 0)
                    {
                        salesItem = await dbContext.SalesItems.Where(col => col.SalesItemId == salesItemVM.SalesItemId).FirstOrDefaultAsync();
                        if (salesItem == null)
                        {
                            await dbTrans.RollbackAsync();
                            return new ResponseMessage(isSuccess: false, message: "The sales item is deleted by another user. Please reopen the invoice and try again!");
                        }
                    }
                    else
                    {
                        salesItem = new SalesItem
                        {
                            CreatedDate = DateTime.Now
                        };
                    }

                    salesItem.SalesId = sale.SalesId;
                    salesItem.ItemId = salesItemVM.ItemModel?.ItemId;
                    salesItem.ServiceTypeId = salesItemVM.ServiceTypeModel?.ServiceTypeId;
                    salesItem.Quantity = salesItemVM.Quantity;
                    salesItem.Mrp = salesItemVM.ItemModel != null ? salesItemVM.ItemModel.Mrp : salesItemVM.Rate;
                    salesItem.Rate = salesItemVM.Rate;
                    salesItem.Amount = salesItemVM.Amount;
                    salesItem.DiscountInRs = salesItemVM.DiscountInRs;
                    salesItem.TaxableAmount = salesItemVM.TaxableAmount;
                    salesItem.CgstPer = salesItemVM.CgstPer;
                    salesItem.SgstPer = salesItemVM.SgstPer;
                    salesItem.IgstPer = salesItemVM.IgstPer;
                    salesItem.GstPer = salesItemVM.GstPer;
                    salesItem.CgstRs = salesItemVM.CgstRs;
                    salesItem.SgstRs = salesItemVM.SgstRs;
                    salesItem.IgstRs = salesItemVM.IgstRs;
                    salesItem.GstAmount = salesItemVM.GstAmount;
                    salesItem.TotalAmount = salesItemVM.TotalAmount;
                    salesItem.PurchasePrice = salesItemVM.ItemModel != null ? salesItemVM.ItemModel!.PurchasePrice : 0;
                    salesItem.UpdatedDate = DateTime.Now;
                    salesItem.UpdatedBy = userRowId;

                    if (salesItemVM.SalesItemId <= 0)
                        await dbContext.SalesItems.AddAsync(salesItem);
                    totalSalesAmount += salesItemVM.TotalAmount;
                }

                if (salesVM.PartyModel != null)
                {
                    Transaction? transaction;
                    if (salesVM.SalesId > 0)
                    {
                        transaction = await dbContext.Transactions.Where(col => col.SalesId == salesVM.SalesId).FirstOrDefaultAsync();
                        if (transaction == null)
                        {
                            await dbTrans.RollbackAsync();
                            return new ResponseMessage(isSuccess: false, message: "Sales invoice transaction not found. Please reopen the invoice and try again!");
                        }
                    }
                    else
                    {
                        transaction = new Transaction
                        {
                            TransactionDate = DateTime.Now.Date,
                            SalesId = sale.SalesId,
                            PartyId = salesVM.PartyModel.PartyId,
                            CreatedBy = userRowId,
                            CreatedDate = DateTime.Now
                        };
                    }

                    transaction.PaymentAmount = totalSalesAmount;
                    transaction.UpiType = salesVM.UpiType;
                    transaction.Remarks = salesVM.Remarks ?? string.Empty;
                    transaction.UpdatedBy = userRowId;
                    transaction.UpdatedDate = DateTime.Now;


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

                    if (salesVM.SalesId == 0)
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
            SalesItem? salesItem = await dbContext.SalesItems.Include(sls => sls.Sales).FirstOrDefaultAsync(col => col.SalesItemId == salesItemId);
            if (salesItem != null)
            {
                if (salesItem.Sales.IsLocked == 1)
                    return new ResponseMessage(isSuccess: false, message: AppConstants.INVOICE_LOCKED_MESSAGE);

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
                EndUserMobile = row.EndUserMobile,
                IsLocked = row.IsLocked == 1,
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
                    PartyName = row.Party.PartyName,
                    PartyMobile = row.Party.PartyMobile,
                    PartyEmail = row.Party.PartyEmail
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
                IsLocked = row.IsLocked == 1,
                Remarks = row.Remarks,
                EndUserMobile = row.EndUserMobile,
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
                    PartyAddress = row.Party.PartyAddress,
                    PartyMobile = row.Party.PartyMobile,
                    PartyRemarks = row.Party.PartyRemarks
                } : null

            }).FirstOrDefaultAsync() ?? throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Sales invoice"));

            List<SalesItemVM> list = await dbContext.SalesItems.Where(col => col.SalesId == salesId).Select(row => new SalesItemVM()
            {
                SalesItemId = row.SalesItemId,
                ItemModel = row.Item != null ? new ItemVM()
                {
                    ItemId = row.Item.ItemId,
                    ItemCode = row.Item.ItemCode,
                    ItemName = row.Item.ItemName,
                    Measure = row.Item.Measure
                } : null,
                ServiceTypeModel = row.ServiceType != null ? new ServiceTypeVM()
                {
                    ServiceTypeId = row.ServiceType.ServiceTypeId,
                    ServiceTypeName = row.ServiceType.ServiceTypeName
                } : null,
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


            string? remarks = await dbContext.UnlockRequests.Where(col => col.SalesId == salesId).OrderByDescending(ord => ord.UnlockRequestId).Select(row => row.Remarks).Take(1).FirstOrDefaultAsync();
            if (!string.IsNullOrEmpty(remarks))
                salesVM.Remarks = string.IsNullOrEmpty(salesVM.Remarks) ? remarks : $"{salesVM.Remarks}\n{remarks}";

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

        public async Task<PrintSalesInvoice?> GetSalesInvoiceToPrint(int salesId)
        {
            PrintSalesInvoice? invoice = await dbContext.Sales.Where(col => col.SalesId == salesId).Select(row => new PrintSalesInvoice()
            {
                InvoiceNo = row.InvoiceNo,
                InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                SalesType = row.SalesType,
                PaymentMode = row.PaymentMode,
                UpiType = row.UpiType ?? string.Empty,
                PaidAmount = row.PaidAmount,
                PartyName = row.Party != null ? row.Party.PartyName : string.Empty,
                CreatedBy = row.CreatedByNavigation.UserId,
                CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy hh:mm tt"),
                PrintedTime = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt"),
                GstSummary = row.SalesItems.GroupBy(grp => grp.GstPer).Select(row => new GSTData()
                {
                    GstPer = row.Key,
                    TaxableAmount = row.Sum(x => x.TaxableAmount),
                    IgstAmount = row.Sum(x => x.IgstRs),
                    CgstAmount = row.Sum(x => x.CgstRs),
                    SgstAmount = row.Sum(x => x.SgstRs),
                    GstAmount = row.Sum(x => x.GstAmount)
                }).ToList(),
                SalesItems = row.SalesItems.Select(itm => new PrintSalesItem()
                {
                    ItemCode = itm.Item != null ? itm.Item.ItemCode : "(Service)",
                    ItemName = itm.Item != null ? itm.Item.ItemName : itm.ServiceType!.ServiceTypeName,
                    Measure = itm.Item != null ? itm.Item.Measure : string.Empty,
                    Quantity = itm.Quantity,
                    Mrp = itm.Mrp,
                    Rate = itm.Rate,
                    Amount = itm.Amount,
                    DiscountInRs = itm.DiscountInRs,
                    TaxableAmount = itm.TaxableAmount,
                    IgstPer = itm.IgstPer,
                    CgstPer = itm.CgstPer,
                    SgstPer = itm.SgstPer,
                    GstPer = itm.GstPer,
                    IgstRs = itm.IgstRs,
                    CgstRs = itm.CgstRs,
                    SgstRs = itm.SgstRs,
                    GstAmount = itm.GstAmount,
                    TotalAmount = itm.TotalAmount,
                    SavingAmount = (itm.Mrp * itm.Quantity) - itm.TaxableAmount
                }).ToList(),
            }).FirstOrDefaultAsync();


            return invoice;
        }

        /*public async Task<IEnumerable<MessageTemplate>> GetSalesMessages()
        {
            List<MessageTemplate> templates = [];
            Setting? settings = await dbContext.Settings.Include(sal_msg => sal_msg.SalesMessage).Include(ser_msg => ser_msg.ServiceMessage).FirstOrDefaultAsync();
            if (settings == null) return templates;

            templates.Add(new MessageTemplate()
            {
                MessageId = 1,
                MessageDescription = settings.SalesMessage != null ? settings.SalesMessage.MessageDescription : string.Empty
            });

            templates.Add(new MessageTemplate()
            {
                MessageId = 2,
                MessageDescription = settings.ServiceMessage != null ? settings.ServiceMessage.MessageDescription : string.Empty
            });

            return templates;
        }*/
    }
}
