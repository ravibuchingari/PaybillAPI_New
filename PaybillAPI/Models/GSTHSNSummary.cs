namespace Paybill.Models
{
    public class GSTHSNSummary
    {
        public string HsnCode { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public List<GSTData> Data { get; set; } = [];

        public string ItemName => $"HSN/SAC {HsnCode}";
        public string Measure => "NOS";
        public double TotalQuantity => Quantity;
        public double TotalTaxableAmount => Data.Sum(d => d.TaxableAmount);
        public float GstPer => Data.FirstOrDefault()?.GstPer ?? 0;
        public double TotalCgst => Data.Sum(d => d.CgstAmount);
        public double TotalSgst => Data.Sum(d => d.SgstAmount);
        public double TotalIgst => Data.Sum(d => d.IgstAmount);
        public double TotalValue => Data.Sum(d => d.TaxableAmount + d.GstAmount);
    }
}
