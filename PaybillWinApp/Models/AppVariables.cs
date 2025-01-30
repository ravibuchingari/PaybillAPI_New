using Microsoft.Extensions.DependencyInjection;

namespace PaybillWinApp.Models
{
    public class AppVariables
    {
        public const string PROVIDER_BASE_URL = "http://gevatechnologies.in/api/paybill/ApiService/";
        public const string TABLE_PREF = "preference_table";
        public static string SQLITE_DB = "Data Source={0};Version={1};";
        public static string API_BASE_URL = string.Empty;
        public static readonly string[] PAYBILL_API_AES_KEY_AND_IV = ["PgUpwEBhCapsVkScrLKEySGNSkEYPgDn", "NumPrtScnLockvhI"];
        public static UserVM User = new();
        public static DashboardPrefVM DashboardPref = new();
        public static ServiceProvider? ServiceProvider { get; set; }
    }
}
