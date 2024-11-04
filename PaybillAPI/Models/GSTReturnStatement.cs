namespace PaybillAPI.Models
{
    public class GSTReturnStatement
    {
        public string InvoiceDate { get; set; } = null!;
        public double TurnoverAmount { get; set; }
        public double TaxableAmount { get; set; }
        public double IgstAmount { get; set; }
        public double cgstAmount { get; set; }
        public double sgstAmount { get; set; }
        public double GstAmount { get; set; }
        public List<GSTData> Data { get; set; } = [];
    }

    public class GSTData
    {
        public double TurnoverAmount { get; set; }
        public double TaxableAmount { get; set; }
        public float GstPer { get; set; }
        public float IgstPer { get; set; }
        public float CgstPer { get; set; }
        public float SgstPer { get; set; }
        public double IgstAmount { get; set; }
        public double CgstAmount { get; set; }
        public double SgstAmount { get; set; }
        public double GstAmount { get; set; }
    }

}
