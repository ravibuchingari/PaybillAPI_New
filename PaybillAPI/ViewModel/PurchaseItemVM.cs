namespace PaybillAPI.ViewModel
{
    public class PurchaseItemVM
    {
        public int PurchaseItemId { get; set; }

        public int PurchaseId { get; set; }

        public float Quantity { get; set; }

        public float Rate { get; set; }

        public double Amount { get; set; }

        public double DiscountInRs { get; set; }

        public float CgstPer { get; set; }

        public float SgstPer { get; set; }

        public float IgstPer { get; set; }

        public float GstPer { get; set; }

        public double CgstRs { get; set; }

        public double SgstRs { get; set; }

        public double IgstRs { get; set; }

        public double GstAmount { get; set; }

        public double TaxableAmount { get; set; }

        public double TotalAmount { get; set; }

        public ItemVM? ItemModel { get; set; }
        public string CreatedDate { get; set; }
    }
}
