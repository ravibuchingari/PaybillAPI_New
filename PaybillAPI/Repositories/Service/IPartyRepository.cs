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
    }
}
