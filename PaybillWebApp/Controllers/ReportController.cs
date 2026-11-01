using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillWebApp.Helpers;
using PaybillWebApp.Models;
using PaybillWebApp.Services;

namespace PaybillWebApp.Controllers
{
    [Authorize]
    public class ReportController(IPaybillApiService apiService) : Controller
    {
        private static (string Start, string End) GetDefaultDates(string? fromDate, string? toDate)
        {
            string start = string.IsNullOrWhiteSpace(fromDate)
                ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString("yyyy-MM-dd")
                : fromDate;
            string end = string.IsNullOrWhiteSpace(toDate)
                ? DateTime.Today.ToString("yyyy-MM-dd")
                : toDate;
            return (start, end);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GstReturns(string? fromDate = null, string? toDate = null, string returnType = "GSTR-1")
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);

            string? apiFilter = returnType switch
            {
                "GSTR-1" or "GSTR-3B" or "CMP-08" or "GSTR-9" => null,
                _ => null
            };

            var detailedTask = apiService.GetGSTReturnDetailedAsync(start, end, apiFilter);
            var hsnTask = apiService.GetGSTHSNSummaryAsync(start, end);
            var sacTask = apiService.GetGSTSACSummaryAsync(start, end);
            var settingsTask = apiService.GetSettingsAsync();

            await Task.WhenAll(detailedTask, hsnTask, sacTask, settingsTask);

            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.ReturnType = returnType;
            ViewBag.HsnSummary = hsnTask.Result;
            ViewBag.SacSummary = sacTask.Result;
            ViewBag.CompanyGstin = string.IsNullOrWhiteSpace(settingsTask.Result.ReceiptHeaderLine5)
                ? apiService.GetCurrentCompanyGstin()
                : settingsTask.Result.ReceiptHeaderLine5;

            return View(detailedTask.Result);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadGstr1Json(string fromDate, string toDate)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var detailedTask = apiService.GetGSTReturnDetailedAsync(start, end, "Sales");
            var hsnTask = apiService.GetGSTHSNSummaryAsync(start, end);
            var settingsTask = apiService.GetSettingsAsync();

            await Task.WhenAll(detailedTask, hsnTask, settingsTask);

            string gstin = string.IsNullOrWhiteSpace(settingsTask.Result.ReceiptHeaderLine5)
                ? apiService.GetCurrentCompanyGstin()
                : settingsTask.Result.ReceiptHeaderLine5;

            DateTime dt = DateTime.TryParse(end, out var parsed) ? parsed : DateTime.Today;
            string fp = dt.ToString("MMyyyy");

            string json = GstHelper.GenerateGstr1Json(gstin, fp, detailedTask.Result, hsnTask.Result);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", $"GSTR1_{gstin}_{fp}.json");
        }

        [HttpGet]
        public async Task<IActionResult> Daybook(string? fromDate = null, string? toDate = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var entries = await apiService.GetDaybookAsync(start, end);
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            return View(entries);
        }

        [HttpGet]
        public async Task<IActionResult> SalesDetails(string? fromDate = null, string? toDate = null, string? salesType = null, string? paymentMode = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var param = new ReportParam
            {
                FromDate = start,
                ToDate = end,
                SalesType = salesType,
                PaymentMode = paymentMode
            };

            var sales = await apiService.GetSalesDetailsReportAsync(param);
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.SalesType = salesType;
            ViewBag.PaymentMode = paymentMode;
            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadSalesDetailsExcel(string? fromDate = null, string? toDate = null, string? salesType = null, string? paymentMode = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var bytes = await apiService.DownloadSalesDetailsExcelAsync(new ReportParam
            {
                FromDate = start,
                ToDate = end,
                SalesType = salesType,
                PaymentMode = paymentMode
            });

            if (bytes == null || bytes.Length == 0)
            {
                TempData["ErrorMessage"] = "No sales data available to export.";
                return RedirectToAction(nameof(SalesDetails), new { fromDate = start, toDate = end, salesType, paymentMode });
            }

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Sales_Details_{start}_to_{end}.xlsx");
        }

        [HttpGet]
        public async Task<IActionResult> SalesSummary(string? fromDate = null, string? toDate = null, string? salesType = null, string? paymentMode = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var list = await apiService.GetSalesSummaryReportAsync(new ReportParam
            {
                FromDate = start,
                ToDate = end,
                SalesType = salesType,
                PaymentMode = paymentMode
            });

            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.SalesType = salesType;
            ViewBag.PaymentMode = paymentMode;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadSalesSummaryExcel(string? fromDate = null, string? toDate = null, string? salesType = null, string? paymentMode = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var bytes = await apiService.DownloadSalesSummaryExcelAsync(new ReportParam
            {
                FromDate = start,
                ToDate = end,
                SalesType = salesType,
                PaymentMode = paymentMode
            });

            if (bytes == null || bytes.Length == 0)
            {
                TempData["ErrorMessage"] = "No sales summary data available to export.";
                return RedirectToAction(nameof(SalesSummary), new { fromDate = start, toDate = end, salesType, paymentMode });
            }

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Sales_Summary_{start}_to_{end}.xlsx");
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseReport(string? fromDate = null, string? toDate = null, string? purchaseType = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var list = await apiService.GetPurchaseDetailsReportAsync(new ReportParam
            {
                FromDate = start,
                ToDate = end,
                PurchaseType = purchaseType
            });

            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.PurchaseType = purchaseType;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> BalanceSheet(string filter = "all")
        {
            var list = await apiService.GetBalanceSheetAsync();
            ViewBag.Filter = filter;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> InventoryValuation(string? filter = null)
        {
            var valuationTask = apiService.GetInventoryValuationAsync(filter);
            var categoriesTask = apiService.GetCategoriesWithItemCountAsync();
            await Task.WhenAll(valuationTask, categoriesTask);

            ViewBag.Filter = filter;
            ViewBag.CategoryCounts = categoriesTask.Result;
            return View(valuationTask.Result);
        }

        [HttpGet]
        public async Task<IActionResult> AgedInventory(int ageDays = 30)
        {
            if (ageDays <= 0) ageDays = 30;
            var items = await apiService.GetAgedInventoryAsync(ageDays);
            ViewBag.AgeDays = ageDays;
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> ProductMovement(string? fromDate = null, string? toDate = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var list = await apiService.GetProductMovementAnalysisAsync(start, end);
            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> OrderReadiness()
        {
            var items = await apiService.GetMinStockItemsAsync();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> AuditDeletedItems(string? fromDate = null, string? toDate = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var delSalesTask = apiService.GetDeletedSalesItemsAsync(start, end);
            var delPurchasesTask = apiService.GetDeletedPurchaseItemsAsync(start, end);

            await Task.WhenAll(delSalesTask, delPurchasesTask);

            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.DeletedSalesItems = delSalesTask.Result;
            ViewBag.DeletedPurchaseItems = delPurchasesTask.Result;
            return View();
        }
    }
}

