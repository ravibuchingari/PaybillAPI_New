using System.ComponentModel;

namespace Paybill.Models
{
    public class SalesSummary
    {
        public string Month { get; set; } = string.Empty;
        public string SalesType { get; set; } = string.Empty;
        public string PaymentMode { get; set; } = string.Empty;
        public double Cash { get; set; }
        public double Card { get; set; }
        public double Upi { get; set; }
        public double Credit { get; set; }
        public double TotalAmount { get; set; }

        [Browsable(false)]
        public string InvoiceNumber => Month;
        [Browsable(false)]
        public string SalesDate => Month;
        [Browsable(false)]
        public string PartyName => SalesType;
        [Browsable(false)]
        public string Gstin => string.Empty;
        [Browsable(false)]
        public double TotalTaxableAmount => TotalAmount;
        [Browsable(false)]
        public double TotalCgst => 0;
        [Browsable(false)]
        public double TotalSgst => 0;
        [Browsable(false)]
        public double TotalIgst => 0;
        [Browsable(false)]
        public double TotalDiscount => 0;
        [Browsable(false)]
        public double TotalInvoiceAmount => TotalAmount;
        [Browsable(false)]
        public double BalanceAmount => Credit;
    }
}
