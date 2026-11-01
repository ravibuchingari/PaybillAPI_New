using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Areas.Paybill.Models;
using Paybill.Services;
using Paybill.ViewModel;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class JobCardController(IPaybillApiService apiService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int? statusFilter = null)
        {
            var jobCards = await apiService.GetActiveJobCardsAsync();
            if (statusFilter.HasValue && statusFilter.Value > 0)
            {
                jobCards = jobCards.Where(j => j.JobCardStatusId == statusFilter.Value).ToList();
            }

            ViewBag.StatusFilter = statusFilter;
            return View(jobCards);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? id = null)
        {
            var nextNoTask = apiService.GetNextJobCardNumberAsync();
            var customersTask = apiService.GetActivePartiesAsync(isVendor: false, isAll: false);
            var servicesTask = apiService.GetServiceTypesAsync(isAll: false);
            var itemsTask = apiService.GetAllItemsOfflineAsync(isAllItems: false);
            var gstTask = apiService.GetGstListAsync(isActiveOnly: true);

            Task<JobCardVM?>? jobCardTask = id.HasValue && id.Value > 0
                ? apiService.GetJobCardDetailsAsync(id.Value)
                : null;

            await Task.WhenAll(
                nextNoTask,
                customersTask,
                servicesTask,
                itemsTask,
                gstTask,
                jobCardTask ?? Task.FromResult<JobCardVM?>(null));

            var jobCard = jobCardTask?.Result ?? new JobCardVM
            {
                RequestDate = DateTime.Today.ToString("yyyy-MM-dd"),
                JobCardNumber = nextNoTask.Result,
                JobCardStatusId = 1,
                Status = "Pending"
            };

            var vm = new JobCardPageViewModel
            {
                JobCard = jobCard,
                NextJobCardNumber = nextNoTask.Result,
                Customers = customersTask.Result,
                ServiceTypes = servicesTask.Result,
                Items = itemsTask.Result,
                GstSlabs = gstTask.Result,
                CompanyGstin = apiService.GetCurrentCompanyGstin()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SaveJobCard([FromBody] JobCardVM model)
        {
            if (model == null || model.PartyId <= 0)
                return Json(new { isSuccess = false, message = "Please select a Customer for the Job Card." });

            if ((model.ServiceTypes == null || model.ServiceTypes.Count == 0) &&
                (model.Spares == null || model.Spares.Count == 0))
            {
                return Json(new { isSuccess = false, message = "Please add at least one Service Complaint or Spare Part." });
            }

            if (string.IsNullOrWhiteSpace(model.RequestDate))
                model.RequestDate = DateTime.Today.ToString("yyyy-MM-dd");

            if (model.JobCardStatusId <= 0)
                model.JobCardStatusId = 1;

            model.Status = model.JobCardStatusId switch
            {
                1 => "Pending",
                2 => "In Progress",
                3 => "Completed",
                4 => "Delivered",
                5 => "Cancelled",
                _ => "Pending"
            };

            var res = await apiService.SaveJobCardAsync(model);
            return Json(new
            {
                isSuccess = res.IsSuccess,
                message = res.Message,
                jobCardId = res.Data
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, int statusId)
        {
            var res = await apiService.UpdateJobCardStatusAsync(id, statusId);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Job card status updated.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to update job card status.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComplaint(int complaintId)
        {
            var res = await apiService.DeleteJobCardItemAsync(complaintId);
            return Json(new { isSuccess = res.IsSuccess, message = res.Message });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSpare(int spareId)
        {
            var res = await apiService.DeleteJobCardSpareAsync(spareId);
            return Json(new { isSuccess = res.IsSuccess, message = res.Message });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteJobCard(int id)
        {
            var res = await apiService.DeleteJobCardAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Job card deleted.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Could not delete job card.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateInvoice(int id)
        {
            var res = await apiService.GenerateJobCardInvoiceAsync(id);
            if (res.IsSuccess)
            {
                TempData["SuccessMessage"] = res.Message ?? "Sales invoice generated from Job Card!";
                if (!string.IsNullOrWhiteSpace(res.Data) && int.TryParse(res.Data, out int salesId) && salesId > 0)
                {
                    return RedirectToAction("Create", "Sales", new { id = salesId });
                }
            }
            else
            {
                TempData["ErrorMessage"] = res.Message ?? "Failed to convert Job Card to Sales Invoice.";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            var jobCardTask = apiService.GetJobCardDetailsAsync(id);
            var headerTask = apiService.GetPrintHeaderAsync();
            await Task.WhenAll(jobCardTask, headerTask);

            ViewBag.Header = headerTask.Result;
            return View(jobCardTask.Result ?? new JobCardVM { ServiceRequestId = id });
        }
    }
}


