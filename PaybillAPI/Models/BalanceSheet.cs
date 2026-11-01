using Paybill.ViewModel;

namespace Paybill.Models
{
    public class BalanceSheet
    {
        public double TotalReceiptAmount { get; set; }
        public double TotalPaymentAmount { get; set; }
        public double Balance { get; set; }
        public PartyVM PartyModel { get; set; } = new();

        public int PartyId => PartyModel.PartyId;
        public string PartyName => PartyModel.PartyName;
        public string? Mobile => PartyModel.PartyMobile;
        public string PartyType => PartyModel.IsVendor ? "Vendor" : "Customer";
        public double OpeningBalance => PartyModel.OpeningBalance;
        public double SalesAmount => TotalPaymentAmount;
        public double PurchaseAmount => TotalPaymentAmount;
        public double ReceivedAmount => TotalReceiptAmount;
        public double PaidAmount => TotalReceiptAmount;
        public double SalesDiscount => 0;
        public double PurchaseDiscount => 0;
        public double ClosingBalance => Balance;
    }
}
