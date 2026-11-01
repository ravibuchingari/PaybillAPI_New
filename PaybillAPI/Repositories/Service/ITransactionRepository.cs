using Paybill.Models;
using Paybill.ViewModel;

namespace Paybill.Repositories.Service
{
    public interface ITransactionRepository
    {
        Task<ResponseMessage> DeleteTransaction(int transactionId, string remarks, int userRowId);
        Task<List<BalanceSheet>> GetBalanceSheet();
        Task<List<TransactionVM>> GetPartyLedger(ReportParam reportParam);
        Task<IEnumerable<TransactionVM>> GetTodayTransactions(bool isPayment);
        Task<IEnumerable<TransactionVM>> GetTransactions(DateTime fromDate, DateTime toDate, int isPayment);
        Task<ResponseMessage> SaveTransaction(TransactionVM transactionVM, int userRowId);
    }
}
