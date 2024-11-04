namespace PaybillAPI.Models
{
    public class GSTReturnStatement
    {
        public string InvoiceDate { get; set; } = null!;
        public List<GSTData> Data { get; set; } = [];
    }

    public class GSTData
    {
        public double TaxableAmount { get; set; }
        public float GstPer { get; set; }
        public double GstAmount { get; set; }
    }

}
