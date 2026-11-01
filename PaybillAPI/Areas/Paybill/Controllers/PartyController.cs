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
    public class PartyController(
        IPartyRepository partyRepository,
        ITransactionRepository transactionRepository,
        ISharedRepository sharedRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(bool isVendor = false)
        {
            var parties = (await partyRepository.GetParties(isVendor)).ToList();
            var balances = (await transactionRepository.GetBalanceSheet()).ToList();

            var balanceMap = balances
                .GroupBy(b => b.PartyId)
                .ToDictionary(g => g.Key, g => g.First());

            var vm = new PartyPageViewModel
            {
                Parties = parties,
                BalanceMap = balanceMap,
                IsVendor = isVendor
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveParty(PartyVM model)
        {
            try
            {
                var res = await partyRepository.UpsertParty(model, CurrentUserRowId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? (model.IsVendor ? "Supplier saved successfully." : "Customer saved successfully.");
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to save party details.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { isVendor = model.IsVendor });
        }

        [HttpPost]
        public async Task<IActionResult> SavePartyJson([FromBody] PartyVM model)
        {
            try
            {
                var res = await partyRepository.UpsertParty(model, CurrentUserRowId);
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
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPartyDetailsJson(int id)
        {
            try
            {
                var party = await partyRepository.GetPartyDetails(id);
                return Json(party);
            }
            catch
            {
                return Json(null);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteParty(int id, bool isVendor)
        {
            try
            {
                var res = await partyRepository.DeleteParty(id, isVendor);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Party deleted successfully.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Unable to delete party (may have linked invoices/transactions).";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Unable to delete party: {ex.Message}";
            }

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

            PartyVM? party = null;
            try
            {
                party = await partyRepository.GetPartyDetails(id);
            }
            catch
            {
                party = null;
            }

            var ledger = (await transactionRepository.GetPartyLedger(new ReportParam
            {
                Id = id.ToString(),
                FromDate = start,
                ToDate = end,
                UserRowId = CurrentUserRowId
            })).ToList();

            var printHeader = await sharedRepository.GetPrintHeader();

            ViewBag.Party = party ?? new PartyVM { PartyId = id, PartyName = "Party Ledger" };
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.PrintHeader = printHeader;

            return View(ledger);
        }
    }
}
