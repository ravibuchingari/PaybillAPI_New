using System.Text;
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
    public class ReportController(
        IReportRepository reportRepository,
        ITransactionRepository transactionRepository,
        IItemRepository itemRepository,
        IAdminRepository adminRepository,
        IWebHostEnvironment hostEnvironment) : PaybillBaseController
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
            DateTime fDate = ParseDate(start);
            DateTime tDate = ParseDate(end);

            string? apiFilter = returnType switch
            {
                "GSTR-1" or "GSTR-3B" or "CMP-08" or "GSTR-9" => null,
                _ => null
            };

            List<GSTReturnDetailed> detailed = !string.IsNullOrWhiteSpace(apiFilter)
                ? (await reportRepository.GetGSTRReturnByType(apiFilter, fDate, tDate)).ToList()
                : (await reportRepository.GetGSTReturnDetailed(fDate, tDate)).ToList();

            var hsnSummary = (await reportRepository.GetGSTHSNSummary(fDate, tDate)).ToList();
            var sacSummary = (await reportRepository.GetGSTSACSummary(fDate, tDate)).ToList();
            var settings = await adminRepository.GetSettings() ?? new SettingVM();

            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.ReturnType = returnType;
            ViewBag.HsnSummary = hsnSummary;
            ViewBag.SacSummary = sacSummary;
            ViewBag.CompanyGstin = string.IsNullOrWhiteSpace(settings.ReceiptHeaderLine5)
                ? CurrentCompanyGstin
                : settings.ReceiptHeaderLine5;

            return View(detailed);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadGstr1Json(string fromDate, string toDate)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            DateTime fDate = ParseDate(start);
            DateTime tDate = ParseDate(end);

            var detailed = (await reportRepository.GetGSTRReturnByType("Sales", fDate, tDate)).ToList();
            var hsnSummary = (await reportRepository.GetGSTHSNSummary(fDate, tDate)).ToList();
            var settings = await adminRepository.GetSettings() ?? new SettingVM();

            string gstin = string.IsNullOrWhiteSpace(settings.ReceiptHeaderLine5)
                ? CurrentCompanyGstin
                : settings.ReceiptHeaderLine5;

            string fp = tDate.ToString("MMyyyy");

            string json = GstHelper.GenerateGstr1Json(gstin, fp, detailed, hsnSummary);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json", $"GSTR1_{gstin}_{fp}.json");
        }

        [HttpGet]
        public async Task<IActionResult> Daybook(string? fromDate = null, string? toDate = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var entries = (await reportRepository.GetDaybook(ParseDate(start), ParseDate(end))).ToList();
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
                PaymentMode = paymentMode,
                UserRowId = CurrentUserRowId
            };

            var sales = await reportRepository.GetSalesDetails(param);
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
            var param = new ReportParam
            {
                FromDate = start,
                ToDate = end,
                SalesType = salesType,
                PaymentMode = paymentMode,
                UserRowId = CurrentUserRowId
            };

            var list = await reportRepository.GetSalesDetails(param);
            if (list.Count == 0)
            {
                TempData["ErrorMessage"] = "No sales data available to export.";
                return RedirectToAction(nameof(SalesDetails), new { fromDate = start, toDate = end, salesType, paymentMode });
            }

            string[] selectedProperties =
            [
                "InvoiceNo", "InvoiceDate", "PartyName", "SalesType", "PaymentMode", "UpiType",
                "TotalAmount", "TotalDiscount", "TotalTaxableAmount", "TotalGSTAmount", "TotalInvoiceAmount",
                "PartyModel", "Summary"
            ];

            string tempDir = Path.Combine(hostEnvironment.WebRootPath, AppConstants.TEMP_DIR);
            Directory.CreateDirectory(tempDir);
            string fileName = SharedMethod.GenerateExcel(
                SharedMethod.ConvertToDataTable(list, selectedProperties),
                tempDir,
                $"Sales details from {start} to {end}",
                "sales_details");

            byte[] bytes = await System.IO.File.ReadAllBytesAsync(fileName);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Sales_Details_{start}_to_{end}.xlsx");
        }

        [HttpGet]
        public async Task<IActionResult> SalesSummary(string? fromDate = null, string? toDate = null, string? salesType = null, string? paymentMode = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var list = await reportRepository.GetSalesSummary(new ReportParam
            {
                FromDate = start,
                ToDate = end,
                SalesType = salesType,
                PaymentMode = paymentMode,
                UserRowId = CurrentUserRowId
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
            var param = new ReportParam
            {
                FromDate = start,
                ToDate = end,
                SalesType = salesType,
                PaymentMode = paymentMode,
                UserRowId = CurrentUserRowId
            };

            var list = await reportRepository.GetSalesSummary(param);
            if (list.Count == 0)
            {
                TempData["ErrorMessage"] = "No sales summary data available to export.";
                return RedirectToAction(nameof(SalesSummary), new { fromDate = start, toDate = end, salesType, paymentMode });
            }

            string[] selectedProperties = ["Month", "Credit", "Cash", "Card", "Upi", "TotalAmount"];
            string tempDir = Path.Combine(hostEnvironment.WebRootPath, AppConstants.TEMP_DIR);
            Directory.CreateDirectory(tempDir);
            string fileName = SharedMethod.GenerateExcel(
                SharedMethod.ConvertToDataTable(list, selectedProperties),
                tempDir,
                $"Sales summary from {start} to {end}",
                "sales_summary");

            byte[] bytes = await System.IO.File.ReadAllBytesAsync(fileName);
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Sales_Summary_{start}_to_{end}.xlsx");
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseReport(string? fromDate = null, string? toDate = null, string? purchaseType = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var list = (await reportRepository.GetPurchaseDetails(new ReportParam
            {
                FromDate = start,
                ToDate = end,
                PurchaseType = purchaseType,
                UserRowId = CurrentUserRowId
            })).ToList();

            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.PurchaseType = purchaseType;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> BalanceSheet(string filter = "all")
        {
            var list = (await transactionRepository.GetBalanceSheet()).ToList();
            ViewBag.Filter = filter;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> InventoryValuation(string? filter = null)
        {
            var valuation = (await reportRepository.GetInventoryValuation(filter ?? string.Empty)).ToList();
            var categories = (await itemRepository.GetCategoriesWithItemCount()).ToList();

            ViewBag.Filter = filter;
            ViewBag.CategoryCounts = categories;
            return View(valuation);
        }

        [HttpGet]
        public async Task<IActionResult> AgedInventory(int ageDays = 30)
        {
            if (ageDays <= 0) ageDays = 30;
            var items = (await reportRepository.GetAgedInventory(ageDays)).ToList();
            ViewBag.AgeDays = ageDays;
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> ProductMovement(string? fromDate = null, string? toDate = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            var list = (await reportRepository.GetProductMovementAnalysis(new ReportParam
            {
                FromDate = start,
                ToDate = end,
                UserRowId = CurrentUserRowId
            })).ToList();

            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> OrderReadiness()
        {
            var items = (await itemRepository.GetMinStockItems()).ToList();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> AuditDeletedItems(string? fromDate = null, string? toDate = null)
        {
            var (start, end) = GetDefaultDates(fromDate, toDate);
            DateTime fDate = ParseDate(start);
            DateTime tDate = ParseDate(end);

            var delSales = (await reportRepository.GetDeletedSalesItems(fDate, tDate)).ToList();
            var delPurchases = (await reportRepository.GetDeletedPurchaseItems(fDate, tDate)).ToList();

            ViewBag.FromDate = start;
            ViewBag.ToDate = end;
            ViewBag.DeletedSalesItems = delSales;
            ViewBag.DeletedPurchaseItems = delPurchases;
            return View();
        }
    }
}
