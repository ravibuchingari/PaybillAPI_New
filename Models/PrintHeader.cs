namespace Paybill.Models
{
    public class PrintHeader
    {
        public string InvoiceTitle { get; set; } = "Tax Invoice";
        public string CompanyName { get; set; } = string.Empty;
        public string Header1 { get; set; } = string.Empty;
        public string Header2 { get; set; } = string.Empty;
        public string Header3 { get; set; } = string.Empty;
        public string Gstin { get; set; } = string.Empty;
        public bool GstSlabRequired { get; set; } = true;
        public bool IsPaymentDetailsRequired { get; set; } = true;
        public bool IsSavingDetailsRequired { get; set; } = true;
        public bool IsGstSummaryRequired { get; set; } = true;
        public bool ItemWiseGstSlabRequired { get; set; } = true;
        public string BankDetails { get; set; } = string.Empty;
        public string FooterLine1 { get; set; } = "Thank you for your business!";
        public string FooterLine2 { get; set; } = string.Empty;

        public string HeaderLine1
        {
            get => CompanyName;
            set => CompanyName = value ?? string.Empty;
        }
        public string HeaderLine2
        {
            get => Header1;
            set => Header1 = value ?? string.Empty;
        }
        public string HeaderLine3
        {
            get => Header2;
            set => Header2 = value ?? string.Empty;
        }
        public string HeaderLine4
        {
            get => Header3;
            set => Header3 = value ?? string.Empty;
        }
        public string HeaderLine5
        {
            get => Gstin;
            set => Gstin = value ?? string.Empty;
        }
    }
}
