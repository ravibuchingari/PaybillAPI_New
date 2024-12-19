namespace PayBillApp.WinApp.Models
{
    internal class ItemModel
    {
        public int SalesDetailID { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double MRP { get; set; }
        public double Rate { get; set; }
        public double DiscountInRs { get; set; }
        public double Amount { get; set; }
        public float GSTInPer { get; set; }
        public double GSTInRs { get; set; }
        public double TotalAmount { get; set; }

    }
}
