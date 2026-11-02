using Paybill.Models;

namespace Paybill.ViewModel
{

    public class PurchaseVM
    {
        public int PurchaseId { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string PurchaseType { get; set; } = "Cash";
        public string PaymentMode { get; set; } = "Cash";
        public string? UpiType { get; set; } = string.Empty;
        public string? Remarks { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
        public int? PurchaseOrderId { get; set; }
        public List<PurchaseItemVM> PurchaseItems { get; set; } = [];
        public InvoiceSummary? Summary { get; set; }
        public PartyVM PartyModel { get; set; } = new();

        public bool IsCashPurchase { get; set; } = true;
        public double RoundOff { get; set; }
        public double PaidAmount { get; set; }
        public double BalanceAmount { get; set; }

        public string InvoiceNumber
        {
            get => InvoiceNo;
            set => InvoiceNo = value ?? string.Empty;
        }
        public string PurchaseDate
        {
            get => InvoiceDate;
            set => InvoiceDate = value ?? string.Empty;
        }
        public PartyVM Party
        {
            get => PartyModel;
            set => PartyModel = value ?? new PartyVM();
        }
        public int PartyId
        {
            get => PartyModel.PartyId;
            set => PartyModel.PartyId = value;
        }

        private double? _totalTaxable;
        public double TotalTaxableAmount
        {
            get => _totalTaxable ?? Summary?.TotalTaxableAmount ?? PurchaseItems.Sum(i => i.TaxableAmount);
            set
            {
                _totalTaxable = value;
                Summary ??= new InvoiceSummary();
                Summary.TotalTaxableAmount = value;
            }
        }

        private double? _totalCgst;
        public double TotalCgst
        {
            get => _totalCgst ?? PurchaseItems.Sum(i => i.CgstRs);
            set => _totalCgst = value;
        }

        private double? _totalSgst;
        public double TotalSgst
        {
            get => _totalSgst ?? PurchaseItems.Sum(i => i.SgstRs);
            set => _totalSgst = value;
        }

        private double? _totalIgst;
        public double TotalIgst
        {
            get => _totalIgst ?? PurchaseItems.Sum(i => i.IgstRs);
            set => _totalIgst = value;
        }

        private double? _totalDiscount;
        public double TotalDiscount
        {
            get => _totalDiscount ?? Summary?.TotalDiscount ?? PurchaseItems.Sum(i => i.DiscountInRs);
            set
            {
                _totalDiscount = value;
                Summary ??= new InvoiceSummary();
                Summary.TotalDiscount = value;
            }
        }

        private double? _totalInvoiceAmount;
        public double TotalInvoiceAmount
        {
            get => _totalInvoiceAmount ?? Summary?.TotalInvoiceAmount ?? PurchaseItems.Sum(i => i.TotalAmount);
            set
            {
                _totalInvoiceAmount = value;
                Summary ??= new InvoiceSummary();
                Summary.TotalInvoiceAmount = value;
            }
        }
    }

    //public class PurchaseVM
    //{
    //    public int PurchaseId { get; set; }
    //    public string InvoiceNo { get; set; } = null!;
    //    public string InvoiceDate { get; set; } = null!;
    //    public string PurchaseType { get; set; } = null!;
    //    public string PaymentMode { get; set; } = null!;
    //    public string? UpiType { get; set; }
    //    public string? Remarks { get; set; }
    //    public bool IsLocked { get; set; }
    //    public int PurchaseOrderId { get; set; }
    //    public List<PurchaseItemVM> PurchaseItems { get; set; } = [];
    //    public InvoiceSummary? Summary { get; set; }
    //    public PartyVM PartyModel { get; set; } = new PartyVM();
    //}
}
