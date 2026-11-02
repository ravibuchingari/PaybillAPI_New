namespace Paybill.Models
{
    public class PrintSalesInvoice
    {
        public int SalesId { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string SalesType { get; set; } = string.Empty;
        public double PaidAmount { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedDate { get; set; } = string.Empty;
        public string PaymentMode { get; set; } = string.Empty;
        public string UpiType { get; set; } = string.Empty;
        public string PartyName { get; set; } = string.Empty;
        public string PartyMobile { get; set; } = string.Empty;
        public string PartyAddress { get; set; } = string.Empty;
        public string Gstin { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string PrintedTime { get; set; } = string.Empty;
        public double RewardPointsEarned { get; set; }
        public double RewardPointsRedeemed { get; set; }
        public double RewardDiscountAmount { get; set; }
        public double CustomerAvailablePoints { get; set; }
        public List<GSTData> GstSummary { get; set; } = [];
        public List<PrintSalesItem> SalesItems { get; set; } = [];

        public string SalesDate => InvoiceDate;
        public string SalesTime => PrintedTime;
        public string Mobile => PartyMobile;
        public string Address => PartyAddress;
        public double TotalTaxableAmount => SalesItems.Sum(i => i.TaxableAmount);
        public double TotalCgst => SalesItems.Sum(i => i.CgstRs);
        public double TotalSgst => SalesItems.Sum(i => i.SgstRs);
        public double TotalIgst => SalesItems.Sum(i => i.IgstRs);
        public double TotalDiscount => SalesItems.Sum(i => i.DiscountInRs);
        public double TotalSavings => SalesItems.Sum(i => i.SavingAmount);
        public double RoundOff => 0;
        public double TotalInvoiceAmount => Math.Max(0, SalesItems.Sum(i => i.TotalAmount) - RewardDiscountAmount);
        public double ReceivedAmount => PaidAmount;
        public double BalanceAmount => Math.Max(0, TotalInvoiceAmount - PaidAmount);
        public double PointsEarned => RewardPointsEarned;
        public double PointsRedeemed => RewardPointsRedeemed;
        public double PointsDiscount => RewardDiscountAmount;
        public double AvailablePoints => CustomerAvailablePoints;
        public List<GSTData> GstSummaries => GstSummary;
    }
}
