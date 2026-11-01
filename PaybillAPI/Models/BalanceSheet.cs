using Paybill.ViewModel;

namespace Paybill.Models
{
    public class BalanceSheet
    {
        public double TotalReceiptAmount { get; set; }
        public double TotalPaymentAmount { get; set; }
        public double Balance { get; set; }
        public PartyVM PartyModel { get; set; } = null!;
    }
}
