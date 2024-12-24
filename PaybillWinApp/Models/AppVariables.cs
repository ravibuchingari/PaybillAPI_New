using Microsoft.Extensions.DependencyInjection;

namespace PaybillWinApp.Models
{
    public class AppVariables
    {
        public static ServiceProvider? ServiceProvider { get; set; }
        public static string ApiUrl = string.Empty;
    }
}
