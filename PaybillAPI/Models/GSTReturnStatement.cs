﻿namespace PaybillAPI.Models
{
    public class GSTReturnStatement
    {
        public string InvoiceDate { get; set; } = null!;
        public double TurnoverAmount { get; set; }
        public double TaxableAmount { get; set; }
        public double IgstAmount { get; set; }
        public double CgstAmount { get; set; }
        public double SgstAmount { get; set; }
        public double GstAmount { get; set; }
        public List<GSTData> Data { get; set; } = [];
    }

}
