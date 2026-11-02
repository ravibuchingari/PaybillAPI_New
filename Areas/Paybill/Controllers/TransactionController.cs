using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Helpers;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class TransactionController(
        ITransactionRepository transactionRepository,
        IPartyRepository partyRepository,
        ISharedRepository sharedRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(bool isPayment = false, string? fromDate = null, string? toDate = null)
        {
            string start = string.IsNullOrWhiteSpace(fromDate)
                ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString("yyyy-MM-dd")
                : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate)
                ? DateTime.Today.ToString("yyyy-MM-dd")
                : toDate;

            var transactions = (await transactionRepository.GetTransactions(ParseDate(start), ParseDate(end), isPayment ? 1 : 0)).ToList();
            var parties = (await partyRepository.GetActiveParties(isVendor: isPayment, isAll: true)).ToList();
            var header = await sharedRepository.GetPrintHeader();

            var vm = new TransactionPageViewModel
            {
                Transactions = transactions,
                Parties = parties,
                IsPayment = isPayment,
                FromDate = start,
                ToDate = end,
                Header = header
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTransaction(TransactionVM model)
        {
            if (model.PartyId <= 0)
            {
                TempData["ErrorMessage"] = "Please select a Party (Customer or Supplier).";
                return RedirectToAction(nameof(Index), new { isPayment = model.IsPayment });
            }

            if (string.IsNullOrWhiteSpace(model.TransactionDate))
                model.TransactionDate = DateTime.Today.ToString("yyyy-MM-dd");

            model.TransactionType = model.IsPayment ? "Payment" : "Receipt";

            try
            {
                var res = await transactionRepository.SaveTransaction(model, CurrentUserRowId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? (model.IsPayment ? "Payment recorded successfully." : "Receipt recorded successfully.");
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to save transaction.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { isPayment = model.IsPayment });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTransaction(int id, string remarks, bool isPayment, string? fromDate, string? toDate)
        {
            if (string.IsNullOrWhiteSpace(remarks))
                remarks = "Deleted by user";

            try
            {
                var res = await transactionRepository.DeleteTransaction(id, remarks, CurrentUserRowId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Transaction deleted.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to delete transaction.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { isPayment, fromDate, toDate });
        }

        [HttpGet]
        public async Task<IActionResult> PrintVoucher(int id, bool isPayment, string? fromDate = null, string? toDate = null)
        {
            string start = string.IsNullOrWhiteSpace(fromDate) ? DateTime.Today.AddYears(-1).ToString("yyyy-MM-dd") : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate) ? DateTime.Today.ToString("yyyy-MM-dd") : toDate;

            var transactions = (await transactionRepository.GetTransactions(ParseDate(start), ParseDate(end), isPayment ? 1 : 0)).ToList();
            var header = await sharedRepository.GetPrintHeader();

            var tx = transactions.FirstOrDefault(t => t.TransactionId == id) ?? new TransactionVM
            {
                TransactionId = id,
                IsPayment = isPayment,
                TransactionDate = DateTime.Today.ToString("yyyy-MM-dd")
            };

            double amount = isPayment ? tx.PaidAmount : tx.ReceivedAmount;
            ViewBag.Header = header;
            ViewBag.AmountInWords = GstHelper.NumberToWords(amount);

            return View(tx);
        }
    }
}
