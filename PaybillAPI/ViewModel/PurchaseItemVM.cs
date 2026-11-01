namespace Paybill.ViewModel
{
    public class PurchaseItemVM
    {
        public int PurchaseItemId { get; set; }
        public int PurchaseId { get; set; }
        public float Quantity { get; set; }
        public float FreeQuantity { get; set; }
        public float Mrp { get; set; }
        public float Rate { get; set; }
        public float SalesPrice { get; set; }
        public double Amount { get; set; }
        public float DiscountPer { get; set; }
        public double DiscountInRs { get; set; }
        public int GstId { get; set; }
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
        public ItemVM ItemModel { get; set; } = new();
        public string? CreatedDate { get; set; }
        public string? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedRemarks { get; set; }
        public string? InvoiceNumber { get; set; }

        public ItemVM Item
        {
            get => ItemModel;
            set => ItemModel = value ?? new ItemVM();
        }
        public int ItemId
        {
            get => ItemModel.ItemId;
            set => ItemModel.ItemId = value;
        }
        public float PurchasePrice
        {
            get => Rate;
            set
            {
                Rate = value;
                if (Amount == 0 && Quantity > 0)
                    Amount = Math.Round(Quantity * value, 2);
            }
        }
        public double DiscountRs
        {
            get => DiscountInRs;
            set => DiscountInRs = value;
        }
        public double CgstAmount
        {
            get => CgstRs;
            set
            {
                CgstRs = value;
                GstAmount = CgstRs + SgstRs + IgstRs;
            }
        }
        public double SgstAmount
        {
            get => SgstRs;
            set
            {
                SgstRs = value;
                GstAmount = CgstRs + SgstRs + IgstRs;
            }
        }
        public double IgstAmount
        {
            get => IgstRs;
            set
            {
                IgstRs = value;
                GstAmount = CgstRs + SgstRs + IgstRs;
            }
        }
        public string? PurchaseDate
        {
            get => CreatedDate;
            set => CreatedDate = value;
        }
        public string? Remarks
        {
            get => DeletedRemarks;
            set => DeletedRemarks = value;
        }
    }

    //public class PurchaseItemVM
    //{
    //    public int PurchaseItemId { get; set; }

    //    public int PurchaseId { get; set; }

    //    public float Quantity { get; set; }

    //    public float Rate { get; set; }

    //    public double Amount { get; set; }

    //    public double DiscountInRs { get; set; }

    //    public float CgstPer { get; set; }

    //    public float SgstPer { get; set; }

    //    public float IgstPer { get; set; }

    //    public float GstPer { get; set; }

    //    public double CgstRs { get; set; }

    //    public double SgstRs { get; set; }

    //    public double IgstRs { get; set; }

    //    public double GstAmount { get; set; }

    //    public double TaxableAmount { get; set; }

    //    public double TotalAmount { get; set; }

    //    public ItemVM ItemModel { get; set; } = new ItemVM();
    //    public string? CreatedDate { get; set; }
    //    public string? DeletedDate { get; set; }
    //    public string? DeletedBy { get; set; }
    //    public string? DeletedRemarks { get; set; }
    //}
}
