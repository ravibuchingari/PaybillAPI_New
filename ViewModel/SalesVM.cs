using Paybill.Models;
using System.ComponentModel;

namespace Paybill.ViewModel
{
    public class SalesVM
    {
        public int SalesId { get; set; }
        public string InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string SalesType { get; set; } = "Cash";
        public string PaymentMode { get; set; } = "Cash";
        public string? UpiType { get; set; } = string.Empty;
        public double PaidAmount { get; set; }
        public double BalanceAmount { get; set; }
        public string? Remarks { get; set; } = string.Empty;
        public string? CreatedDate { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public bool IsLocked { get; set; }
        public string? EndUserMobile { get; set; } = string.Empty;
        public int ServiceRequestId { get; set; }
        public double RewardPointsEarned { get; set; }
        public double RewardPointsRedeemed { get; set; }
        public double RewardDiscountAmount { get; set; }
        public PartyVM? PartyModel { get; set; }
        public List<SalesItemVM> SalesItems { get; set; } = [];
        public InvoiceSummary? Summary { get; set; }
        public JobCardVM? JobCard { get; set; }

        [Browsable(false)]
        public bool IsCashSales { get; set; } = true;
        [Browsable(false)]
        public double TotalSavings { get; set; }
        [Browsable(false)]
        public double RoundOff { get; set; }

        [Browsable(false)]
        public string InvoiceNumber
        {
            get => InvoiceNo;
            set => InvoiceNo = value ?? string.Empty;
        }
        [Browsable(false)]
        public string SalesDate
        {
            get => InvoiceDate;
            set => InvoiceDate = value ?? string.Empty;
        }
        [Browsable(false)]
        public PartyVM? Party
        {
            get => PartyModel;
            set => PartyModel = value;
        }
        [Browsable(false)]
        public int? PartyId
        {
            get => PartyModel?.PartyId;
            set
            {
                if (value.HasValue && value.Value > 0)
                {
                    PartyModel ??= new PartyVM();
                    PartyModel.PartyId = value.Value;
                }
            }
        }

        private double? _totalTaxable;
        [Browsable(false)]
        public double TotalTaxableAmount
        {
            get => _totalTaxable ?? Summary?.TotalTaxableAmount ?? SalesItems.Sum(i => i.TaxableAmount);
            set
            {
                _totalTaxable = value;
                Summary ??= new InvoiceSummary();
                Summary.TotalTaxableAmount = value;
            }
        }

        private double? _totalCgst;
        [Browsable(false)]
        public double TotalCgst
        {
            get => _totalCgst ?? SalesItems.Sum(i => i.CgstRs);
            set => _totalCgst = value;
        }

        private double? _totalSgst;
        [Browsable(false)]
        public double TotalSgst
        {
            get => _totalSgst ?? SalesItems.Sum(i => i.SgstRs);
            set => _totalSgst = value;
        }

        private double? _totalIgst;
        [Browsable(false)]
        public double TotalIgst
        {
            get => _totalIgst ?? SalesItems.Sum(i => i.IgstRs);
            set => _totalIgst = value;
        }

        private double? _totalDiscount;
        [Browsable(false)]
        public double TotalDiscount
        {
            get => _totalDiscount ?? Summary?.TotalDiscount ?? SalesItems.Sum(i => i.DiscountInRs);
            set
            {
                _totalDiscount = value;
                Summary ??= new InvoiceSummary();
                Summary.TotalDiscount = value;
            }
        }

        private double? _totalInvoiceAmount;
        [Browsable(false)]
        public double TotalInvoiceAmount
        {
            get => _totalInvoiceAmount ?? Summary?.TotalInvoiceAmount ?? SalesItems.Sum(i => i.TotalAmount);
            set
            {
                _totalInvoiceAmount = value;
                Summary ??= new InvoiceSummary();
                Summary.TotalInvoiceAmount = value;
            }
        }

        [Browsable(false)]
        public double ReceivedAmount
        {
            get => PaidAmount;
            set => PaidAmount = value;
        }
        [Browsable(false)]
        public double PointsEarned
        {
            get => RewardPointsEarned;
            set => RewardPointsEarned = value;
        }
        [Browsable(false)]
        public double PointsRedeemed
        {
            get => RewardPointsRedeemed;
            set => RewardPointsRedeemed = value;
        }
        [Browsable(false)]
        public double PointsDiscount
        {
            get => RewardDiscountAmount;
            set => RewardDiscountAmount = value;
        }
    }
}
