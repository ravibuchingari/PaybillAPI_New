using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface ITransactionRepository
    {
        Task<ResponseMessage> DeleteTransaction(int transactionId, int userRowId);
        Task<IEnumerable<TransactionVM>> GetTodayTransactions(bool isPayment);
        Task<IEnumerable<TransactionVM>> GetTransactions(DateTime fromDate, DateTime toDate, int isPayment);
        Task<ResponseMessage> SaveTransaction(TransactionVM transactionVM, int userRowId);
    }
}
