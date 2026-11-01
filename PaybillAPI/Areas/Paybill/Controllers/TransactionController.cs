using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Areas.Paybill.Models;
using Paybill.Helpers;
using Paybill.Services;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class TransactionController(IPaybillApiService apiService) : Controller
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

            var txTask = apiService.GetTransactionsAsync(start, end, isPayment ? 1 : 0);
            var partiesTask = apiService.GetActivePartiesAsync(isVendor: isPayment, isAll: true);
            var headerTask = apiService.GetPrintHeaderAsync();

            await Task.WhenAll(txTask, partiesTask, headerTask);

            var vm = new TransactionPageViewModel
            {
                Transactions = txTask.Result,
                Parties = partiesTask.Result,
                IsPayment = isPayment,
                FromDate = start,
                ToDate = end,
                Header = headerTask.Result
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

            var res = await apiService.InsertTransactionAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? (model.IsPayment ? "Payment recorded successfully." : "Receipt recorded successfully.");
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save transaction.";

            return RedirectToAction(nameof(Index), new { isPayment = model.IsPayment });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTransaction(int id, string remarks, bool isPayment, string? fromDate, string? toDate)
        {
            if (string.IsNullOrWhiteSpace(remarks))
                remarks = "Deleted by user";

            var res = await apiService.DeleteTransactionAsync(id, remarks);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Transaction deleted.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to delete transaction.";

            return RedirectToAction(nameof(Index), new { isPayment, fromDate, toDate });
        }

        [HttpGet]
        public async Task<IActionResult> PrintVoucher(int id, bool isPayment, string? fromDate = null, string? toDate = null)
        {
            string start = string.IsNullOrWhiteSpace(fromDate) ? DateTime.Today.AddYears(-1).ToString("yyyy-MM-dd") : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate) ? DateTime.Today.ToString("yyyy-MM-dd") : toDate;

            var txTask = apiService.GetTransactionsAsync(start, end, isPayment ? 1 : 0);
            var headerTask = apiService.GetPrintHeaderAsync();
            await Task.WhenAll(txTask, headerTask);

            var tx = txTask.Result.FirstOrDefault(t => t.TransactionId == id) ?? new TransactionVM
            {
                TransactionId = id,
                IsPayment = isPayment,
                TransactionDate = DateTime.Today.ToString("yyyy-MM-dd")
            };

            double amount = isPayment ? tx.PaidAmount : tx.ReceivedAmount;
            ViewBag.Header = headerTask.Result;
            ViewBag.AmountInWords = GstHelper.NumberToWords(amount);

            return View(tx);
        }
    }
}


