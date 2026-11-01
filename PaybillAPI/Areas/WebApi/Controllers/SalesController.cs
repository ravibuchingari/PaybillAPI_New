using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Models;
using Paybill.Repositories.Service;

namespace Paybill.Areas.WebApi.Controllers
{
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Area("WebApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController(ISalesRepository salesRepository, ISharedRepository sharedRepository) : ControllerBase
    {
        [HttpPost]
        [Route("sales/invoice/save")]
        public async Task<IActionResult> SaveSalesInvoice([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await salesRepository.SaveSalesInvoice(userParam.SalesModel!, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("sales/item/{salesItemId}/delete")]
        public async Task<IActionResult> DeleteSalesItem([FromBody] UserParam userParam, [FromRoute] string salesItemId)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            if (string.IsNullOrWhiteSpace(userParam.Remarks))
                return BadRequest("Remarks cannot be empty.");
            salesItemId = DataProtection.UrlDecode(salesItemId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.DeleteSalesItem(int.Parse(salesItemId), userParam.Remarks ?? string.Empty, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("sales/invoice/list/{fromDate}/{toDate}")]
        public async Task<IActionResult> GetSalesInvoices([FromBody] UserParam userParam, [FromRoute] string fromDate, [FromRoute] string toDate)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await salesRepository.GetSalesInvoices(DateTime.Parse(fromDate.Replace("Sept", "Sep")), DateTime.Parse(toDate.Replace("Sept", "Sep"))));
        }

        [HttpPost]
        [Route("sales/invoice/details/{salesId}")]
        public async Task<IActionResult> GetSalesInvoiceDetails([FromBody] UserParam userParam, [FromRoute] string salesId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            salesId = DataProtection.UrlDecode(salesId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.GetSalesInvoiceDetails(int.Parse(salesId)));
        }

        [HttpPost]
        [Route("sales/invoice/{salesId}/delete")]
        public async Task<IActionResult> DeleteSalesInvoice([FromBody] UserParam userParam, [FromRoute] string salesId)
        {
            if (!await sharedRepository.IsValidAdminUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            salesId = DataProtection.UrlDecode(salesId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.DeleteSalesInvoice(int.Parse(salesId), Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("sales/invoice/{salesId}/print")]
        public async Task<IActionResult> GetSalesInvoiceToPrint([FromBody] UserParam userParam, [FromRoute] string salesId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            salesId = DataProtection.UrlDecode(salesId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            PrintSalesInvoice? salesInvoice = await salesRepository.GetSalesInvoiceToPrint(int.Parse(salesId));
            if (salesInvoice != null)
                return Ok(salesInvoice);
            else
                return BadRequest("Sales invoice not found.");
        }

        [HttpPost]
        [Route("sales/summary/dashboard")]
        public async Task<IActionResult> GetDashboardSalesSummary([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await salesRepository.GetDashboardSalesSummary());
        }

        #region "Job Cards / Service Requests"

        [HttpPost]
        [Route("jobcard/save")]
        public async Task<IActionResult> CreateJobCard([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            if (userParam.JobCardModel == null)
                return BadRequest("Job card model is required.");
            return Ok(await salesRepository.CreateJobCard(userParam.JobCardModel, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("jobcard/list")]
        public async Task<IActionResult> GetActiveJobCards([FromBody] UserParam userParam)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await salesRepository.GetActiveJobCards());
        }

        [HttpPost]
        [Route("jobcard/{serviceRequestId}/details")]
        public async Task<IActionResult> GetJobCardDetails([FromBody] UserParam userParam, [FromRoute] string serviceRequestId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            string decodedId = int.TryParse(serviceRequestId, out _) ? serviceRequestId : DataProtection.UrlDecode(serviceRequestId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.GetJobCardDetails(int.Parse(decodedId)));
        }

        [HttpGet]
        [Route("jobcard/next-number")]
        public async Task<IActionResult> GetNextJobCardNumber()
        {
            return Ok(await salesRepository.GetNextJobCardNumber());
        }

        [HttpPost]
        [Route("jobcard/{serviceRequestId}/delete")]
        public async Task<IActionResult> DeleteJobCard([FromBody] UserParam userParam, [FromRoute] string serviceRequestId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            string decodedId = int.TryParse(serviceRequestId, out _) ? serviceRequestId : DataProtection.UrlDecode(serviceRequestId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.DeleteJobCard(int.Parse(decodedId)));
        }

        [HttpPost]
        [Route("jobcard/item/{serviceRequestComplaintId}/delete")]
        public async Task<IActionResult> DeleteJobCardItem([FromBody] UserParam userParam, [FromRoute] string serviceRequestComplaintId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            string decodedId = int.TryParse(serviceRequestComplaintId, out _) ? serviceRequestComplaintId : DataProtection.UrlDecode(serviceRequestComplaintId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.DeleteJobCardItem(int.Parse(decodedId)));
        }

        [HttpPost]
        [Route("jobcard/spare/{jobCardSpareId}/delete")]
        public async Task<IActionResult> DeleteJobCardSpare([FromBody] UserParam userParam, [FromRoute] string jobCardSpareId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            string decodedId = int.TryParse(jobCardSpareId, out _) ? jobCardSpareId : DataProtection.UrlDecode(jobCardSpareId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.DeleteJobCardSpare(int.Parse(decodedId)));
        }

        [HttpPost]
        [Route("jobcard/{serviceRequestId}/status/{statusId}")]
        public async Task<IActionResult> UpdateJobCardStatus([FromBody] UserParam userParam, [FromRoute] int serviceRequestId, [FromRoute] int statusId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await salesRepository.UpdateJobCardStatus(serviceRequestId, statusId));
        }

        [HttpPost]
        [Route("jobcard/{jobCardId}/generate-invoice")]
        public async Task<IActionResult> GenerateOrGetSalesInvoiceForJobCard([FromBody] UserParam userParam, [FromRoute] int jobCardId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            return Ok(await salesRepository.GenerateOrGetSalesInvoiceForJobCard(jobCardId, Convert.ToInt32(User.Identity?.Name)));
        }

        [HttpPost]
        [Route("jobcard/{jobCardId}/sales-invoice")]
        public async Task<IActionResult> GetJobCardSalesInvoice([FromBody] UserParam userParam, [FromRoute] string jobCardId)
        {
            if (!await sharedRepository.IsValidUser(userParam.UserRowId, userParam.SecurityKey, Convert.ToInt32(User.Identity?.Name)))
                return Unauthorized(AppConstants.UNAUTHORIZED_ACCESS);
            string decodedId = int.TryParse(jobCardId, out _) ? jobCardId : DataProtection.UrlDecode(jobCardId, AppConstants.PAYBILL_API_AES_KEY_AND_IV);
            return Ok(await salesRepository.GetJobCardSalesInvoice(int.Parse(decodedId)));
        }

        #endregion
    }
}

