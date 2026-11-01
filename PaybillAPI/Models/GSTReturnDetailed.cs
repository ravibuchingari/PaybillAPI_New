namespace Paybill.Models
{
    public class GSTReturnDetailed
    {
        public int SalesId { get; set; }
        public string? InvoiceNo { get; set; } = string.Empty;
        public string InvoiceDate { get; set; } = string.Empty;
        public string? PartyName { get; set; } = string.Empty;
        public string? PartyGstin { get; set; } = string.Empty;
        public List<GSTData> Data { get; set; } = [];
        public bool IsHeader { get; set; }

        public string Type { get; set; } = "Sales";
        public string TransactionDate => InvoiceDate;
        public string? InvoiceNumber => InvoiceNo;
        public string? Gstin => PartyGstin;
        public double TaxableAmount => Data.Sum(d => d.TaxableAmount);
        public float GstPer => Data.FirstOrDefault()?.GstPer ?? 0;
        public double CgstAmount => Data.Sum(d => d.CgstAmount);
        public double SgstAmount => Data.Sum(d => d.SgstAmount);
        public double IgstAmount => Data.Sum(d => d.IgstAmount);
        public double InvoiceTotal => Data.Sum(d => d.TaxableAmount + d.GstAmount);
    }
}
