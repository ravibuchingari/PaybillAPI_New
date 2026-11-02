using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paybill.Models;
using Paybill.Repositories.Service;
using Paybill.ViewModel;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    [AllowAnonymous]
    public class AccountController(ISharedRepository sharedRepository) : PaybillBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            var clientInfo = await sharedRepository.GetPrimaryClientInfo();
            var vm = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                IsConfigured = clientInfo != null,
                ClientUniqueId = clientInfo?.ClientUniqueId ?? "WEB_DEFAULT_UNIQUE_ID",
                ClientId = clientInfo?.ClientId ?? "WEB_DEFAULT_CLIENT_ID",
                CompanyName = clientInfo?.ClientName ?? "PayBill POS & ERP",
                BusinessType = clientInfo?.BusinessType ?? "Enterprise Business Management"
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserId) || string.IsNullOrWhiteSpace(model.Password))
            {
                model.ErrorMessage = "Please enter both User ID and Password.";
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.ClientUniqueId) || string.IsNullOrWhiteSpace(model.ClientId))
            {
                var clientInfo = await sharedRepository.GetPrimaryClientInfo();
                model.ClientUniqueId = clientInfo?.ClientUniqueId ?? "WEB_DEFAULT_UNIQUE_ID";
                model.ClientId = clientInfo?.ClientId ?? "WEB_DEFAULT_CLIENT_ID";
            }

            if (!await sharedRepository.IsValidAccount(model.ClientUniqueId, model.ClientId))
            {
                model.ErrorMessage = AppConstants.UNAUTHORIZED_ACCESS;
                return View(model);
            }

            var authRes = await sharedRepository.UserAuthentication(new AuthRequestVM
            {
                ClientUniqueId = model.ClientUniqueId,
                ClientId = model.ClientId,
                UserId = model.UserId.Trim(),
                Password = model.Password
            });

            if (!authRes.IsSuccess || authRes.User == null)
            {
                model.ErrorMessage = !string.IsNullOrWhiteSpace(authRes.Message)
                    ? authRes.Message
                    : "Invalid User ID or Password. Please verify your credentials.";
                return View(model);
            }

            string companyName = !string.IsNullOrWhiteSpace(authRes.Pref?.HeaderModel?.CompanyName)
                ? authRes.Pref.HeaderModel.CompanyName
                : model.CompanyName;

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, authRes.User.UserRowId.ToString()),
                new(ClaimTypes.Name, authRes.User.UserId),
                new("UserId", authRes.User.UserId),
                new("FullName", authRes.User.FullName),
                new(ClaimTypes.Role, authRes.User.IsAdmin ? "admin" : "user"),
                new("SecurityKey", authRes.User.SecurityKey ?? string.Empty),
                new("ClientUniqueId", authRes.User.Client?.ClientUniqueId ?? model.ClientUniqueId),
                new("ClientId", authRes.User.Client?.ClientId ?? model.ClientId),
                new("CompanyName", companyName),
                new("CompanyGstin", authRes.Pref?.HeaderModel?.Gstin ?? string.Empty)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                });

            if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult Setup()
        {
            return View(new SetupAccountViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Setup(SetupAccountViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ClientName) ||
                string.IsNullOrWhiteSpace(model.Mobile) ||
                string.IsNullOrWhiteSpace(model.AdminUserId) ||
                string.IsNullOrWhiteSpace(model.AdminPassword))
            {
                model.ErrorMessage = "Please fill in all required business and admin user fields.";
                return View(model);
            }

            string uniqueId = Guid.NewGuid().ToString("N");
            string clientId = DateTime.Now.Ticks.ToString();
            string securityKey = SharedMethod.GenerateUniqueID();

            var clientVm = new ClientVM
            {
                ClientUniqueId = uniqueId,
                ClientId = clientId,
                ClientName = model.ClientName.Trim(),
                BusinessType = model.BusinessType.Trim(),
                Mobile = model.Mobile.Trim(),
                Email = model.Email?.Trim(),
                Address = model.Address?.Trim() ?? string.Empty,
                SubscriptionType = "Enterprise",
                SubscriptionAmount = 0,
                SubscriptionEndDate = DateTime.Now.AddYears(5).ToString("yyyy-MM-dd"),
                IsPremiumUser = true,
                IsActivated = true,
                SecurityKey = securityKey
            };

            string accResponse = await sharedRepository.CreateAccountIfNotExists(clientVm);
            if (!accResponse.Equals(AppConstants.RESPONSE_SUCCESS))
            {
                model.ErrorMessage = accResponse;
                return View(model);
            }

            string userResponse = await sharedRepository.CreateUserIfNotExists(new UserVM
            {
                UserId = model.AdminUserId.Trim(),
                Password = model.AdminPassword,
                FirstName = string.IsNullOrWhiteSpace(model.AdminFirstName) ? "Admin" : model.AdminFirstName.Trim(),
                LastName = string.IsNullOrWhiteSpace(model.AdminLastName) ? "User" : model.AdminLastName.Trim(),
                Mobile = model.Mobile.Trim(),
                Address = model.Address?.Trim() ?? string.Empty,
                IsAdmin = true,
                IsActive = true,
                SecurityKey = clientVm.SecurityKey
            });

            if (!userResponse.Equals(AppConstants.RESPONSE_SUCCESS))
            {
                model.ErrorMessage = userResponse;
                return View(model);
            }

            TempData["SuccessMessage"] = "Business account and Admin user created! Please sign in.";
            return RedirectToAction("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
