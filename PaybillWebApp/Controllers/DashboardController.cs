using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillWebApp.Models;
using PaybillWebApp.Services;

namespace PaybillWebApp.Controllers
{
    [Authorize]
    public class DashboardController(IPaybillApiService apiService) : Controller
    {
        public async Task<IActionResult> Index(string? fromDate = null, string? toDate = null)
        {
            DateTime today = DateTime.Now.Date;
            DateTime monthStart = new(today.Year, today.Month, 1);
            DateTime yearStart = new(today.Year, 1, 1);

            string chartFrom = !string.IsNullOrWhiteSpace(fromDate) ? fromDate : monthStart.ToString("yyyy-MM-dd");
            string chartTo = !string.IsNullOrWhiteSpace(toDate) ? toDate : today.ToString("yyyy-MM-dd");
            string recentFrom = today.AddDays(-30).ToString("yyyy-MM-dd");
            string todayStr = today.ToString("yyyy-MM-dd");

            var salesSummaryTask = apiService.GetDashboardSalesSummaryAsync();
            var balanceSheetTask = apiService.GetBalanceSheetAsync();
            var valuationTask = apiService.GetInventoryValuationAsync();
            var lowStockTask = apiService.GetMinStockItemsAsync();
            var recentSalesTask = apiService.GetSalesInvoicesAsync(recentFrom, todayStr);
            var recentPurchasesTask = apiService.GetPurchaseInvoicesAsync(monthStart.ToString("yyyy-MM-dd"), todayStr);
            var jobCardsTask = apiService.GetActiveJobCardsAsync();
            var todayPaymentsTask = apiService.GetTodayTransactionsAsync(true);
            var todayReceiptsTask = apiService.GetTodayTransactionsAsync(false);
            var dayChartTask = apiService.GetDayWiseSalesChartAsync(chartFrom, chartTo);
            var monthChartTask = apiService.GetMonthWiseSalesChartAsync(yearStart.ToString("yyyy-MM-dd"), todayStr);
            var itemChartTask = apiService.GetItemWiseSalesChartAsync(chartFrom, chartTo);
            var paymentModeChartTask = apiService.GetPaymentModeChartAsync(chartFrom, chartTo);

            Task<List<UnlockRequestVM>> unlockTask = apiService.IsAdminUser()
                ? apiService.GetUnlockRequestsAsync()
                : Task.FromResult(new List<UnlockRequestVM>());

            await Task.WhenAll(
                salesSummaryTask, balanceSheetTask, valuationTask, lowStockTask,
                recentSalesTask, recentPurchasesTask, jobCardsTask,
                todayPaymentsTask, todayReceiptsTask,
                dayChartTask, monthChartTask, itemChartTask, paymentModeChartTask, unlockTask);

            var balances = balanceSheetTask.Result;
            var valuations = valuationTask.Result;
            var recentPurchases = recentPurchasesTask.Result;

            // In PaybillAPI BalanceSheet: Balance = TotalReceiptAmount - TotalPaymentAmount
            // For Customer (!IsVendor): PaymentAmount = Sales (Debit), ReceiptAmount = Receipt (Credit). If Balance < 0, customer owes money.
            double customerReceivables = balances
                .Where(b => b.PartyModel != null && !b.PartyModel.IsVendor && b.Balance < 0)
                .Sum(b => Math.Abs(b.Balance));

            // If overallPendingCreditAmount from sales summary is higher (includes any credit invoices), take max
            if (salesSummaryTask.Result.Today.OverallPendingCreditAmount > customerReceivables)
            {
                customerReceivables = salesSummaryTask.Result.Today.OverallPendingCreditAmount;
            }

            // For Supplier/Vendor (IsVendor): ReceiptAmount = Purchase, PaymentAmount = Payment Out. If Balance > 0, we owe vendor.
            double vendorPayables = balances
                .Where(b => b.PartyModel != null && b.PartyModel.IsVendor && b.Balance > 0)
                .Sum(b => b.Balance);

            var vm = new DashboardViewModel
            {
                SalesSummary = salesSummaryTask.Result,
                TotalCustomerReceivables = customerReceivables,
                TotalVendorPayables = vendorPayables,
                TotalInventoryPurchaseValue = valuations.Sum(v => v.PurchaseValue),
                TotalInventorySalesValue = valuations.Sum(v => v.SalesValue),
                TotalActiveItemsCount = valuations.Count,
                TodayPaymentsOut = todayPaymentsTask.Result.Sum(t => t.PaymentAmount),
                TodayReceiptsIn = todayReceiptsTask.Result.Sum(t => t.ReceiptAmount),
                MonthlyPurchaseTotal = recentPurchases.Sum(p => p.Summary?.TotalInvoiceAmount ?? 0),
                MonthlyPurchaseCount = recentPurchases.Count,
                LowStockItems = lowStockTask.Result.Take(12).ToList(),
                RecentSales = recentSalesTask.Result.OrderByDescending(s => s.SalesId).Take(8).ToList(),
                RecentPurchases = recentPurchases.OrderByDescending(p => p.PurchaseId).Take(8).ToList(),
                ActiveJobCards = jobCardsTask.Result.Take(8).ToList(),
                PendingUnlockRequests = unlockTask.Result,
                DayWiseSalesChart = dayChartTask.Result,
                MonthWiseSalesChart = monthChartTask.Result,
                ItemWiseSalesChart = itemChartTask.Result.Take(10).ToList(),
                PaymentModeChart = paymentModeChartTask.Result
            };

            ViewBag.ChartFrom = chartFrom;
            ViewBag.ChartTo = chartTo;
            return View(vm);
        }

        [AllowAnonymous]
        public IActionResult Error()
        {
            return View();
        }
    }
}

