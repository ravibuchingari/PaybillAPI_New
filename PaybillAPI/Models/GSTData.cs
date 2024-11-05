namespace PaybillAPI.Models
{
    public class GSTData
    {
        public float GstPer { get; set; }
        public double TaxableAmount { get; set; }
        public float IgstPer { get; set; }
        public float CgstPer { get; set; }
        public float SgstPer { get; set; }
        public double IgstAmount { get; set; }
        public double CgstAmount { get; set; }
        public double SgstAmount { get; set; }
        public double GstAmount { get; set; }
    }
}
