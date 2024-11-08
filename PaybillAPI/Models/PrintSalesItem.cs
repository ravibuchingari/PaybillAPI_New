namespace PaybillAPI.Models
{
    public class PrintSalesItem
    {
        public string ItemCode { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public string Measure { get; set; } = null!;
        public double Quantity { get; set; }
        public double Mrp { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double DiscountInRs { get; set; }
        public double TaxableAmount { get; set; }
        public float CgstPer { get; set; }
        public float SgstPer { get; set; }
        public float IgstPer { get; set; }
        public float GstPer { get; set; }
        public double CgstRs { get; set; }
        public double SgstRs { get; set; }
        public double IgstRs { get; set; }
        public double GstAmount { get; set; }
        public double TotalAmount { get; set; }
        public double SavingAmount { get; set; }
    }
}
