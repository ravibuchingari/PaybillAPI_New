﻿namespace PaybillAPI.Models
{
    public class ReceiptHeader
    {
        public string? InvoiceTitle { get; set; }
        public string? CompanyName { get; set; }
        public string? Header1 { get; set; }
        public string? Header2 { get; set; }
        public string? Header3 { get; set; }
        public string? Gstin { get; set; }
        public bool GstSlabRequired { get; set; }
    }
}
