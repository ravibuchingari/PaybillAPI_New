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
    public class DashboardController(
        ISalesRepository salesRepository,
        ITransactionRepository transactionRepository,
        IReportRepository reportRepository,
        IItemRepository itemRepository,
        IPurchaseRepository purchaseRepository,
        ISharedRepository sharedRepository) : PaybillBaseController
    {
        public async Task<IActionResult> Index(string? fromDate = null, string? toDate = null)
        {
            DateTime today = DateTime.Now.Date;
            DateTime monthStart = new(today.Year, today.Month, 1);
            DateTime yearStart = new(today.Year, 1, 1);

            DateTime chartFromDate = ParseDate(fromDate, monthStart);
            DateTime chartToDate = ParseDate(toDate, today);
            string chartFrom = chartFromDate.ToString("yyyy-MM-dd");
            string chartTo = chartToDate.ToString("yyyy-MM-dd");

            // Sequential awaits on the scoped DbContext
            var salesSummary = await salesRepository.GetDashboardSalesSummary();
            var balances = (await transactionRepository.GetBalanceSheet()).ToList();
            var valuations = (await reportRepository.GetInventoryValuation(string.Empty)).ToList();
            var lowStockItems = (await itemRepository.GetMinStockItems()).ToList();
            var recentSales = (await salesRepository.GetSalesInvoices(today.AddDays(-30), today)).ToList();
            var recentPurchases = (await purchaseRepository.GetPurchaseInvoices(monthStart, today)).ToList();
            var jobCards = await salesRepository.GetActiveJobCards();
            var todayPayments = (await transactionRepository.GetTodayTransactions(true)).ToList();
            var todayReceipts = (await transactionRepository.GetTodayTransactions(false)).ToList();
            var dayChart = (await reportRepository.GetDayWiseSalesSummary(chartFromDate, chartToDate)).ToList();
            var monthChart = (await reportRepository.GetMonthWiseSalesSummary(yearStart, today)).ToList();
            var itemChart = (await reportRepository.GetItemWiseSalesSummary(chartFromDate, chartToDate)).ToList();
            var paymentModeChart = (await reportRepository.GetSalesPaymentModeSummary(chartFromDate, chartToDate)).ToList();

            List<UnlockRequestVM> pendingUnlocks = IsAdminUser
                ? await sharedRepository.GetUnlockRequests()
                : [];

            // In PaybillAPI BalanceSheet: Balance = TotalReceiptAmount - TotalPaymentAmount
            // For Customer (!IsVendor): PaymentAmount = Sales (Debit), ReceiptAmount = Receipt (Credit). If Balance < 0, customer owes money.
            double customerReceivables = balances
                .Where(b => b.PartyModel != null && !b.PartyModel.IsVendor && b.Balance < 0)
                .Sum(b => Math.Abs(b.Balance));

            if (salesSummary.Today.OverallPendingCreditAmount > customerReceivables)
            {
                customerReceivables = salesSummary.Today.OverallPendingCreditAmount;
            }

            // For Supplier/Vendor (IsVendor): ReceiptAmount = Purchase, PaymentAmount = Payment Out. If Balance > 0, we owe vendor.
            double vendorPayables = balances
                .Where(b => b.PartyModel != null && b.PartyModel.IsVendor && b.Balance > 0)
                .Sum(b => b.Balance);

            var vm = new DashboardViewModel
            {
                SalesSummary = salesSummary,
                TotalCustomerReceivables = customerReceivables,
                TotalVendorPayables = vendorPayables,
                TotalInventoryPurchaseValue = valuations.Sum(v => v.PurchaseValue),
                TotalInventorySalesValue = valuations.Sum(v => v.SalesValue),
                TotalActiveItemsCount = valuations.Count,
                TodayPaymentsOut = todayPayments.Sum(t => t.PaymentAmount),
                TodayReceiptsIn = todayReceipts.Sum(t => t.ReceiptAmount),
                MonthlyPurchaseTotal = recentPurchases.Sum(p => p.Summary?.TotalInvoiceAmount ?? 0),
                MonthlyPurchaseCount = recentPurchases.Count,
                LowStockItems = [.. lowStockItems.Take(12)],
                RecentSales = [.. recentSales.OrderByDescending(s => s.SalesId).Take(8)],
                RecentPurchases = [.. recentPurchases.OrderByDescending(p => p.PurchaseId).Take(8)],
                ActiveJobCards = [.. jobCards.Take(8)],
                PendingUnlockRequests = pendingUnlocks,
                DayWiseSalesChart = dayChart,
                MonthWiseSalesChart = monthChart,
                ItemWiseSalesChart = [.. itemChart.Take(10)],
                PaymentModeChart = paymentModeChart
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
