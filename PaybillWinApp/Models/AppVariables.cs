using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Models
{
    public class AppVariables
    {
        public static ServiceProvider? ServiceProvider { get; set; }
        public static string ApiUrl = string.Empty;
    }
}
