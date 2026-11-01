using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Models;
using Paybill.ViewModel;
using Paybill.Services;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class RewardController(IPaybillApiService apiService) : Controller
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

            var settingsTask = apiService.GetSettingsAsync();
            var overallTask = apiService.GetOverallRewardsSummaryAsync();
            var custSummaryTask = apiService.GetAllCustomerRewardsSummaryAsync(start, end, searchQuery);
            var txTask = apiService.GetRewardsTransactionsAsync(partyId: partyId, fromDate: start, toDate: end, searchQuery: searchQuery);
            var redemptionsTask = apiService.GetRedemptionDetailsAsync(fromDate: start, toDate: end, searchQuery: searchQuery);
            var customersTask = apiService.GetActivePartiesAsync(isVendor: false, isAll: false);

            await Task.WhenAll(settingsTask, overallTask, custSummaryTask, txTask, redemptionsTask, customersTask);

            var vm = new RewardsDashboardViewModel
            {
                Settings = settingsTask.Result,
                OverallSummary = overallTask.Result,
                CustomerSummaries = custSummaryTask.Result,
                Transactions = txTask.Result,
                Redemptions = redemptionsTask.Result,
                Customers = customersTask.Result,
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

            var res = await apiService.SaveManualRewardAdjustmentAsync(partyId, points, string.IsNullOrWhiteSpace(reason) ? "Manual Adjustment" : reason);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Reward points adjusted successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to adjust reward points.";

            return RedirectToAction(nameof(Index), new { tab = "transactions" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExpirePoints()
        {
            var res = await apiService.ExpireOldPointsAsync();
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Expired points processed.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to expire points.";

            return RedirectToAction(nameof(Index));
        }
    }
}


