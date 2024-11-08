using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories
{
    public class TransactionRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), ITransactionRepository
    {
        public async Task<ResponseMessage> SaveTransaction(TransactionVM transactionVM, int userRowId)
        {
            Transaction transaction = new()
            {
                PartyId = transactionVM.PartyModel.PartyId,
                TransactionDate = DateTime.Parse(transactionVM.TransactionDate),
                ReceiptAmount = transactionVM.ReceiptAmount,
                PaymentAmount = transactionVM.PaymentAmount,
                PaymentMode = transactionVM.PaymentMode,
                UpiType = transactionVM.UpiType,
                Remarks = transactionVM.Remarks,
                TransactionType = transactionVM.TransactionType,
                CreatedBy = userRowId,
                UpdatedBy = userRowId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            await dbContext.Transactions.AddAsync(transaction);
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: "Transaction saved successfully.");
        }

        public async Task<ResponseMessage> DeleteTransaction(int transactionId, int userRowId)
        {
            Transaction? transaction = await dbContext.Transactions.FindAsync(transactionId);
            if (transaction == null)
                return new ResponseMessage(isSuccess: false, message: "Transaction not found.");
            dbContext.Transactions.Remove(transaction);
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: "Transaction deleted successfully.");
        }

        public async Task<IEnumerable<TransactionVM>> GetTodayTransactions(bool isPayment)
        {
            if (isPayment)
            {
                return await dbContext.Transactions.Where(col => col.SalesId == null && col.PurchaseId == null && col.CreatedDate.Date == DateTime.Now.Date && col.PaymentAmount > 0).Select(row => new TransactionVM()
                {
                    TransactionId = row.TransactionId,
                    TransactionDate = row.TransactionDate.ToString("dd-MMM-yyyy"),
                    ReceiptAmount = row.ReceiptAmount,
                    PaymentAmount = row.PaymentAmount,
                    TransactionType = row.TransactionType,
                    PaymentMode = row.PaymentMode ?? string.Empty,
                    UpiType = row.UpiType,
                    Remarks = row.Remarks ?? string.Empty,
                    CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy hh:mm tt"),
                    PartyModel = new PartyVM()
                    {
                        PartyId = row.Party.PartyId,
                        PartyName = row.Party.PartyName,
                        PartyMobile = row.PaymentMode
                    }

                }).ToListAsync();
            }
            else
            {
                return await dbContext.Transactions.Where(col => col.SalesId == null && col.PurchaseId == null && col.CreatedDate.Date == DateTime.Now.Date && col.ReceiptAmount > 0).Select(row => new TransactionVM()
                {
                    TransactionId = row.TransactionId,
                    TransactionDate = row.TransactionDate.ToString("dd-MMM-yyyy"),
                    ReceiptAmount = row.ReceiptAmount,
                    PaymentAmount = row.PaymentAmount,
                    TransactionType = row.TransactionType,
                    PaymentMode = row.PaymentMode ?? string.Empty,
                    UpiType = row.UpiType,
                    Remarks = row.Remarks ?? string.Empty,
                    CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy hh:mm tt"),
                    PartyModel = new PartyVM()
                    {
                        PartyId = row.Party.PartyId,
                        PartyName = row.Party.PartyName,
                        PartyMobile = row.PaymentMode
                    }

                }).ToListAsync();
            }

        }

        public async Task<IEnumerable<TransactionVM>> GetTransactions(DateTime fromDate, DateTime toDate, int isPayment)
        {
            if (isPayment == 1)
            {
                return await dbContext.Transactions.Where(col => col.SalesId == null && col.PurchaseId == null && col.CreatedDate.Date >= fromDate.Date && col.CreatedDate.Date <= toDate.Date && col.PaymentAmount > 0).Select(row => new TransactionVM()
                {
                    TransactionId = row.TransactionId,
                    TransactionDate = row.TransactionDate.ToString("dd-MMM-yyyy"),
                    ReceiptAmount = row.ReceiptAmount,
                    PaymentAmount = row.PaymentAmount,
                    TransactionType = row.TransactionType,
                    PaymentMode = row.PaymentMode ?? string.Empty,
                    UpiType = row.UpiType,
                    Remarks = row.Remarks ?? string.Empty,
                    CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy hh:mm tt"),
                    PartyModel = new PartyVM()
                    {
                        PartyId = row.Party.PartyId,
                        PartyName = row.Party.PartyName,
                        PartyMobile = row.PaymentMode
                    }

                }).ToListAsync();
            }
            else if (isPayment == 0)
            {
                return await dbContext.Transactions.Where(col => col.SalesId == null && col.PurchaseId == null && col.CreatedDate.Date >= fromDate.Date && col.CreatedDate.Date <= toDate.Date && col.ReceiptAmount > 0).Select(row => new TransactionVM()
                {
                    TransactionId = row.TransactionId,
                    TransactionDate = row.TransactionDate.ToString("dd-MMM-yyyy"),
                    ReceiptAmount = row.ReceiptAmount,
                    PaymentAmount = row.PaymentAmount,
                    TransactionType = row.TransactionType,
                    PaymentMode = row.PaymentMode ?? string.Empty,
                    UpiType = row.UpiType,
                    Remarks = row.Remarks ?? string.Empty,
                    CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy hh:mm tt"),
                    PartyModel = new PartyVM()
                    {
                        PartyId = row.Party.PartyId,
                        PartyName = row.Party.PartyName,
                        PartyMobile = row.PaymentMode
                    }

                }).ToListAsync();
            }
            else
            {
                return await dbContext.Transactions.Where(col => col.SalesId == null && col.PurchaseId == null && col.CreatedDate.Date >= fromDate.Date && col.CreatedDate.Date <= toDate.Date).Select(row => new TransactionVM()
                {
                    TransactionId = row.TransactionId,
                    TransactionDate = row.TransactionDate.ToString("dd-MMM-yyyy"),
                    ReceiptAmount = row.ReceiptAmount,
                    PaymentAmount = row.PaymentAmount,
                    TransactionType = row.TransactionType,
                    PaymentMode = row.PaymentMode ?? string.Empty,
                    UpiType = row.UpiType,
                    Remarks = row.Remarks ?? string.Empty,
                    CreatedDate = row.CreatedDate.ToString("dd-MMM-yyyy hh:mm tt"),
                    PartyModel = new PartyVM()
                    {
                        PartyId = row.Party.PartyId,
                        PartyName = row.Party.PartyName,
                        PartyMobile = row.PaymentMode
                    }

                }).ToListAsync();
            }
        }

        public async Task<List<TransactionVM>> GetPartyLedger(ReportParam reportParam)
        {
            return await dbContext.Transactions.Where(col => col.PartyId == int.Parse(reportParam.Id!) && col.TransactionDate.Date >= Convert.ToDateTime(reportParam.FromDate).Date && col.TransactionDate <= Convert.ToDateTime(reportParam.ToDate).Date).OrderBy(ord => ord.TransactionDate).Select(row => new TransactionVM()
            {
                TransactionId = row.TransactionId,
                TransactionDate = row.TransactionDate.ToString("dd-MMM-yyyy"),
                TransactionRefNo = row.Sales != null ? row.Sales.InvoiceNo : (row.Purchase != null ? row.Purchase.InvoiceNo : ""),
                TransactionType = row.TransactionType,
                PaymentMode = row.PaymentMode,
                UpiType = row.UpiType,
                ReceiptAmount = row.ReceiptAmount,
                PaymentAmount = row.PaymentAmount,
                Remarks = row.Remarks ?? string.Empty,
            }).ToListAsync();
        }

        public async Task<List<BalanceSheet>> GetBalanceSheet()
        {
            return await dbContext.Parties.OrderBy(ord => ord.PartyName).Select(row => new BalanceSheet()
            {
                PartyModel = new PartyVM()
                {
                    PartyId = row.PartyId,
                    PartyName = row.PartyName,
                    PartyMobile = row.PartyMobile,
                    PartyAddress = row.PartyAddress
                },
                TotalReceiptAmount = row.Transactions.Where(p => p.PartyId == row.PartyId).Sum(sm => sm.ReceiptAmount),
                TotalPaymentAmount = row.Transactions.Where(p => p.PartyId == row.PartyId).Sum(sm => sm.PaymentAmount),
                Balance = row.Transactions.Where(p => p.PartyId == row.PartyId).Sum(sm => sm.ReceiptAmount) - row.Transactions.Where(p => p.PartyId == row.PartyId).Sum(sm => sm.PaymentAmount)
            }).ToListAsync();
        }

    }
}
