using PaybillAPI.Models;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories.Service
{
    public interface IPartyRepository
    {
        Task<ResponseMessage> DeleteParty(int partyId, bool isVendor);
        Task<IEnumerable<PartyVM>> GetActiveParties(bool isVendor, bool isAll);
        Task<IEnumerable<PartyVM>> GetParties(bool isVendor);
        Task<PartyVM> GetPartyDetails(int partyId);
        Task<ResponseMessage> UpsertParty(PartyVM partyVM, int userRowId);

        // Customer Rewards
        Task<ResponseMessage> GetCustomerAvailablePoints(int partyId);
        Task<RewardCustomerSummaryVM> GetCustomerRewardsSummary(int partyId);
        Task<List<RewardTransactionVM>> GetRewardsTransactions(int? partyId, int? salesId, string? fromDate, string? toDate, string? transType, string? searchQuery);
        Task<ResponseMessage> SaveManualRewardAdjustment(RewardAdjustmentRequestVM request, int userRowId);
        Task<List<RewardCustomerSummaryVM>> GetAllCustomerRewardsSummary(string? fromDate, string? toDate, string? searchQuery);
        Task<RewardOverallSummaryVM> GetOverallRewardsSummary();
        Task<List<RewardRedemptionDetailVM>> GetRedemptionDetails(string? specificDate, string? fromDate, string? toDate, string? searchQuery, string? filterInvoiceNo);
        Task<ResponseMessage> GetCustomerEarliestUpcomingExpiryDate(int partyId);
    }
}
