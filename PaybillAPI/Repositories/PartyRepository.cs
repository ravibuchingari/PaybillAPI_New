using Microsoft.EntityFrameworkCore;
using Paybill.Data;
using Paybill.DTO;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;

namespace Paybill.Repositories
{
    public class PartyRepository(AppDBContext dbContext) : RootRepository(dbContext ?? null), IPartyRepository
    {
        private static Party MapParty(PartyVM partyVM, Party party)
        {
            party.PartyName = partyVM.PartyName;
            party.PartyAddress = partyVM.PartyAddress;
            party.PartyShippingAddress = partyVM.PartyShippingAddress;
            party.PartyMobile = partyVM.PartyMobile;
            party.PartyEmail = partyVM.PartyEmail;
            party.PartyGstNo = partyVM.PartyGstNo;
            party.PartyRemarks = partyVM.PartyRemarks;
            party.IsVendor = (sbyte)(partyVM.IsVendor ? 1 : 0);
            party.IsActive = (sbyte)(partyVM.IsActive ? 1 : 0);
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
            return await dbContext.Parties.Where(col => col.IsVendor == (isVendor ? 1 : 0)).Select(row => new PartyVM()
            {
                PartyId = row.PartyId,
                PartyName = row.PartyName,
                PartyAddress = row.PartyAddress,
                PartyShippingAddress = row.PartyShippingAddress ?? string.Empty,
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
                PartyShippingAddress = row.PartyShippingAddress ?? string.Empty,
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
            return await dbContext.Parties.Where(col => col.IsActive == 1 && col.IsVendor == (isAll ? col.IsVendor : isVendor ? 1 : 0)).Select(row => new PartyVM()
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

        #region "Customer Rewards"

        public async Task<ResponseMessage> GetCustomerAvailablePoints(int partyId)
        {
            if (partyId <= 0)
                return new ResponseMessage(isSuccess: true, message: "0", data: "0");

            double available = await dbContext.RewardTransactions
                .Where(r => r.PartyId == partyId)
                .SumAsync(r => r.PointsCredited - r.PointsDebited);

            return new ResponseMessage(isSuccess: true, message: available.ToString("0.##"), data: available.ToString("0.##"));
        }

        public async Task<RewardCustomerSummaryVM> GetCustomerRewardsSummary(int partyId)
        {
            var summary = new RewardCustomerSummaryVM { PartyId = partyId };
            if (partyId <= 0)
                return summary;

            var party = await dbContext.Parties.AsNoTracking().FirstOrDefaultAsync(p => p.PartyId == partyId);
            if (party != null)
            {
                summary.PartyName = party.PartyName ?? string.Empty;
                summary.PartyMobile = party.PartyMobile ?? string.Empty;
            }

            var txns = await dbContext.RewardTransactions.AsNoTracking()
                .Where(r => r.PartyId == partyId)
                .ToListAsync();

            summary.TotalEarned = txns.Where(t => t.TransactionType == "EARNED").Sum(t => t.PointsCredited);
            summary.TotalRedeemed = txns.Where(t => t.TransactionType == "REDEEMED").Sum(t => t.PointsDebited);
            summary.TotalExpired = txns.Where(t => t.TransactionType == "EXPIRED").Sum(t => t.PointsDebited);
            summary.TotalReversed = txns.Where(t => t.TransactionType == "REVERSED").Sum(t => t.PointsDebited - t.PointsCredited);
            summary.TotalAdjusted = txns.Where(t => t.TransactionType == "ADJUSTMENT").Sum(t => t.PointsCredited - t.PointsDebited);
            summary.AvailablePoints = txns.Sum(t => t.PointsCredited - t.PointsDebited);

            var setting = await dbContext.Settings.AsNoTracking().FirstOrDefaultAsync();
            double pointVal = (setting != null && setting.RewardPointValue > 0) ? setting.RewardPointValue : 1.0;
            summary.PointsValue = summary.AvailablePoints * pointVal;

            return summary;
        }

        public async Task<List<RewardTransactionVM>> GetRewardsTransactions(
            int? partyId,
            int? salesId,
            string? fromDate,
            string? toDate,
            string? transType,
            string? searchQuery)
        {
            var query = dbContext.RewardTransactions.AsNoTracking()
                .Include(r => r.Party)
                .Include(r => r.Sales)
                .AsQueryable();

            if (partyId != null && partyId > 0)
                query = query.Where(r => r.PartyId == partyId.Value);

            if (salesId != null && salesId > 0)
                query = query.Where(r => r.SalesId == salesId.Value);

            if (!string.IsNullOrWhiteSpace(fromDate) && DateTime.TryParse(fromDate, out var fDate))
                query = query.Where(r => r.TransactionDate.Date >= fDate.Date);

            if (!string.IsNullOrWhiteSpace(toDate) && DateTime.TryParse(toDate, out var tDate))
                query = query.Where(r => r.TransactionDate.Date <= tDate.Date);

            if (!string.IsNullOrWhiteSpace(transType) && !string.Equals(transType, "ALL", StringComparison.OrdinalIgnoreCase))
                query = query.Where(r => r.TransactionType == transType);

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                string q = searchQuery.Trim().ToLower();
                query = query.Where(r =>
                    (r.Party != null && r.Party.CustomerName.ToLower().Contains(q)) ||
                    (r.Party != null && r.Party.Mobile != null && r.Party.Mobile.ToLower().Contains(q)) ||
                    (r.Sales != null && r.Sales.InvoiceNo.ToLower().Contains(q)));
            }

            return await query
                .OrderByDescending(r => r.RewardTransId)
                .Select(r => new RewardTransactionVM
                {
                    RewardTransId = r.RewardTransId,
                    PartyId = r.PartyId,
                    SalesId = r.SalesId ?? 0,
                    TransactionType = r.TransactionType,
                    PointsCredited = r.PointsCredited,
                    PointsDebited = r.PointsDebited,
                    MonetaryValue = r.MonetaryValue,
                    TransactionDate = r.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    Description = r.Description ?? string.Empty,
                    RefTransId = r.RefTransId ?? 0,
                    CreatedBy = r.CreatedBy ?? 0,
                    PartyName = r.Party != null ? r.Party.CustomerName : string.Empty,
                    PartyMobile = r.Party != null ? r.Party.Mobile ?? string.Empty : string.Empty,
                    InvoiceNo = r.Sales != null ? r.Sales.InvoiceNo : string.Empty
                })
                .ToListAsync();
        }

        public async Task<ResponseMessage> SaveManualRewardAdjustment(RewardAdjustmentRequestVM request, int userRowId)
        {
            if (request.PartyId <= 0)
                return new ResponseMessage(isSuccess: false, message: "Invalid customer selected.");
            if (request.Points == 0.0)
                return new ResponseMessage(isSuccess: false, message: "Adjustment points cannot be zero.");

            var entity = new RewardTransaction
            {
                PartyId = request.PartyId,
                TransactionType = "ADJUSTMENT",
                PointsCredited = request.Points > 0 ? request.Points : 0.0,
                PointsDebited = request.Points < 0 ? Math.Abs(request.Points) : 0.0,
                MonetaryValue = 0.0,
                TransactionDate = DateTime.Now,
                Description = string.IsNullOrWhiteSpace(request.Reason) ? "Manual Points Adjustment" : request.Reason,
                CreatedBy = userRowId
            };

            await dbContext.RewardTransactions.AddAsync(entity);
            await SaveChangesAsync();
            return new ResponseMessage(isSuccess: true, message: AppConstants.RESPONSE_SUCCESS, data: entity.RewardTransId.ToString());
        }

        public async Task<List<RewardCustomerSummaryVM>> GetAllCustomerRewardsSummary(
            string? fromDate,
            string? toDate,
            string? searchQuery)
        {
            var setting = await dbContext.Settings.AsNoTracking().FirstOrDefaultAsync();
            double pointVal = (setting != null && setting.RewardPointValue > 0) ? setting.RewardPointValue : 1.0;

            var partiesQuery = dbContext.Parties.AsNoTracking()
                .Where(p => p.IsVendor == 0 && p.IsActive == 1);

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                string q = searchQuery.Trim().ToLower();
                partiesQuery = partiesQuery.Where(p =>
                    p.PartyName.ToLower().Contains(q) ||
                    (p.PartyMobile != null && p.PartyMobile.ToLower().Contains(q)));
            }

            var parties = await partiesQuery.OrderBy(p => p.PartyName).ToListAsync();
            var allTxns = await dbContext.RewardTransactions.AsNoTracking().ToListAsync();

            DateTime? fDate = (!string.IsNullOrWhiteSpace(fromDate) && DateTime.TryParse(fromDate, out var fd)) ? fd.Date : null;
            DateTime? tDate = (!string.IsNullOrWhiteSpace(toDate) && DateTime.TryParse(toDate, out var td)) ? td.Date : null;

            var result = new List<RewardCustomerSummaryVM>();
            foreach (var p in parties)
            {
                var pAll = allTxns.Where(t => t.PartyId == p.PartyId).ToList();
                var pPeriod = pAll.Where(t =>
                    (fDate == null || t.TransactionDate.Date >= fDate.Value) &&
                    (tDate == null || t.TransactionDate.Date <= tDate.Value)).ToList();

                double avail = pAll.Sum(t => t.PointsCredited - t.PointsDebited);
                result.Add(new RewardCustomerSummaryVM
                {
                    PartyId = p.PartyId,
                    PartyName = p.PartyName,
                    PartyMobile = p.PartyMobile ?? string.Empty,
                    TotalEarned = pPeriod.Where(t => t.TransactionType == "EARNED").Sum(t => t.PointsCredited),
                    TotalRedeemed = pPeriod.Where(t => t.TransactionType == "REDEEMED").Sum(t => t.PointsDebited),
                    TotalExpired = pPeriod.Where(t => t.TransactionType == "EXPIRED").Sum(t => t.PointsDebited),
                    TotalReversed = pPeriod.Where(t => t.TransactionType == "REVERSED").Sum(t => t.PointsDebited - t.PointsCredited),
                    TotalAdjusted = pPeriod.Where(t => t.TransactionType == "ADJUSTMENT").Sum(t => t.PointsCredited - t.PointsDebited),
                    AvailablePoints = avail,
                    PointsValue = avail * pointVal
                });
            }

            return result;
        }

        public async Task<RewardOverallSummaryVM> GetOverallRewardsSummary()
        {
            var summary = new RewardOverallSummaryVM();
            var allTxns = await dbContext.RewardTransactions.AsNoTracking().ToListAsync();

            summary.TotalPointsEarned = allTxns.Where(t => t.TransactionType == "EARNED").Sum(t => t.PointsCredited);
            summary.TotalPointsRedeemed = allTxns.Where(t => t.TransactionType == "REDEEMED").Sum(t => t.PointsDebited);
            summary.TotalPointsExpired = allTxns.Where(t => t.TransactionType == "EXPIRED").Sum(t => t.PointsDebited);
            summary.TotalPointsReversedOrAdjusted = allTxns
                .Where(t => t.TransactionType == "REVERSED" || t.TransactionType == "ADJUSTMENT")
                .Sum(t => t.PointsCredited - t.PointsDebited);

            var byCustomer = allTxns
                .GroupBy(t => t.PartyId)
                .Select(g => new { PartyId = g.Key, Balance = g.Sum(x => x.PointsCredited - x.PointsDebited) })
                .Where(x => x.Balance > 0)
                .ToList();

            summary.TotalCustomersWithBalance = byCustomer.Count;
            summary.TotalOutstandingPoints = byCustomer.Sum(x => x.Balance);

            var setting = await dbContext.Settings.AsNoTracking().FirstOrDefaultAsync();
            double pointVal = (setting != null && setting.RewardPointValue > 0) ? setting.RewardPointValue : 1.0;
            summary.TotalOutstandingValue = summary.TotalOutstandingPoints * pointVal;

            return summary;
        }

        public async Task<List<RewardRedemptionDetailVM>> GetRedemptionDetails(
            string? specificDate,
            string? fromDate,
            string? toDate,
            string? searchQuery,
            string? filterInvoiceNo)
        {
            var allTxns = await dbContext.RewardTransactions.AsNoTracking()
                .Include(r => r.Party)
                .Include(r => r.Sales)
                .ToListAsync();

            var redeemed = allTxns.Where(r => r.TransactionType == "REDEEMED").AsEnumerable();

            if (!string.IsNullOrWhiteSpace(specificDate) && DateTime.TryParse(specificDate, out var sDate))
            {
                redeemed = redeemed.Where(r => r.TransactionDate.Date == sDate.Date);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(fromDate) && DateTime.TryParse(fromDate, out var fDate))
                    redeemed = redeemed.Where(r => r.TransactionDate.Date >= fDate.Date);
                if (!string.IsNullOrWhiteSpace(toDate) && DateTime.TryParse(toDate, out var tDate))
                    redeemed = redeemed.Where(r => r.TransactionDate.Date <= tDate.Date);
            }

            if (!string.IsNullOrWhiteSpace(filterInvoiceNo))
            {
                string invFilter = filterInvoiceNo.Trim().ToLower();
                redeemed = redeemed.Where(r => r.Sales != null && r.Sales.InvoiceNo.ToLower().Contains(invFilter));
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                string q = searchQuery.Trim().ToLower();
                redeemed = redeemed.Where(r =>
                    (r.Party != null && r.Party.CustomerName.ToLower().Contains(q)) ||
                    (r.Party != null && r.Party.Mobile != null && r.Party.Mobile.ToLower().Contains(q)) ||
                    (r.Sales != null && r.Sales.InvoiceNo.ToLower().Contains(q)));
            }

            var result = new List<RewardRedemptionDetailVM>();
            foreach (var r in redeemed.OrderByDescending(x => x.RewardTransId))
            {
                double runningBal = allTxns
                    .Where(t => t.PartyId == r.PartyId && t.RewardTransId <= r.RewardTransId)
                    .Sum(t => t.PointsCredited - t.PointsDebited);

                bool isReversed = allTxns.Any(t => t.RefTransId == r.RewardTransId && t.TransactionType == "REVERSED");
                double preDiscount = r.Sales != null ? (r.Sales.PaidAmount + r.Sales.BalanceAmount + r.Sales.RewardDiscountAmount) : 0.0;

                result.Add(new RewardRedemptionDetailVM
                {
                    RewardTransId = r.RewardTransId,
                    PartyId = r.PartyId,
                    PartyName = r.Party?.CustomerName ?? string.Empty,
                    PartyMobile = r.Party?.Mobile ?? string.Empty,
                    SalesId = r.SalesId ?? 0,
                    InvoiceNo = r.Sales?.InvoiceNo ?? string.Empty,
                    TransactionDate = r.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    PreDiscountAmount = preDiscount,
                    PointsRedeemed = r.PointsDebited,
                    MonetaryValue = r.MonetaryValue,
                    RemainingPointsBalance = runningBal,
                    Status = isReversed ? "REVERSED" : "SUCCESS"
                });
            }

            return result;
        }

        public async Task<ResponseMessage> GetCustomerEarliestUpcomingExpiryDate(int partyId)
        {
            if (partyId <= 0)
                return new ResponseMessage(isSuccess: true, message: string.Empty, data: string.Empty);

            var setting = await dbContext.Settings.AsNoTracking().FirstOrDefaultAsync();
            if (setting == null || setting.RewardIsExpiryEnabled == 0)
                return new ResponseMessage(isSuccess: true, message: "No expiry", data: "No expiry");

            int expiryDays = setting.RewardExpiryDays > 0 ? setting.RewardExpiryDays : 365;
            var txns = await dbContext.RewardTransactions.AsNoTracking()
                .Where(r => r.PartyId == partyId)
                .OrderBy(r => r.RewardTransId)
                .ToListAsync();

            double totalDebited = 0.0;
            var credits = new List<(double Credited, DateTime Date)>();

            foreach (var t in txns)
            {
                if (t.TransactionType == "REDEEMED" || t.TransactionType == "EXPIRED" || t.TransactionType == "REVERSED")
                {
                    totalDebited += t.PointsDebited;
                }
                else if (t.TransactionType == "ADJUSTMENT")
                {
                    if (t.PointsDebited > 0)
                        totalDebited += t.PointsDebited;
                    else if (t.PointsCredited > 0)
                        credits.Add((t.PointsCredited, t.TransactionDate.Date));
                }
                else if (t.TransactionType == "EARNED" && t.PointsCredited > 0)
                {
                    credits.Add((t.PointsCredited, t.TransactionDate.Date));
                }
            }

            if (credits.Count == 0)
                return new ResponseMessage(isSuccess: true, message: string.Empty, data: string.Empty);

            DateTime today = DateTime.Now.Date;
            double remainingDebits = totalDebited;
            DateTime? earliestExpiryDate = null;

            foreach (var batch in credits)
            {
                double activePoints = batch.Credited;
                if (remainingDebits > 0)
                {
                    if (remainingDebits >= activePoints)
                    {
                        remainingDebits -= activePoints;
                        activePoints = 0.0;
                    }
                    else
                    {
                        activePoints -= remainingDebits;
                        remainingDebits = 0.0;
                    }
                }

                if (activePoints > 0)
                {
                    DateTime expDate = batch.Date.AddDays(expiryDays).Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                    if (expDate >= today)
                    {
                        if (earliestExpiryDate == null || expDate < earliestExpiryDate.Value)
                        {
                            earliestExpiryDate = expDate;
                        }
                    }
                }
            }

            string formatted = earliestExpiryDate != null ? earliestExpiryDate.Value.ToString("dd-MM-yyyy") : string.Empty;
            return new ResponseMessage(isSuccess: true, message: formatted, data: formatted);
        }

        public async Task<ResponseMessage> ExpireOldPoints(int userRowId)
        {
            var setting = await dbContext.Settings.AsNoTracking().FirstOrDefaultAsync();
            if (setting == null || setting.RewardIsExpiryEnabled == 0)
                return new ResponseMessage(isSuccess: true, message: "0", data: "0");

            int expiryDays = setting.RewardExpiryDays > 0 ? setting.RewardExpiryDays : 365;
            DateTime today = DateTime.Now.Date;

            var allTxns = await dbContext.RewardTransactions.OrderBy(r => r.RewardTransId).ToListAsync();
            var byParty = allTxns.GroupBy(r => r.PartyId);

            int expiredCount = 0;
            double totalExpiredPoints = 0.0;

            foreach (var group in byParty)
            {
                double totalDebited = 0.0;
                var credits = new List<(double Credited, DateTime Date)>();

                foreach (var t in group)
                {
                    if (t.TransactionType == "REDEEMED" || t.TransactionType == "EXPIRED" || t.TransactionType == "REVERSED")
                        totalDebited += t.PointsDebited;
                    else if (t.TransactionType == "ADJUSTMENT")
                    {
                        if (t.PointsDebited > 0) totalDebited += t.PointsDebited;
                        else if (t.PointsCredited > 0) credits.Add((t.PointsCredited, t.TransactionDate.Date));
                    }
                    else if (t.TransactionType == "EARNED" && t.PointsCredited > 0)
                        credits.Add((t.PointsCredited, t.TransactionDate.Date));
                }

                double remainingDebits = totalDebited;
                double partyExpired = 0.0;

                foreach (var batch in credits)
                {
                    double activePoints = batch.Credited;
                    if (remainingDebits > 0)
                    {
                        if (remainingDebits >= activePoints)
                        {
                            remainingDebits -= activePoints;
                            activePoints = 0.0;
                        }
                        else
                        {
                            activePoints -= remainingDebits;
                            remainingDebits = 0.0;
                        }
                    }

                    if (activePoints > 0)
                    {
                        DateTime expDate = batch.Date.AddDays(expiryDays).Date;
                        if (expDate < today)
                        {
                            partyExpired += activePoints;
                        }
                    }
                }

                if (partyExpired > 0.001)
                {
                    double pointVal = setting.RewardPointValue > 0 ? setting.RewardPointValue : 1.0;
                    await dbContext.RewardTransactions.AddAsync(new RewardTransaction
                    {
                        PartyId = group.Key,
                        SalesId = 0,
                        TransactionType = "EXPIRED",
                        PointsCredited = 0.0,
                        PointsDebited = Math.Round(partyExpired, 2),
                        MonetaryValue = Math.Round(partyExpired * pointVal, 2),
                        TransactionDate = DateTime.Now,
                        Description = $"Auto-expired points older than {expiryDays} days",
                        RefTransId = 0,
                        CreatedBy = userRowId
                    });
                    expiredCount++;
                    totalExpiredPoints += partyExpired;
                }
            }

            if (expiredCount > 0)
                await SaveChangesAsync();

            return new ResponseMessage(isSuccess: true, message: Math.Round(totalExpiredPoints, 2).ToString(), data: expiredCount.ToString());
        }

        #endregion
    }
}
