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
    public class PartyController(IPaybillApiService apiService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(bool isVendor = false)
        {
            var partiesTask = apiService.GetPartiesAsync(isVendor);
            var balanceTask = apiService.GetBalanceSheetAsync();

            await Task.WhenAll(partiesTask, balanceTask);

            var balanceMap = balanceTask.Result
                .GroupBy(b => b.PartyId)
                .ToDictionary(g => g.Key, g => g.First());

            var vm = new PartyPageViewModel
            {
                Parties = partiesTask.Result,
                BalanceMap = balanceMap,
                IsVendor = isVendor
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveParty(PartyVM model)
        {
            var res = await apiService.UpsertPartyAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? (model.IsVendor ? "Supplier saved successfully." : "Customer saved successfully.");
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save party details.";

            return RedirectToAction(nameof(Index), new { isVendor = model.IsVendor });
        }

        [HttpPost]
        public async Task<IActionResult> SavePartyJson([FromBody] PartyVM model)
        {
            var res = await apiService.UpsertPartyAsync(model);
            int partyId = 0;
            if (!string.IsNullOrWhiteSpace(res.Data))
                int.TryParse(res.Data, out partyId);

            return Json(new
            {
                isSuccess = res.IsSuccess,
                message = res.Message,
                partyId,
                party = model
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetPartyDetailsJson(int id)
        {
            var party = await apiService.GetPartyDetailsAsync(id);
            return Json(party);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteParty(int id, bool isVendor)
        {
            var res = await apiService.DeletePartyAsync(id, isVendor);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Party deleted successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Unable to delete party (may have linked invoices/transactions).";

            return RedirectToAction(nameof(Index), new { isVendor });
        }

        [HttpGet]
        public async Task<IActionResult> Ledger(int id, string? fromDate = null, string? toDate = null)
        {
            string start = string.IsNullOrWhiteSpace(fromDate)
                ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString("yyyy-MM-dd")
                : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate)
                ? DateTime.Today.ToString("yyyy-MM-dd")
                : toDate;

            var partyTask = apiService.GetPartyDetailsAsync(id);
            var ledgerTask = apiService.GetPartyLedgerAsync(id, start, end);
            var headerTask = apiService.GetPrintHeaderAsync();

            await Task.WhenAll(partyTask, ledgerTask, headerTask);

            ViewBag.Party = partyTask.Result ?? new PartyVM { PartyId = id, PartyName = "Party Ledger" };
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.PrintHeader = headerTask.Result;

            return View(ledgerTask.Result);
        }
    }
}


