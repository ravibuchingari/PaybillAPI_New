namespace Paybill.Models
{
    public class PrintHeader
    {
        public string InvoiceTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Header1 { get; set; } = string.Empty;
        public string Header2 { get; set; } = string.Empty;
        public string Header3 { get; set; } = string.Empty;
        public string Gstin { get; set; } = string.Empty;
        public bool GstSlabRequired { get; set; }
        public bool IsPaymentDetailsRequired { get; set; }
        public bool IsSavingDetailsRequired { get; set; }
        public bool IsGstSummaryRequired { get; set; }
        public bool ItemWiseGstSlabRequired { get; set; }
        public string BankDetails { get; set; } = string.Empty;
    }
}
