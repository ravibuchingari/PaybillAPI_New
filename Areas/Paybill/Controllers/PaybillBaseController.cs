using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Paybill.Areas.Paybill.Controllers
{
    [Area("Paybill")]
    public abstract class PaybillBaseController : Controller
    {
        protected int CurrentUserRowId =>
            int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int id) ? id : 0;

        protected bool IsAdminUser =>
            User.IsInRole("admin");

        protected string CurrentCompanyName =>
            User.FindFirstValue("CompanyName") ?? "PayBill POS & ERP";

        protected string CurrentCompanyGstin =>
            User.FindFirstValue("CompanyGstin") ?? string.Empty;

        protected string CurrentClientUniqueId =>
            User.FindFirstValue("ClientUniqueId") ?? "WEB_DEFAULT_UNIQUE_ID";

        protected string CurrentClientId =>
            User.FindFirstValue("ClientId") ?? "WEB_DEFAULT_CLIENT_ID";

        protected static DateTime ParseDate(string? dateStr, DateTime? fallback = null)
        {
            if (!string.IsNullOrWhiteSpace(dateStr))
            {
                string normalized = dateStr.Replace("Sept", "Sep", StringComparison.OrdinalIgnoreCase);
                if (DateTime.TryParse(normalized, out DateTime parsed))
                    return parsed;
            }
            return fallback ?? DateTime.Today;
        }
    }
}

