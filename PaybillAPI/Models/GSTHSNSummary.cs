namespace PaybillAPI.Models
{
    public class GSTHSNSummary
    {
        public string HsnCode { get; set; } = null!;
        public double Quantity { get; set; }
        public List<GSTData> Data { get; set; } = [];
    }

}
