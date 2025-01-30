using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Models
{
    public class CountryVM
    {
        public int CountryId { get; set; } = 0;
        public string CountryName { get; set; } = "";
        public string CountryCurrencyCode { get; set; } = "Rs";
        public string CountryCurrencySymbol { get; set; } = "₹";
        public string CountryLocaleCode { get; set; } = "in";
        public int CountryMobileLength { get; set; } = 10;
    }

}
