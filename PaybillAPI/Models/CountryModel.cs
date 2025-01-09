namespace PaybillAPI.Models
{
    public class CountryModel
    {
        public int CountryId { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCurrencyCode { get; set; }
        public string? CountryCurrencySymbol { get; set; }
        public string? CountryLocaleCode { get; set; }
        public sbyte CountryMobileLength { get; set; }
    }
}
