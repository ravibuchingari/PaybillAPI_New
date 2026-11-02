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
    public class JobCardController(
        ISalesRepository salesRepository,
        IPartyRepository partyRepository,
        IItemRepository itemRepository,
        ISharedRepository sharedRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(int? statusFilter = null)
        {
            var jobCards = await salesRepository.GetActiveJobCards();
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
            var nextNoRes = await salesRepository.GetNextJobCardNumber();
            string nextNo = nextNoRes.Data?.ToString() ?? nextNoRes.Message ?? "1";

            var customers = (await partyRepository.GetActiveParties(isVendor: false, isAll: false)).ToList();
            var services = (await itemRepository.GetServiceTypes(isAll: false)).ToList();
            var items = (await itemRepository.GetItemsForOffline(isAllItems: false, lastUpdatedTime: null)).ToList();
            var gstSlabs = (await itemRepository.GetGsts(isActive: true)).ToList();

            JobCardVM? existingJobCard = null;
            if (id.HasValue && id.Value > 0)
            {
                try
                {
                    existingJobCard = await salesRepository.GetJobCardDetails(id.Value);
                }
                catch
                {
                    existingJobCard = null;
                }
            }

            var jobCard = existingJobCard ?? new JobCardVM
            {
                RequestDate = DateTime.Today.ToString("yyyy-MM-dd"),
                JobCardNumber = nextNo,
                JobCardStatusId = 1,
                Status = "Pending"
            };

            var vm = new JobCardPageViewModel
            {
                JobCard = jobCard,
                NextJobCardNumber = nextNo,
                Customers = customers,
                ServiceTypes = services,
                Items = items,
                GstSlabs = gstSlabs,
                CompanyGstin = CurrentCompanyGstin
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

            try
            {
                var res = await salesRepository.CreateJobCard(model, CurrentUserRowId);
                return Json(new
                {
                    isSuccess = res.IsSuccess,
                    message = res.Message,
                    jobCardId = res.Data
                });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, int statusId)
        {
            try
            {
                var res = await salesRepository.UpdateJobCardStatus(id, statusId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Job card status updated.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to update job card status.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComplaint(int complaintId)
        {
            try
            {
                var res = await salesRepository.DeleteJobCardItem(complaintId);
                return Json(new { isSuccess = res.IsSuccess, message = res.Message });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSpare(int spareId)
        {
            try
            {
                var res = await salesRepository.DeleteJobCardSpare(spareId);
                return Json(new { isSuccess = res.IsSuccess, message = res.Message });
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteJobCard(int id)
        {
            try
            {
                var res = await salesRepository.DeleteJobCard(id);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Job card deleted.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Could not delete job card.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateInvoice(int id)
        {
            try
            {
                var res = await salesRepository.GenerateOrGetSalesInvoiceForJobCard(id, CurrentUserRowId);
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
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Print(int id)
        {
            JobCardVM? jobCard = null;
            try
            {
                jobCard = await salesRepository.GetJobCardDetails(id);
            }
            catch
            {
                jobCard = null;
            }

            var header = await sharedRepository.GetPrintHeader();
            ViewBag.Header = header;
            return View(jobCard ?? new JobCardVM { ServiceRequestId = id });
        }
    }
}
