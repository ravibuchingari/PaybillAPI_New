using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(ISharedRepository sharedRepository, ITransactionRepository transactionRepository, IReportRepository reportRepository, IWebHostEnvironment hostEnvironment) : ControllerBase
    {
        [HttpGet]
        [Route("sales/gst/return/detailed")]
        public async Task<IActionResult> GetGSTReturnDetailed([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await reportRepository.GetGSTReturnDetailed(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpGet]
        [Route("sales/gst/hsn/summary")]
        public async Task<IActionResult> GetGSTHSNSummary([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await reportRepository.GetGSTHSNSummary(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpGet]
        [Route("sales/gst/sac/summary")]
        public async Task<IActionResult> GetGSTSACSummary([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await reportRepository.GetGSTSACSummary(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpPost]
        [Route("sales/details")]
        public async Task<IActionResult> GetSalesDetails([FromBody] ReportParam reportParam)
        {
            return Ok(await reportRepository.GetSalesDetails(reportParam));
        }

        [HttpPost]
        [Route("sales/details/download")]
        public async Task<IActionResult> GetSalesDetailsDownload([FromBody] ReportParam reportParam)
        {
            var list = await reportRepository.GetSalesDetails(reportParam);
            if (list.Count > 0)
            {
                string[] selectedProperties = { "InvoiceNo", "InvoiceDate", "PartyName", "SalesType", "PaymentMode", "UpiType", "TotalAmount", "TotalDiscount", "TotalTaxableAmount", "TotalGSTAmount", "TotalInvoiceAmount", "PartyModel", "Summary" };
                string fileName = SharedMethod.GenerateExcel(SharedMethod.ConvertToDataTable(list, selectedProperties), Path.Combine(hostEnvironment.WebRootPath, AppConstants.TEMP_DIR), $"Sales details from {reportParam.FromDate} to {reportParam.ToDate}", "sales_details");
                new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string? contentType);
                var fileStream = File(System.IO.File.OpenRead(fileName), contentType: contentType ?? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                return fileStream;
            }
            else
                return BadRequest("No data found");

        }

        [HttpPost]
        [Route("sales/summary")]
        public async Task<IActionResult> GetSalesSummary([FromBody] ReportParam reportParam)
        {
            return Ok(await reportRepository.GetSalesSummary(reportParam));
        }

        [HttpPost]
        [Route("sales/summary/download")]
        public async Task<IActionResult> GetSalesSummaryDownload([FromBody] ReportParam reportParam)
        {
            var list = await reportRepository.GetSalesSummary(reportParam);
            if (list.Count > 0)
            {
                string[] selectedProperties = { "Month", "Credit", "Cash", "Card", "Upi", "TotalAmount" };
                string fileName = SharedMethod.GenerateExcel(SharedMethod.ConvertToDataTable(list, selectedProperties), Path.Combine(hostEnvironment.WebRootPath, AppConstants.TEMP_DIR), $"Sales summary from {reportParam.FromDate} to {reportParam.ToDate}", "sales_summary");
                new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string? contentType);
                var fileStream = File(System.IO.File.OpenRead(fileName), contentType: contentType ?? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                return fileStream;
            }
            else
                return BadRequest("No data found");

        }

        [HttpPost]
        [Route("purchase/details")]
        public async Task<IActionResult> GetPurchaseDetails([FromBody] ReportParam reportParam)
        {
            return Ok(await reportRepository.GetPurchaseDetails(reportParam));
        }

        [HttpPost]
        [Route("party/ledger")]
        public async Task<IActionResult> GetPartyLedger([FromBody] ReportParam reportParam)
        {
            if (!await sharedRepository.IsValidUser(reportParam.UserRowId, reportParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await transactionRepository.GetPartyLedger(reportParam));
        }

        [HttpPost]
        [Route("party/balance/sheet")]
        public async Task<IActionResult> GetBalanceSheet([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await transactionRepository.GetBalanceSheet());
        }

        [HttpGet]
        [Route("trans/daybook/{fromDate}/{toDate}")]
        public async Task<IActionResult> GetDaybook([FromRoute] string fromDate, [FromRoute] string toDate)
        {
            fromDate = DataProtection.UrlDecode(fromDate, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            toDate = DataProtection.UrlDecode(toDate, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await reportRepository.GetDaybook(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpGet]
        [Route("sales/items/deleted")]
        public async Task<IActionResult> GetDeletedSalesItems([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await reportRepository.GetDeletedSalesItems(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpGet]
        [Route("purchase/items/deleted")]
        public async Task<IActionResult> GetDeletedPurchaseItems([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await reportRepository.GetDeletedPurchaseItems(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpPost]
        [Route("purchase/order/list")]
        public async Task<IActionResult> GetPurchaseOrderList([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await reportRepository.GetPurchaseOrderList());
        }

        [HttpGet]
        [Route("inventory/valuation")]
        public async Task<IActionResult> GetInventoryValuation([FromQuery] string? filter)
        {
            return Ok(await reportRepository.GetInventoryValuation(filter ?? string.Empty));
        }

        [HttpGet]
        [Route("inventory/age")]
        public async Task<IActionResult> GetAgedInventory([FromQuery] int inventoryAge)
        {
            return Ok(await reportRepository.GetAgedInventory(inventoryAge));
        }
    }
}
