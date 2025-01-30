using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaybillWinApp.Models
{
    public class PrintHeaderVM
    {
        public string InvoiceTitle { get; set; } = "";
        public string CompanyName { get; set; } = "";
        public string Header1 { get; set; } = "";
        public string Header2 { get; set; } = "";
        public string Header3 { get; set; } = "";
        public string Gstin { get; set; } = "";
        public bool GstSlabRequired { get; set; } = false;
        public bool IsPaymentDetailsRequired { get; set; } = true;
        public bool IsSavingDetailsRequired { get; set; } = true;
        public bool IsGstSummaryRequired { get; set; } = true;
        public bool ItemWiseGstSlabRequired { get; set; } = false;
    }
}
