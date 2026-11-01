using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaybillWebApp.Models;
using PaybillWebApp.Services;

namespace PaybillWebApp.Controllers
{
    [Authorize]
    public class SettingsController(IPaybillApiService apiService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string tab = "company")
        {
            var settingsTask = apiService.GetSettingsAsync();
            var clientTask = apiService.GetClientInfoAsync();
            var usersTask = apiService.GetUsersAsync();
            var messagesTask = apiService.GetMessagesAsync();
            var customLinesTask = apiService.GetAllCustomReceiptLinesAsync();
            var unlocksTask = apiService.GetUnlockRequestsAsync();

            await Task.WhenAll(settingsTask, clientTask, usersTask, messagesTask, customLinesTask, unlocksTask);

            var vm = new SettingsPageViewModel
            {
                Settings = settingsTask.Result,
                ClientProfile = clientTask.Result ?? new ClientVM(),
                Users = usersTask.Result,
                MessageTemplates = messagesTask.Result,
                CustomReceiptLines = customLinesTask.Result,
                UnlockRequests = unlocksTask.Result,
                ActiveTab = tab,
                IsAdmin = apiService.IsAdminUser()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSettings(SettingVM model, string returnTab = "company")
        {
            var res = await apiService.UpdateSettingsAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Settings updated successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to update settings.";

            return RedirectToAction(nameof(Index), new { tab = returnTab });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveProfile(ClientVM model)
        {
            var res = await apiService.UpdateClientProfileAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Business profile updated.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to update business profile.";

            return RedirectToAction(nameof(Index), new { tab = "profile" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveUser(UserVM model)
        {
            var res = await apiService.UpsertUserAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "User account saved successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save user account.";

            return RedirectToAction(nameof(Index), new { tab = "users" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int userRowId)
        {
            var res = await apiService.DeleteUserAsync(userRowId);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "User deleted.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to delete user.";

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

            var res = await apiService.ChangePasswordAsync(oldPassword, newPassword);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Password updated successfully.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to change password. Check your current password.";

            return RedirectToAction(nameof(Index), new { tab = "security" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCustomLine(CustomReceiptLineVM model)
        {
            var res = await apiService.UpsertCustomReceiptLineAsync(model);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Custom receipt line saved.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save custom receipt line.";

            return RedirectToAction(nameof(Index), new { tab = "receiptlines" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleCustomLine(int id, bool isActive)
        {
            var res = await apiService.UpdateCustomReceiptLineStatusAsync(id, isActive);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = "Receipt line status updated.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to update receipt line status.";

            return RedirectToAction(nameof(Index), new { tab = "receiptlines" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCustomLine(int id)
        {
            var res = await apiService.DeleteCustomReceiptLineAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = "Custom receipt line deleted.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to delete custom line.";

            return RedirectToAction(nameof(Index), new { tab = "receiptlines" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveMessageTemplate(string messageId, string description, string messageType, bool isSelected)
        {
            var res = await apiService.SaveMessageTemplateAsync(messageId, description, messageType, isSelected);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? "Message template saved.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to save message template.";

            return RedirectToAction(nameof(Index), new { tab = "messages" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SelectMessageTemplate(int id, string messageType)
        {
            var res = await apiService.SelectMessageTemplateAsync(id, messageType);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = "Default message template updated.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to select template.";

            return RedirectToAction(nameof(Index), new { tab = "messages" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMessageTemplate(int id)
        {
            var res = await apiService.DeleteMessageTemplateAsync(id);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = "Message template deleted.";
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to delete template.";

            return RedirectToAction(nameof(Index), new { tab = "messages" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessUnlockRequest(int unlockRequestId, bool isApproved, string remarks)
        {
            var res = await apiService.UpdateUnlockRequestAsync(unlockRequestId, isApproved, string.IsNullOrWhiteSpace(remarks) ? (isApproved ? "Approved by Admin" : "Rejected by Admin") : remarks);
            if (res.IsSuccess)
                TempData["SuccessMessage"] = res.Message ?? (isApproved ? "Invoice unlocked successfully." : "Unlock request rejected.");
            else
                TempData["ErrorMessage"] = res.Message ?? "Failed to process unlock request.";

            return RedirectToAction(nameof(Index), new { tab = "unlocks" });
        }
    }
}

