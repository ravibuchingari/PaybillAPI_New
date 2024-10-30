namespace PaybillAPI.ViewModel
{
    public class PartyVM
    {
        public int PartyId { get; set; }

        public string PartyName { get; set; } = null!;

        public string PartyAddress { get; set; } = null!;

        public string? PartyMobile { get; set; }

        public string? PartyEmail { get; set; }

        public string? PartyGstNo { get; set; }

        public string? PartyRemarks { get; set; }

        public bool IsVendor { get; set; }

        public bool IsActive { get; set; }
    }
}
