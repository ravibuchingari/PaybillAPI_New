using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using PaybillAPI.Models;
using PaybillAPI.Repositories.Service;
using PaybillAPI.ViewModel;
using System.ComponentModel;
using System.Data;

namespace PaybillAPI.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportRepository reportRepository, IWebHostEnvironment hostEnvironment) : ControllerBase
    {
        [HttpGet]
        [Route("gst/returns")]
        public async Task<IActionResult> GetGSTReturns([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await reportRepository.GetGSTReturns(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpGet]
        [Route("gst/summary")]
        public async Task<IActionResult> GetGSTSummary([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await reportRepository.GetGSTSummary(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpPost]
        [Route("sales/details")]
        public async Task<IActionResult> GetSalesDetails([FromBody] ReportParam reportParam)
        {
            return Ok(await reportRepository.GetSalesDetails(reportParam));
        }

        [HttpPost]
        [Route("sales/details/download")]
        [AllowAnonymous]
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
    }
}
