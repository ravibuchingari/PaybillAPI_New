namespace Paybill.ViewModel
{
    public class PartyVM
    {
        public int PartyId { get; set; }
        public string PartyName { get; set; } = string.Empty;
        public string PartyAddress { get; set; } = string.Empty;
        public string PartyShippingAddress { get; set; } = string.Empty;
        public string? PartyMobile { get; set; } = string.Empty;
        public string? PartyEmail { get; set; } = string.Empty;
        public string? PartyGstNo { get; set; } = string.Empty;
        public string? PartyRemarks { get; set; } = string.Empty;
        public bool IsVendor { get; set; }
        public bool IsActive { get; set; } = true;
        public double OpeningBalance { get; set; }
        public string? Phone { get; set; } = string.Empty;

        public string? Mobile
        {
            get => PartyMobile;
            set => PartyMobile = value;
        }
        public string? Email
        {
            get => PartyEmail;
            set => PartyEmail = value;
        }
        public string? Gstin
        {
            get => PartyGstNo;
            set => PartyGstNo = value;
        }
        public string Address
        {
            get => PartyAddress;
            set => PartyAddress = value ?? string.Empty;
        }
        public string? Remarks
        {
            get => PartyRemarks;
            set => PartyRemarks = value;
        }
    }
}
