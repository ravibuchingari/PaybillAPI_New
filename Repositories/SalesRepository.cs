using Microsoft.EntityFrameworkCore;
using Paybill.Data;
using Paybill.DTO;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;
using System.Data;

namespace Paybill.Repositories
{
    public class SalesRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), ISalesRepository
    {
        public async Task<ResponseMessage> SaveSalesInvoice(SalesVM salesVM, int userRowId)
        {
            Setting? setting = await dbContext.Settings.FirstOrDefaultAsync();
            if (setting == null)
            {
                return new ResponseMessage(isSuccess: false, message: "The application settings have not been updated. You cannot perform any actions until the settings are updated.");
            }

            using var dbTrans = await dbContext.Database.BeginTransactionAsync();
            try
            {
                Sale? sale;
                DateTime invoiceDate = DateTime.TryParse(salesVM.InvoiceDate, out var parsedDate) ? parsedDate : DateTime.Now.Date;
                int? serviceReqId = salesVM.ServiceRequestId > 0 ? salesVM.ServiceRequestId : (salesVM.JobCard != null && salesVM.JobCard.ServiceRequestId > 0 ? salesVM.JobCard.ServiceRequestId : null);

                if (salesVM.SalesId == 0)
                {
                    sale = new()
                    {
                        PartyId = salesVM.PartyModel?.PartyId > 0 ? salesVM.PartyModel.PartyId : null,
                        InvoiceNo = salesVM.InvoiceNo ?? string.Empty,
                        InvoiceDate = invoiceDate,
                        SalesType = salesVM.SalesType,
                        PaymentMode = salesVM.PaymentMode,
                        UpiType = salesVM.UpiType,
                        Remarks = salesVM.Remarks,
                        PaidAmount = salesVM.PaidAmount,
                        BalanceAmount = salesVM.BalanceAmount,
                        IsLocked = (sbyte)(serviceReqId != null && serviceReqId > 0 ? 0 : 1),
                        EndUserMobile = salesVM.EndUserMobile,
                        ServiceRequestId = serviceReqId,
                        RewardPointsEarned = salesVM.RewardPointsEarned,
                        RewardPointsRedeemed = salesVM.RewardPointsRedeemed,
                        RewardDiscountAmount = salesVM.RewardDiscountAmount,
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
                    sale = await dbContext.Sales.Include(prt => prt.Party).Where(col => col.SalesId == salesVM.SalesId).FirstOrDefaultAsync();
                    if (sale == null)
                    {
                        await dbTrans.RollbackAsync();
                        return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, "Sales invoice"));
                    }

                    if ((serviceReqId == null || serviceReqId == 0) && sale.IsLocked == 1)
                    {
                        await dbTrans.RollbackAsync();
                        return new ResponseMessage(isSuccess: false, message: AppConstants.INVOICE_LOCKED_MESSAGE);
                    }

                    if (salesVM.PartyModel?.PartyId != sale.Party?.PartyId)
                    {
                        await dbTrans.RollbackAsync();
                        return new ResponseMessage(isSuccess: false, message: "Party cannot be modified.");
                    }

                    sale.InvoiceDate = invoiceDate;
                    sale.SalesType = salesVM.SalesType;
                    sale.PaymentMode = salesVM.PaymentMode;
                    sale.UpiType = salesVM.UpiType;
                    sale.Remarks = salesVM.Remarks;
                    sale.PaidAmount = salesVM.PaidAmount;
                    sale.BalanceAmount = salesVM.BalanceAmount;
                    sale.IsLocked = (sbyte)(serviceReqId != null && serviceReqId > 0 ? 0 : 1);
                    sale.EndUserMobile = salesVM.EndUserMobile;
                    sale.RewardPointsEarned = salesVM.RewardPointsEarned;
                    sale.RewardPointsRedeemed = salesVM.RewardPointsRedeemed;
                    sale.RewardDiscountAmount = salesVM.RewardDiscountAmount;
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
                    salesItem.ItemId = salesItemVM.ItemModel?.ItemId > 0 ? salesItemVM.ItemModel.ItemId : null;
                    salesItem.ServiceTypeId = salesItemVM.ServiceTypeModel?.ServiceTypeId > 0 ? salesItemVM.ServiceTypeModel.ServiceTypeId : null;
                    salesItem.Quantity = salesItemVM.Quantity;
                    salesItem.Mrp = salesItemVM.ItemModel != null && salesItemVM.ItemModel.Mrp > 0 ? salesItemVM.ItemModel.Mrp : (salesItemVM.Mrp > 0 ? salesItemVM.Mrp : salesItemVM.Rate);
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
                    salesItem.PurchasePrice = salesItemVM.ItemModel != null ? salesItemVM.ItemModel.PurchasePrice : 0;
                    salesItem.UpdatedDate = DateTime.Now;
                    salesItem.UpdatedBy = userRowId;

                    if (salesItemVM.SalesItemId <= 0)
                        await dbContext.SalesItems.AddAsync(salesItem);
                    totalSalesAmount += salesItemVM.TotalAmount;
                }

                double netInvoiceAmount = Math.Max(0.0, totalSalesAmount - salesVM.RewardDiscountAmount);

                if (salesVM.PartyModel != null && salesVM.PartyModel.PartyId > 0)
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
                            TransactionDate = invoiceDate,
                            SalesId = sale.SalesId,
                            PartyId = salesVM.PartyModel.PartyId,
                            CreatedBy = userRowId,
                            CreatedDate = DateTime.Now
                        };
                    }

                    transaction.TransactionDate = invoiceDate;
                    transaction.PaymentAmount = netInvoiceAmount;
                    transaction.UpiType = salesVM.UpiType;
                    transaction.Remarks = salesVM.Remarks ?? "Sales invoice";
                    transaction.UpdatedBy = userRowId;
                    transaction.UpdatedDate = DateTime.Now;

                    if (salesVM.SalesType.ToLower().Equals("cash"))
                    {
                        transaction.PaymentMode = string.IsNullOrEmpty(salesVM.PaymentMode) ? PaymentMode.Cash.ToString() : salesVM.PaymentMode;
                        transaction.ReceiptAmount = netInvoiceAmount;
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

                    // Customer Reward Transactions
                    int partyId = salesVM.PartyModel.PartyId;
                    if (salesVM.SalesId > 0)
                    {
                        var existingRewards = await dbContext.RewardTransactions
                            .Where(r => r.SalesId == sale.SalesId && (r.TransactionType == "EARNED" || r.TransactionType == "REDEEMED"))
                            .ToListAsync();
                        if (existingRewards.Count > 0)
                        {
                            dbContext.RewardTransactions.RemoveRange(existingRewards);
                        }
                    }

                    string invLabel = !string.IsNullOrEmpty(sale.InvoiceNo) ? sale.InvoiceNo : sale.SalesId.ToString();

                    if (salesVM.RewardPointsEarned > 0.0)
                    {
                        await dbContext.RewardTransactions.AddAsync(new RewardTransaction
                        {
                            PartyId = partyId,
                            SalesId = sale.SalesId,
                            TransactionType = "EARNED",
                            PointsCredited = salesVM.RewardPointsEarned,
                            PointsDebited = 0.0,
                            MonetaryValue = 0.0,
                            TransactionDate = invoiceDate,
                            Description = $"Earned on invoice #{invLabel}",
                            CreatedBy = userRowId
                        });
                    }

                    if (salesVM.RewardPointsRedeemed > 0.0)
                    {
                        await dbContext.RewardTransactions.AddAsync(new RewardTransaction
                        {
                            PartyId = partyId,
                            SalesId = sale.SalesId,
                            TransactionType = "REDEEMED",
                            PointsCredited = 0.0,
                            PointsDebited = salesVM.RewardPointsRedeemed,
                            MonetaryValue = salesVM.RewardDiscountAmount,
                            TransactionDate = invoiceDate,
                            Description = $"Redeemed on invoice #{invLabel}",
                            CreatedBy = userRowId
                        });
                    }
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
            return await dbContext.Sales
                .Include(itm => itm.SalesItems)
                .Where(col => col.InvoiceDate.Date >= fromDate.Date && col.InvoiceDate.Date <= toDate.Date)
                .OrderByDescending(col => col.SalesId)
                .Select(row => new SalesVM()
                {
                    SalesId = row.SalesId,
                    InvoiceNo = row.InvoiceNo,
                    InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                    SalesType = row.SalesType,
                    PaymentMode = row.PaymentMode,
                    UpiType = row.UpiType ?? string.Empty,
                    PaidAmount = row.PaidAmount,
                    BalanceAmount = row.BalanceAmount,
                    EndUserMobile = row.EndUserMobile ?? string.Empty,
                    IsLocked = row.IsLocked == 1,
                    ServiceRequestId = row.ServiceRequestId ?? 0,
                    RewardPointsEarned = row.RewardPointsEarned,
                    RewardPointsRedeemed = row.RewardPointsRedeemed,
                    RewardDiscountAmount = row.RewardDiscountAmount,
                    Summary = new InvoiceSummary()
                    {
                        TotalAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.Amount),
                        TotalDiscount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.DiscountInRs),
                        TotalTaxableAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.TaxableAmount),
                        TotalGSTAmount = row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.GstAmount),
                        TotalInvoiceAmount = Math.Max(0.0, row.SalesItems.Where(c => c.SalesId == row.SalesId).Sum(sm => sm.TotalAmount) - row.RewardDiscountAmount)
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
                UpiType = row.UpiType ?? string.Empty,
                PaidAmount = row.PaidAmount,
                BalanceAmount = row.BalanceAmount,
                IsLocked = row.IsLocked == 1,
                Remarks = row.Remarks ?? string.Empty,
                EndUserMobile = row.EndUserMobile ?? string.Empty,
                ServiceRequestId = row.ServiceRequestId ?? 0,
                RewardPointsEarned = row.RewardPointsEarned,
                RewardPointsRedeemed = row.RewardPointsRedeemed,
                RewardDiscountAmount = row.RewardDiscountAmount,
                Summary = new InvoiceSummary()
                {
                    TotalAmount = row.SalesItems.Sum(sm => sm.Amount),
                    TotalDiscount = row.SalesItems.Sum(sm => sm.DiscountInRs),
                    TotalTaxableAmount = row.SalesItems.Sum(sm => sm.TaxableAmount),
                    TotalGSTAmount = row.SalesItems.Sum(sm => sm.GstAmount),
                    TotalInvoiceAmount = Math.Max(0.0, row.SalesItems.Sum(sm => sm.TotalAmount) - row.RewardDiscountAmount)
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
                Mrp = row.Mrp,
                Rate = row.Rate,
                Amount = row.Amount,
                DiscountInRs = row.DiscountInRs,
                TaxableAmount = row.TaxableAmount,
                CgstPer = row.CgstPer,
                SgstPer = row.SgstPer,
                IgstPer = row.IgstPer,
                GstPer = row.GstPer,
                CgstRs = row.CgstRs,
                SgstRs = row.SgstRs,
                IgstRs = row.IgstRs,
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

        public async Task<ResponseMessage> DeleteSalesInvoice(int salesId, int userRowId = 1)
        {
            Sale? sale = await dbContext.Sales.Include(itm => itm.SalesItems).Include(trn => trn.Transactions).FirstOrDefaultAsync(col => col.SalesId == salesId);
            if (sale != null)
            {
                if (sale.SalesItems.Count > 0)
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.SQL_DELETE_REFERENCE_MESSAGE, "sales invoice"));

                using var dbTrans = await dbContext.Database.BeginTransactionAsync();
                try
                {
                    // Reverse reward points if any
                    var origRewards = await dbContext.RewardTransactions
                        .Where(r => r.SalesId == salesId && (r.TransactionType == "EARNED" || r.TransactionType == "REDEEMED"))
                        .ToListAsync();

                    foreach (var orig in origRewards)
                    {
                        bool alreadyReversed = await dbContext.RewardTransactions
                            .AnyAsync(r => r.RefTransId == orig.RewardTransId && r.TransactionType == "REVERSED");

                        if (!alreadyReversed)
                        {
                            if (orig.TransactionType == "EARNED" && orig.PointsCredited > 0.0)
                            {
                                await dbContext.RewardTransactions.AddAsync(new RewardTransaction
                                {
                                    PartyId = orig.PartyId,
                                    SalesId = null,
                                    TransactionType = "REVERSED",
                                    PointsCredited = 0.0,
                                    PointsDebited = orig.PointsCredited,
                                    MonetaryValue = 0.0,
                                    TransactionDate = DateTime.Now,
                                    Description = $"Reversed earned points for cancelled invoice #{sale.InvoiceNo}",
                                    RefTransId = orig.RewardTransId,
                                    CreatedBy = userRowId
                                });
                            }
                            else if (orig.TransactionType == "REDEEMED" && orig.PointsDebited > 0.0)
                            {
                                await dbContext.RewardTransactions.AddAsync(new RewardTransaction
                                {
                                    PartyId = orig.PartyId,
                                    SalesId = null,
                                    TransactionType = "REVERSED",
                                    PointsCredited = orig.PointsDebited,
                                    PointsDebited = 0.0,
                                    MonetaryValue = orig.MonetaryValue,
                                    TransactionDate = DateTime.Now,
                                    Description = $"Restored redeemed points for cancelled invoice #{sale.InvoiceNo}",
                                    RefTransId = orig.RewardTransId,
                                    CreatedBy = userRowId
                                });
                            }
                        }
                        orig.SalesId = null;
                    }

                    if (sale.Transactions.Count > 0)
                    {
                        foreach (var trn in sale.Transactions)
                        {
                            trn.DeletedBy = userRowId;
                            trn.DeletedRemarks = "Sales invoice deleted";
                        }
                        await SaveChangesAsync();
                        dbContext.Transactions.RemoveRange(sale.Transactions);
                    }

                    var linkedJobCards = await dbContext.JobCards.Where(j => j.SalesId == salesId).ToListAsync();
                    foreach (var jc in linkedJobCards)
                    {
                        jc.SalesId = null;
                    }

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
            var saleRow = await dbContext.Sales.AsNoTracking().FirstOrDefaultAsync(col => col.SalesId == salesId);
            double availablePts = 0.0;
            if (saleRow?.PartyId != null && saleRow.PartyId > 0)
            {
                int pId = saleRow.PartyId.Value;
                availablePts = await dbContext.RewardTransactions
                    .Where(r => r.PartyId == pId)
                    .SumAsync(r => r.PointsCredited - r.PointsDebited);
            }

            PrintSalesInvoice? invoice = await dbContext.Sales.Where(col => col.SalesId == salesId).Select(row => new PrintSalesInvoice()
            {
                InvoiceNo = row.InvoiceNo,
                InvoiceDate = row.InvoiceDate.ToString("dd-MMM-yyyy"),
                SalesType = row.SalesType,
                PaymentMode = row.PaymentMode,
                UpiType = row.UpiType ?? string.Empty,
                PaidAmount = row.PaidAmount,
                PartyName = row.Party != null ? row.Party.PartyName : string.Empty,
                PartyAddress = row.Party != null ? row.Party.PartyAddress ?? string.Empty : string.Empty,
                PartyMobile = row.Party != null ? row.Party.PartyMobile ?? string.Empty : (row.EndUserMobile ?? string.Empty),
                RewardPointsEarned = row.RewardPointsEarned,
                RewardPointsRedeemed = row.RewardPointsRedeemed,
                RewardDiscountAmount = row.RewardDiscountAmount,
                CustomerAvailablePoints = availablePts,
                CreatedBy = row.CreatedByNavigation.UserId,
                CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy hh:mm tt"),
                PrintedTime = DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt"),
                GstSummary = row.SalesItems.Where(x => x.GstPer > 0).GroupBy(grp => grp.GstPer).Select(g => new GSTData()
                {
                    GstPer = g.Key,
                    TaxableAmount = g.Sum(x => x.TaxableAmount),
                    IgstAmount = g.Sum(x => x.IgstRs),
                    CgstAmount = g.Sum(x => x.CgstRs),
                    SgstAmount = g.Sum(x => x.SgstRs),
                    GstAmount = g.Sum(x => x.GstAmount)
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

        private async Task<TodaySalesSummary> GetSalesSummaryForRangeAsync(DateTime fromDate, DateTime toDate, string dateLabel, double overallPendingCredit)
        {
            var invoices = await GetSalesInvoices(fromDate, toDate);

            int totalInvoiceCount = 0;
            double totalSalesAmount = 0.0;
            double totalDiscountAmount = 0.0;
            double totalGstAmount = 0.0;
            double cashAmount = 0.0;
            double cardAmount = 0.0;
            double upiAmount = 0.0;
            double totalCreditSalesAmount = 0.0;
            double rangePendingCreditAmount = 0.0;

            foreach (var inv in invoices)
            {
                totalInvoiceCount++;
                double invTotal = inv.Summary?.TotalInvoiceAmount ?? 0.0;
                double invDiscount = inv.Summary?.TotalDiscount ?? 0.0;
                double invGst = inv.Summary?.TotalGSTAmount ?? 0.0;

                totalSalesAmount += invTotal;
                totalDiscountAmount += invDiscount;
                totalGstAmount += invGst;

                bool isCredit = string.Equals(inv.SalesType, "Credit", StringComparison.OrdinalIgnoreCase)
                             || string.Equals(inv.PaymentMode, "Credit", StringComparison.OrdinalIgnoreCase);

                if (isCredit)
                {
                    totalCreditSalesAmount += invTotal;
                    double paid = inv.PaidAmount;
                    double pending = inv.BalanceAmount > 0 ? inv.BalanceAmount : Math.Max(0.0, invTotal - paid);
                    rangePendingCreditAmount += pending;

                    if (paid > 0)
                    {
                        if (string.Equals(inv.PaymentMode, "Card", StringComparison.OrdinalIgnoreCase))
                            cardAmount += paid;
                        else if (string.Equals(inv.PaymentMode, "UPI", StringComparison.OrdinalIgnoreCase))
                            upiAmount += paid;
                        else
                            cashAmount += paid;
                    }
                }
                else
                {
                    double paid = inv.PaidAmount > 0 ? inv.PaidAmount : invTotal;
                    if (string.Equals(inv.PaymentMode, "Card", StringComparison.OrdinalIgnoreCase))
                        cardAmount += paid;
                    else if (string.Equals(inv.PaymentMode, "UPI", StringComparison.OrdinalIgnoreCase))
                        upiAmount += paid;
                    else
                        cashAmount += paid;
                }
            }

            return new TodaySalesSummary
            {
                InvoiceDate = dateLabel,
                TotalInvoiceCount = totalInvoiceCount,
                TotalSalesAmount = totalSalesAmount,
                TotalDiscountAmount = totalDiscountAmount,
                TotalGstAmount = totalGstAmount,
                AmountCollected = cashAmount + cardAmount + upiAmount,
                CashAmount = cashAmount,
                CardAmount = cardAmount,
                UpiAmount = upiAmount,
                TotalCreditSalesAmount = totalCreditSalesAmount,
                TodayPendingCreditAmount = rangePendingCreditAmount,
                OverallPendingCreditAmount = overallPendingCredit
            };
        }

        public async Task<DashboardSalesSummaryResponse> GetDashboardSalesSummary()
        {
            double overallPendingCredit = 0.0;
            try
            {
                var creditSales = await dbContext.Sales
                    .Include(s => s.SalesItems)
                    .Where(s => s.SalesType.ToLower() == "credit" || s.PaymentMode.ToLower() == "credit")
                    .Select(s => new
                    {
                        s.BalanceAmount,
                        s.PaidAmount,
                        s.RewardDiscountAmount,
                        ItemsTotal = s.SalesItems.Sum(i => i.TotalAmount)
                    })
                    .ToListAsync();

                double totalCredit = creditSales.Sum(s =>
                    s.BalanceAmount > 0
                        ? s.BalanceAmount
                        : Math.Max(0.0, Math.Max(0.0, s.ItemsTotal - s.RewardDiscountAmount) - s.PaidAmount));

                double totalReceipts = await dbContext.Transactions
                    .Where(t => t.TransactionType.ToLower() == "receipt")
                    .SumAsync(t => t.ReceiptAmount);

                overallPendingCredit = Math.Max(0.0, totalCredit - totalReceipts);
            }
            catch
            {
                overallPendingCredit = 0.0;
            }

            DateTime today = DateTime.Now.Date;
            string todayStr = today.ToString("dd-MMM-yyyy");

            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime weekStart = today.AddDays(-1 * diff).Date;
            string weekStartStr = weekStart.ToString("dd-MMM-yyyy");

            DateTime monthStart = new DateTime(today.Year, today.Month, 1);
            string monthStartStr = monthStart.ToString("dd-MMM-yyyy");
            string monthName = today.ToString("MMMM yyyy");

            var todaySummary = await GetSalesSummaryForRangeAsync(today, today, todayStr, overallPendingCredit);
            var weeklySummary = await GetSalesSummaryForRangeAsync(weekStart, today, $"{weekStartStr} to {todayStr}", overallPendingCredit);
            var monthlySummary = await GetSalesSummaryForRangeAsync(monthStart, today, $"{monthName} ({monthStartStr} to {todayStr})", overallPendingCredit);

            return new DashboardSalesSummaryResponse
            {
                Today = todaySummary,
                Weekly = weeklySummary,
                Monthly = monthlySummary
            };
        }

        #region "Job Cards / Service Requests"

        public async Task<ResponseMessage> CreateJobCard(JobCardVM serviceRequest, int userRowId)
        {
            using var dbTrans = await dbContext.Database.BeginTransactionAsync();
            try
            {
                DateTime reqDate = DateTime.TryParse(serviceRequest.ServiceRequestDate, out var parsed) ? parsed : DateTime.Now.Date;
                JobCard? jobCard;

                if (serviceRequest.ServiceRequestId == 0)
                {
                    jobCard = new JobCard
                    {
                        PartyId = serviceRequest.PartyModel.PartyId,
                        ServiceRequestDate = reqDate,
                        ServiceRequestStatusId = serviceRequest.ServiceRequestStatusId > 0 ? serviceRequest.ServiceRequestStatusId : 1,
                        ServiceRequestDescription = serviceRequest.ServiceRequestDescription ?? string.Empty,
                        CreatedBy = userRowId,
                        UpdatedBy = userRowId,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now
                    };
                    await dbContext.JobCards.AddAsync(jobCard);
                    await SaveChangesAsync();
                }
                else
                {
                    jobCard = await dbContext.JobCards.FirstOrDefaultAsync(j => j.ServiceRequestId == serviceRequest.ServiceRequestId);
                    if (jobCard == null)
                    {
                        await dbTrans.RollbackAsync();
                        return new ResponseMessage(isSuccess: false, message: "Service request not found.");
                    }

                    if (jobCard.ServiceRequestStatusId != 1)
                    {
                        await dbTrans.RollbackAsync();
                        return new ResponseMessage(isSuccess: false, message: "Only job cards with Pending status can be updated.");
                    }

                    jobCard.PartyId = serviceRequest.PartyModel.PartyId;
                    jobCard.ServiceRequestDate = reqDate;
                    jobCard.ServiceRequestStatusId = serviceRequest.ServiceRequestStatusId > 0 ? serviceRequest.ServiceRequestStatusId : jobCard.ServiceRequestStatusId;
                    jobCard.ServiceRequestDescription = serviceRequest.ServiceRequestDescription ?? string.Empty;
                    jobCard.UpdatedBy = userRowId;
                    jobCard.UpdatedDate = DateTime.Now;
                    await SaveChangesAsync();
                }

                int srId = jobCard.ServiceRequestId;

                if (serviceRequest.Complaints != null)
                {
                    foreach (var comp in serviceRequest.Complaints)
                    {
                        if (comp.ServiceRequestComplaintId > 0)
                            continue;

                        await dbContext.JobCardItems.AddAsync(new JobCardItem
                        {
                            ServiceRequestId = srId,
                            ServiceTypeId = comp.ServiceTypeModel.ServiceTypeId,
                            ServiceCharge = comp.ServiceCharge
                        });
                    }
                }

                var existingSpares = await dbContext.JobCardSpares.Where(s => s.ServiceRequestId == srId).ToListAsync();
                if (existingSpares.Count > 0)
                {
                    dbContext.JobCardSpares.RemoveRange(existingSpares);
                }

                if (serviceRequest.Spares != null)
                {
                    foreach (var spare in serviceRequest.Spares)
                    {
                        await dbContext.JobCardSpares.AddAsync(new JobCardSpare
                        {
                            ServiceRequestId = srId,
                            ItemId = spare.ItemModel.ItemId,
                            Quantity = spare.Quantity,
                            Mrp = spare.Mrp,
                            Rate = spare.Rate,
                            Amount = spare.Amount,
                            DiscountInRs = spare.DiscountInRs,
                            TaxableAmount = spare.TaxableAmount,
                            GstPer = spare.GstPer,
                            CgstPer = spare.CgstPer,
                            SgstPer = spare.SgstPer,
                            IgstPer = spare.IgstPer,
                            CgstRs = spare.CgstRs,
                            SgstRs = spare.SgstRs,
                            IgstRs = spare.IgstRs,
                            GstAmount = spare.GstAmount,
                            TotalAmount = spare.TotalAmount
                        });
                    }
                }

                await SaveChangesAsync();
                await dbTrans.CommitAsync();
                return new ResponseMessage(isSuccess: true, message: serviceRequest.ServiceRequestId == 0 ? "Job card created successfully." : "Job card updated successfully.", data: srId.ToString());
            }
            catch (Exception ex)
            {
                await dbTrans.RollbackAsync();
                return new ResponseMessage(isSuccess: false, message: ex.Message);
            }
        }

        public async Task<List<JobCardVM>> GetActiveJobCards()
        {
            var jobCards = await dbContext.JobCards
                .Include(j => j.Party)
                .OrderByDescending(j => j.ServiceRequestId)
                .Select(j => new JobCardVM
                {
                    ServiceRequestId = j.ServiceRequestId,
                    SalesId = j.SalesId,
                    ServiceRequestDate = j.ServiceRequestDate.ToString("dd-MMM-yyyy"),
                    ServiceRequestDescription = j.ServiceRequestDescription ?? string.Empty,
                    ServiceRequestStatusId = j.ServiceRequestStatusId,
                    PartyModel = new PartyVM
                    {
                        PartyId = j.Party.PartyId,
                        PartyName = j.Party.PartyName,
                        PartyMobile = j.Party.PartyMobile,
                        PartyAddress = j.Party.PartyAddress
                    }
                })
                .ToListAsync();

            foreach (var card in jobCards)
            {
                card.Complaints = await dbContext.JobCardItems
                    .Include(i => i.ServiceType)
                    .Where(i => i.ServiceRequestId == card.ServiceRequestId)
                    .Select(i => new JobCardItemVM
                    {
                        ServiceRequestComplaintId = i.ServiceRequestComplaintId,
                        ServiceCharge = i.ServiceCharge,
                        ServiceTypeModel = new ServiceTypeVM
                        {
                            ServiceTypeId = i.ServiceType.ServiceTypeId,
                            ServiceTypeName = i.ServiceType.ServiceTypeName
                        }
                    })
                    .ToListAsync();

                card.Spares = await dbContext.JobCardSpares
                    .Include(s => s.Item)
                    .Where(s => s.ServiceRequestId == card.ServiceRequestId)
                    .Select(s => new JobCardSpareVM
                    {
                        JobCardSpareId = s.JobCardSpareId,
                        ServiceRequestId = s.ServiceRequestId,
                        Quantity = s.Quantity,
                        Mrp = s.Mrp,
                        Rate = s.Rate,
                        Amount = s.Amount,
                        DiscountInRs = s.DiscountInRs,
                        TaxableAmount = s.TaxableAmount,
                        GstPer = s.GstPer,
                        CgstPer = s.CgstPer,
                        SgstPer = s.SgstPer,
                        IgstPer = s.IgstPer,
                        CgstRs = s.CgstRs,
                        SgstRs = s.SgstRs,
                        IgstRs = s.IgstRs,
                        GstAmount = s.GstAmount,
                        TotalAmount = s.TotalAmount,
                        ItemModel = new ItemVM
                        {
                            ItemId = s.Item.ItemId,
                            ItemCode = s.Item.ItemCode,
                            ItemName = s.Item.ItemName,
                            Measure = s.Item.Measure
                        }
                    })
                    .ToListAsync();
            }

            return jobCards;
        }

        public async Task<JobCardVM?> GetJobCardDetails(int serviceRequestId)
        {
            var card = await dbContext.JobCards
                .Include(j => j.Party)
                .Where(j => j.ServiceRequestId == serviceRequestId)
                .Select(j => new JobCardVM
                {
                    ServiceRequestId = j.ServiceRequestId,
                    SalesId = j.SalesId,
                    ServiceRequestDate = j.ServiceRequestDate.ToString("dd-MMM-yyyy"),
                    ServiceRequestDescription = j.ServiceRequestDescription ?? string.Empty,
                    ServiceRequestStatusId = j.ServiceRequestStatusId,
                    PartyModel = new PartyVM
                    {
                        PartyId = j.Party.PartyId,
                        PartyName = j.Party.PartyName,
                        PartyMobile = j.Party.PartyMobile,
                        PartyAddress = j.Party.PartyAddress
                    }
                })
                .FirstOrDefaultAsync();

            if (card == null)
                return null;

            card.Complaints = await dbContext.JobCardItems
                .Include(i => i.ServiceType)
                .Where(i => i.ServiceRequestId == serviceRequestId)
                .Select(i => new JobCardItemVM
                {
                    ServiceRequestComplaintId = i.ServiceRequestComplaintId,
                    ServiceCharge = i.ServiceCharge,
                    ServiceTypeModel = new ServiceTypeVM
                    {
                        ServiceTypeId = i.ServiceType.ServiceTypeId,
                        ServiceTypeName = i.ServiceType.ServiceTypeName
                    }
                })
                .ToListAsync();

            card.Spares = await dbContext.JobCardSpares
                .Include(s => s.Item)
                .Where(s => s.ServiceRequestId == serviceRequestId)
                .Select(s => new JobCardSpareVM
                {
                    JobCardSpareId = s.JobCardSpareId,
                    ServiceRequestId = s.ServiceRequestId,
                    Quantity = s.Quantity,
                    Mrp = s.Mrp,
                    Rate = s.Rate,
                    Amount = s.Amount,
                    DiscountInRs = s.DiscountInRs,
                    TaxableAmount = s.TaxableAmount,
                    GstPer = s.GstPer,
                    CgstPer = s.CgstPer,
                    SgstPer = s.SgstPer,
                    IgstPer = s.IgstPer,
                    CgstRs = s.CgstRs,
                    SgstRs = s.SgstRs,
                    IgstRs = s.IgstRs,
                    GstAmount = s.GstAmount,
                    TotalAmount = s.TotalAmount,
                    ItemModel = new ItemVM
                    {
                        ItemId = s.Item.ItemId,
                        ItemCode = s.Item.ItemCode,
                        ItemName = s.Item.ItemName,
                        Measure = s.Item.Measure
                    }
                })
                .ToListAsync();

            return card;
        }

        public async Task<ResponseMessage> GetNextJobCardNumber()
        {
            int maxId = await dbContext.JobCards.AnyAsync()
                ? await dbContext.JobCards.MaxAsync(j => j.ServiceRequestId)
                : 0;
            int nextNo = maxId + 1;
            return new ResponseMessage(isSuccess: true, message: nextNo.ToString(), data: nextNo.ToString());
        }

        public async Task<ResponseMessage> DeleteJobCard(int serviceRequestId)
        {
            bool hasSales = await dbContext.Sales.AnyAsync(s => s.ServiceRequestId == serviceRequestId);
            if (hasSales)
            {
                return new ResponseMessage(isSuccess: false, message: "The job card cannot be deleted since it is associated with the sales invoice. To delete the job card, first delete the corresponding sales invoice.");
            }

            var jobCard = await dbContext.JobCards.FirstOrDefaultAsync(j => j.ServiceRequestId == serviceRequestId);
            if (jobCard == null)
            {
                return new ResponseMessage(isSuccess: false, message: "Job card not found.");
            }

            if (jobCard.ServiceRequestStatusId != 1)
            {
                return new ResponseMessage(isSuccess: false, message: "Only job cards with Pending status can be deleted.");
            }

            using var dbTrans = await dbContext.Database.BeginTransactionAsync();
            try
            {
                var items = await dbContext.JobCardItems.Where(i => i.ServiceRequestId == serviceRequestId).ToListAsync();
                if (items.Count > 0)
                    dbContext.JobCardItems.RemoveRange(items);

                var spares = await dbContext.JobCardSpares.Where(s => s.ServiceRequestId == serviceRequestId).ToListAsync();
                if (spares.Count > 0)
                    dbContext.JobCardSpares.RemoveRange(spares);

                dbContext.JobCards.Remove(jobCard);
                await SaveChangesAsync();
                await dbTrans.CommitAsync();
                return new ResponseMessage(isSuccess: true, message: "Job card deleted successfully.");
            }
            catch (Exception ex)
            {
                await dbTrans.RollbackAsync();
                return new ResponseMessage(isSuccess: false, message: ex.Message);
            }
        }

        public async Task<ResponseMessage> DeleteJobCardItem(int serviceRequestComplaintId)
        {
            var item = await dbContext.JobCardItems.FirstOrDefaultAsync(i => i.ServiceRequestComplaintId == serviceRequestComplaintId);
            if (item == null)
                return new ResponseMessage(isSuccess: false, message: "Service item could not be deleted. Please try again!");

            dbContext.JobCardItems.Remove(item);
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: AppConstants.RESPONSE_SUCCESS, data: serviceRequestComplaintId.ToString());
        }

        public async Task<ResponseMessage> DeleteJobCardSpare(int jobCardSpareId)
        {
            var spare = await dbContext.JobCardSpares.FirstOrDefaultAsync(s => s.JobCardSpareId == jobCardSpareId);
            if (spare == null)
                return new ResponseMessage(isSuccess: false, message: "Spare item could not be deleted. Please try again!");

            dbContext.JobCardSpares.Remove(spare);
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: AppConstants.RESPONSE_SUCCESS, data: jobCardSpareId.ToString());
        }

        public async Task<ResponseMessage> UpdateJobCardStatus(int serviceRequestId, int statusId)
        {
            var jobCard = await dbContext.JobCards.FirstOrDefaultAsync(j => j.ServiceRequestId == serviceRequestId);
            if (jobCard == null)
                return new ResponseMessage(isSuccess: false, message: "Job card not found.");

            jobCard.ServiceRequestStatusId = statusId;
            jobCard.UpdatedDate = DateTime.Now;
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: AppConstants.RESPONSE_SUCCESS);
        }

        public async Task<ResponseMessage> GenerateOrGetSalesInvoiceForJobCard(int jobCardId, int userRowId)
        {
            var existingSale = await dbContext.Sales.FirstOrDefaultAsync(s => s.ServiceRequestId == jobCardId);
            if (existingSale != null)
            {
                return new ResponseMessage(isSuccess: true, message: existingSale.SalesId.ToString(), data: existingSale.SalesId.ToString());
            }

            var jobCard = await GetJobCardDetails(jobCardId);
            if (jobCard == null || (jobCard.Complaints.Count == 0 && jobCard.Spares.Count == 0))
            {
                return new ResponseMessage(isSuccess: false, message: "0", data: "0");
            }

            using var dbTrans = await dbContext.Database.BeginTransactionAsync();
            try
            {
                double totalAmount = jobCard.Complaints.Sum(c => c.ServiceCharge) + jobCard.Spares.Sum(s => s.TotalAmount);
                DateTime invDate = DateTime.TryParse(jobCard.ServiceRequestDate, out var parsed) ? parsed : DateTime.Now.Date;

                var sale = new Sale
                {
                    PartyId = jobCard.PartyModel.PartyId,
                    InvoiceNo = string.Empty,
                    InvoiceDate = invDate,
                    SalesType = PaymentMode.Cash.ToString(),
                    PaymentMode = PaymentMode.Cash.ToString(),
                    UpiType = string.Empty,
                    PaidAmount = totalAmount,
                    BalanceAmount = 0.0,
                    Remarks = $"Service Invoice for Job Card #{jobCard.ServiceRequestId}",
                    CreatedBy = userRowId,
                    UpdatedBy = userRowId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsLocked = 1,
                    ServiceRequestId = jobCard.ServiceRequestId
                };

                await dbContext.Sales.AddAsync(sale);
                await SaveChangesAsync();

                var jcEntity = await dbContext.JobCards.FirstOrDefaultAsync(j => j.ServiceRequestId == jobCardId);
                if (jcEntity != null)
                {
                    jcEntity.SalesId = sale.SalesId;
                }

                foreach (var comp in jobCard.Complaints)
                {
                    await dbContext.SalesItems.AddAsync(new SalesItem
                    {
                        SalesId = sale.SalesId,
                        ServiceTypeId = comp.ServiceTypeModel.ServiceTypeId,
                        Quantity = 1.0f,
                        Mrp = (float)comp.ServiceCharge,
                        Rate = (float)comp.ServiceCharge,
                        Amount = comp.ServiceCharge,
                        DiscountInRs = 0.0,
                        TaxableAmount = comp.ServiceCharge,
                        GstPer = 0.0f,
                        CgstPer = 0.0f,
                        SgstPer = 0.0f,
                        IgstPer = 0.0f,
                        CgstRs = 0.0,
                        SgstRs = 0.0,
                        IgstRs = 0.0,
                        GstAmount = 0.0,
                        TotalAmount = comp.ServiceCharge,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = userRowId
                    });
                }

                foreach (var spare in jobCard.Spares)
                {
                    await dbContext.SalesItems.AddAsync(new SalesItem
                    {
                        SalesId = sale.SalesId,
                        ItemId = spare.ItemModel.ItemId,
                        Quantity = (float)spare.Quantity,
                        Mrp = (float)spare.Mrp,
                        Rate = (float)spare.Rate,
                        Amount = spare.Amount,
                        DiscountInRs = spare.DiscountInRs,
                        TaxableAmount = spare.TaxableAmount,
                        GstPer = spare.GstPer,
                        CgstPer = spare.CgstPer,
                        SgstPer = spare.SgstPer,
                        IgstPer = spare.IgstPer,
                        CgstRs = spare.CgstRs,
                        SgstRs = spare.SgstRs,
                        IgstRs = spare.IgstRs,
                        GstAmount = spare.GstAmount,
                        TotalAmount = spare.TotalAmount,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = userRowId
                    });
                }

                await dbContext.Transactions.AddAsync(new Transaction
                {
                    PartyId = jobCard.PartyModel.PartyId,
                    TransactionDate = invDate,
                    PaymentMode = PaymentMode.Cash.ToString(),
                    UpiType = string.Empty,
                    Remarks = $"Service Invoice for Job Card #{jobCard.ServiceRequestId}",
                    SalesId = sale.SalesId,
                    PaymentAmount = totalAmount,
                    ReceiptAmount = totalAmount,
                    TransactionType = TransType.SALES_CASH.ToString(),
                    CreatedBy = userRowId,
                    UpdatedBy = userRowId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });

                await SaveChangesAsync();
                await dbTrans.CommitAsync();
                return new ResponseMessage(isSuccess: true, message: sale.SalesId.ToString(), data: sale.SalesId.ToString());
            }
            catch (Exception ex)
            {
                await dbTrans.RollbackAsync();
                return new ResponseMessage(isSuccess: false, message: ex.Message, data: "0");
            }
        }

        public async Task<SalesVM> GetJobCardSalesInvoice(int jobCardId)
        {
            var salesInvoice = new SalesVM();
            var jobCard = await dbContext.JobCards
                .Include(j => j.Party)
                .FirstOrDefaultAsync(j => j.ServiceRequestId == jobCardId);

            if (jobCard == null)
                return salesInvoice;

            salesInvoice.JobCard = new JobCardVM
            {
                ServiceRequestId = jobCard.ServiceRequestId,
                PartyModel = new PartyVM
                {
                    PartyId = jobCard.Party.PartyId,
                    PartyName = jobCard.Party.PartyName
                }
            };

            var existingSale = await dbContext.Sales.FirstOrDefaultAsync(s => s.ServiceRequestId == jobCardId);
            if (existingSale != null)
            {
                var details = await GetSalesInvoiceDetails(existingSale.SalesId);
                details.JobCard = salesInvoice.JobCard;
                return details;
            }

            return salesInvoice;
        }

        #endregion
    }
}
