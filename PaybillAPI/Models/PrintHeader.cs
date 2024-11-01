namespace PaybillAPI.Models
{
    public class PrintHeader
    {
        public string InvoiceTitle { get; set; }
        public string CompanyName { get; set; }
        public string Header1 { get; set; }
        public string Header2 { get; set; }
        public string Header3 { get; set; }
        public string GSTIN { get; set; }
        public bool GSTSlabRequired { get; set; }
    }
}
