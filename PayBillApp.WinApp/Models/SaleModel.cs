using System.Collections.Generic;

namespace PayBillApp.WinApp.Models
{
    public class SaleModel
    {
        public int ClientID { get; set; }
        public string UserID { get; set; }
        public string DeviceAppID { get; set; }
        public string SecurityKey { get; set; }
        public int SalesID { get; set; }
        public double TransportCharge { get; set; }
        public double PackingCharge { get; set; }
        public double OtherCharge { get; set; }
        public double PaidCash { get; set; }
        public int PaymentTypeID { get; set; }
        public int UPITypeID { get; set; }
        public string TransNo { get; set; }
        public int CustomerID { get; set; }
        public string QRTransactionID { get; set; }
        public string QRPayTransactionID { get; set; }
        public List<SaleDetailsModel> SalesDetails { get; set; }
    }
}
