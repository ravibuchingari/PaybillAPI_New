using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
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
        [Route("sales/gst/return/detailed")]
        public async Task<IActionResult> GetGSTReturnDetailed([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            return Ok(await reportRepository.GetGSTReturnDetailed(DateTime.Parse(fromDate), DateTime.Parse(toDate)));
        }

        [HttpGet]
        [Route("sales/gst/return/detailed/download")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGSTReturnDetailedDownload([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var list = await reportRepository.GetGSTReturnDetailed(DateTime.Parse(fromDate), DateTime.Parse(toDate));
            if (list.Count > 0)
            {
                string[] selectedProperties = [];
                string fileName = SharedMethod.GenerateExcel(SharedMethod.ConvertToDataTable(list, selectedProperties), Path.Combine(hostEnvironment.WebRootPath, AppConstants.TEMP_DIR), $"Sales summary from {fromDate} to {toDate}", "sales_summary");
                new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string? contentType);
                var fileStream = File(System.IO.File.OpenRead(fileName), contentType: contentType ?? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                return fileStream;
            }
            else
                return BadRequest("No data found");

        }

        [HttpGet]
        [Route("sales/gst/return/statement")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGSTReturnStatement([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var list = await reportRepository.GetGSTReturnStatement(DateTime.Parse(fromDate), DateTime.Parse(toDate));
            return Ok(list);
        }

       /* [HttpGet]
        [Route("sales/gst/return/statement/download")]
        public async Task<IActionResult> GetGSTReturnStatementDownload([FromQuery] string fromDate, [FromQuery] string toDate)
        {
           *//* var list = await reportRepository.GetGSTReturnDetailed(DateTime.Parse(fromDate), DateTime.Parse(toDate));
            if (list.Count > 0)
            {
                string[] selectedProperties = [];
                string fileName = SharedMethod.GenerateExcel(SharedMethod.ConvertToDataTable(list, selectedProperties), Path.Combine(hostEnvironment.WebRootPath, AppConstants.TEMP_DIR), $"Sales summary from {fromDate} to {toDate}", "sales_summary");
                new FileExtensionContentTypeProvider().TryGetContentType(fileName, out string? contentType);
                var fileStream = File(System.IO.File.OpenRead(fileName), contentType: contentType ?? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                return fileStream;
            }
            else*//*
                return BadRequest("No data found");
        }*/

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
    }
}
