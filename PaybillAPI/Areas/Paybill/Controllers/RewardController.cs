using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class RewardController(
        IPartyRepository partyRepository,
        IAdminRepository adminRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(string tab = "summary", string? fromDate = null, string? toDate = null, string? searchQuery = null, int? partyId = null)
        {
            string start = string.IsNullOrWhiteSpace(fromDate)
                ? DateTime.Today.AddMonths(-3).ToString("yyyy-MM-dd")
                : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate)
                ? DateTime.Today.ToString("yyyy-MM-dd")
                : toDate;

            var settings = await adminRepository.GetSettings() ?? new SettingVM();
            var overallSummary = await partyRepository.GetOverallRewardsSummary();
            var customerSummaries = await partyRepository.GetAllCustomerRewardsSummary(start, end, searchQuery);
            var transactions = await partyRepository.GetRewardsTransactions(partyId, null, start, end, null, searchQuery);
            var redemptions = await partyRepository.GetRedemptionDetails(null, start, end, searchQuery, null);
            var customers = (await partyRepository.GetActiveParties(isVendor: false, isAll: false)).ToList();

            var vm = new RewardsDashboardViewModel
            {
                Settings = settings,
                OverallSummary = overallSummary,
                CustomerSummaries = customerSummaries,
                Transactions = transactions,
                Redemptions = redemptions,
                Customers = customers,
                ActiveTab = tab,
                FromDate = start,
                ToDate = end,
                SearchQuery = searchQuery,
                SelectedPartyId = partyId
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdjustPoints(int partyId, double points, string reason)
        {
            if (partyId <= 0 || Math.Abs(points) < 0.01)
            {
                TempData["ErrorMessage"] = "Please select a customer and enter a non-zero points adjustment.";
                return RedirectToAction(nameof(Index), new { tab = "transactions" });
            }

            try
            {
                var res = await partyRepository.SaveManualRewardAdjustment(new RewardAdjustmentRequestVM
                {
                    PartyId = partyId,
                    Points = points,
                    Reason = string.IsNullOrWhiteSpace(reason) ? "Manual Adjustment" : reason.Trim(),
                    UserRowId = CurrentUserRowId
                }, CurrentUserRowId);

                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Reward points adjusted successfully.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to adjust reward points.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "transactions" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExpirePoints()
        {
            try
            {
                var res = await partyRepository.ExpireOldPoints(CurrentUserRowId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Expired points processed.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to expire points.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
