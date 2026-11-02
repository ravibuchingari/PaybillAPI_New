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
    public class SettingsController(
        IAdminRepository adminRepository,
        ISharedRepository sharedRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Index(string tab = "company")
        {
            var settings = await adminRepository.GetSettings() ?? new SettingVM();
            var clientProfile = await sharedRepository.GetPrimaryClientInfo() ?? new ClientVM();
            var users = (await adminRepository.GetUsers()).ToList();
            var messages = (await adminRepository.GetMessages()).ToList();
            var customLines = await adminRepository.GetAllCustomLines();
            var unlocks = await sharedRepository.GetUnlockRequests();

            var vm = new SettingsPageViewModel
            {
                Settings = settings,
                ClientProfile = clientProfile,
                Users = users,
                MessageTemplates = messages,
                CustomReceiptLines = customLines,
                UnlockRequests = unlocks,
                ActiveTab = tab,
                IsAdmin = IsAdminUser
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSettings(SettingVM model, string returnTab = "company")
        {
            try
            {
                var res = await adminRepository.UpdateSettings(CurrentUserRowId, model);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Settings updated successfully.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to update settings.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = returnTab });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveProfile(ClientVM model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.ClientUniqueId))
                    model.ClientUniqueId = CurrentClientUniqueId;
                if (string.IsNullOrWhiteSpace(model.ClientId))
                    model.ClientId = CurrentClientId;

                var res = await sharedRepository.UpdateProfile(model);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Business profile updated.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to update business profile.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "profile" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUser(UserVM model)
        {
            try
            {
                var res = await sharedRepository.UpsertUser(model, CurrentUserRowId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "User account saved successfully.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to save user account.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "users" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int userRowId)
        {
            try
            {
                var res = await adminRepository.DeleteUser(userRowId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "User deleted.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to delete user.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "users" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                TempData["ErrorMessage"] = "Both current and new passwords are required.";
                return RedirectToAction(nameof(Index), new { tab = "security" });
            }

            if (newPassword != confirmPassword)
            {
                TempData["ErrorMessage"] = "New password and confirmation do not match.";
                return RedirectToAction(nameof(Index), new { tab = "security" });
            }

            try
            {
                var res = await sharedRepository.ChangePassword(CurrentUserRowId, oldPassword, newPassword);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Password updated successfully.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to change password. Check your current password.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "security" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCustomLine(CustomReceiptLineVM model)
        {
            try
            {
                var res = await adminRepository.UpsertCustomLine(model);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Custom receipt line saved.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to save custom receipt line.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "receiptlines" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleCustomLine(int id, bool isActive)
        {
            try
            {
                var res = await adminRepository.UpdateCustomLineActiveStatus(id, isActive);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = "Receipt line status updated.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to update receipt line status.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "receiptlines" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomLine(int id)
        {
            try
            {
                var res = await adminRepository.DeleteCustomLine(id);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = "Custom receipt line deleted.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to delete custom line.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "receiptlines" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveMessageTemplate(string messageId, string description, string messageType, bool isSelected)
        {
            try
            {
                int msgId = int.TryParse(messageId, out int parsedId) ? parsedId : 0;
                var res = await adminRepository.InsMessage(msgId, description, messageType, isSelected);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? "Message template saved.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to save message template.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "messages" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectMessageTemplate(int id, string messageType)
        {
            try
            {
                var res = await adminRepository.SelectMessageTemplate(id, messageType);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = "Default message template updated.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to select template.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "messages" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMessageTemplate(int id)
        {
            try
            {
                var res = await adminRepository.DeleteMessage(id);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = "Message template deleted.";
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to delete template.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "messages" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessUnlockRequest(int unlockRequestId, bool isApproved, string remarks)
        {
            try
            {
                string finalRemarks = string.IsNullOrWhiteSpace(remarks)
                    ? (isApproved ? "Approved by Admin" : "Rejected by Admin")
                    : remarks;

                var res = await sharedRepository.UpdateUnlockRequest(unlockRequestId, isApproved, finalRemarks, CurrentUserRowId);
                if (res.IsSuccess)
                    TempData["SuccessMessage"] = res.Message ?? (isApproved ? "Invoice unlocked successfully." : "Unlock request rejected.");
                else
                    TempData["ErrorMessage"] = res.Message ?? "Failed to process unlock request.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction(nameof(Index), new { tab = "unlocks" });
        }
    }
}
