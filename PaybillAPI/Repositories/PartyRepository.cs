using Microsoft.EntityFrameworkCore;
using PaybillAPI.Data;
using PaybillAPI.DTO;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;

namespace PaybillAPI.Repositories
{
    public class PartyRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), IPartyRepository
    {

        private static Party MapParty(PartyVM partyVM, Party party)
        {
            party.PartyName = partyVM.PartyName;
            party.PartyAddress = partyVM.PartyAddress;
            party.PartyMobile = partyVM.PartyMobile;
            party.PartyEmail = partyVM.PartyEmail;
            party.PartyGstNo = partyVM.PartyGstNo;
            party.PartyRemarks = partyVM.PartyRemarks;
            party.IsVendor = (sbyte)partyVM.IsVendor.GetHashCode();
            party.IsActive = (sbyte)partyVM.IsActive.GetHashCode();
            return party;
        }

        public async Task<ResponseMessage> UpsertParty(PartyVM partyVM, int userRowId)
        {
            string partyType = partyVM.IsVendor ? "Vendor" : "Party";
            Party? party;
            if (partyVM.PartyId == 0)
            {
                party = MapParty(partyVM, new Party());
                party.CreatedDate = DateTime.Now;
                party.CreatedBy = userRowId;
                party.UpdatedDate = DateTime.Now;
                party.UpdatedBy = userRowId;
                await dbContext.Parties.AddAsync(party);
            }
            else
            {
                party = await dbContext.Parties.Where(col => col.PartyId == partyVM.PartyId).FirstOrDefaultAsync();
                if (party == null)
                    return new ResponseMessage(isSuccess: false, message: string.Format(AppConstants.ITEM_NOT_FOUND, partyType));
                party = MapParty(partyVM, party);
                party.UpdatedDate = DateTime.Now;
                party.UpdatedBy = userRowId;
            }
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: $"{(partyVM.PartyId == 0 ? $"{partyType} created successfully" : $"{partyType} updated successfully")}", data: party.PartyId.ToString());
        }

        public async Task<IEnumerable<PartyVM>> GetParties(bool isVendor)
        {
            return await dbContext.Parties.Where(col => col.IsVendor == isVendor.GetHashCode()).Select(row => new PartyVM()
            {
                PartyId = row.PartyId,
                PartyName = row.PartyName,
                PartyAddress = row.PartyAddress,
                PartyMobile = row.PartyMobile,
                PartyEmail = row.PartyEmail,
                PartyGstNo = row.PartyGstNo,
                PartyRemarks = row.PartyRemarks,
                IsActive = row.IsActive == 1
            }).ToListAsync();
        }

        public async Task<PartyVM> GetPartyDetails(int partyId)
        {
            PartyVM? partyVM = await dbContext.Parties.Select(row => new PartyVM()
            {
                PartyId = row.PartyId,
                PartyName = row.PartyName,
                PartyAddress = row.PartyAddress,
                PartyMobile = row.PartyMobile,
                PartyEmail = row.PartyEmail,
                PartyGstNo = row.PartyGstNo,
                PartyRemarks = row.PartyRemarks,
                IsVendor = row.IsVendor == 1,
                IsActive = row.IsActive == 1
            }).FirstOrDefaultAsync(col => col.PartyId == partyId);

            if (partyVM != null)
                return partyVM;
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, "Party"));
        }

        public async Task<ResponseMessage> DeleteParty(int partyId, bool isVendor)
        {
            Party? party = await dbContext.Parties.FirstOrDefaultAsync(col => col.PartyId == partyId);
            if (party != null)
            {
                dbContext.Parties.Remove(party);
                await SaveChangesAsync();
                return new ResponseMessage(isSuccess: true, message: string.Format(AppConstants.ITEM_DELETED, isVendor ? "vendor" : "party"));
            }
            else
                throw new Exception(string.Format(AppConstants.ITEM_NOT_FOUND, isVendor ? "Vendor" : "Party"));
        }

        public async Task<IEnumerable<PartyVM>> GetActiveParties(bool isVendor, bool isAll)
        {
            return await dbContext.Parties.Where(col => col.IsActive == 1 && col.IsVendor == (isAll ? col.IsVendor : isVendor.GetHashCode())).Select(row => new PartyVM()
            {
                PartyId = row.PartyId,
                PartyName = row.PartyName,
                PartyAddress = row.PartyAddress,
                PartyMobile = row.PartyMobile,
                PartyEmail = row.PartyEmail,
                PartyGstNo = row.PartyGstNo,
                PartyRemarks = row.PartyRemarks
            }).ToListAsync();
        }

    }
}
