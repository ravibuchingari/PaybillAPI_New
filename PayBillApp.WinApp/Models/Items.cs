namespace PayBillApp.WinApp.Models
{
    public class Items
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemAaliasNname { get; set; }
        public double ItemMRP { get; set; }
        public double ItemPrice { get; set; }
        public float ItemDiscountPer { get; set; }
        public float ItemGSTPer { get; set; }
        public string LocalLanguage { get; set; }
    }
}
