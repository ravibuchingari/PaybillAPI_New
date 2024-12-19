namespace PayBillApp.WinApp.Models
{
    public class SaleDetailsModel
    {
        public int SalesDetailsID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public double ExtraDiscountInRs { get; set; }
        public int AvailableQty { get; set; }
    }
}