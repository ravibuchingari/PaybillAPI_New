namespace Paybill.ViewModel
{
    public class JobCardVM
    {
        public int ServiceRequestId { get; set; }
        public int? SalesId { get; set; }
        public string JobCardNumber { get; set; } = string.Empty;
        public string ServiceRequestDate { get; set; } = string.Empty;
        public int ServiceRequestStatusId { get; set; } = 1;
        public string ServiceRequestDescription { get; set; } = string.Empty;
        public List<JobCardItemVM> Complaints { get; set; } = [];
        public List<JobCardSpareVM> Spares { get; set; } = [];
        public PartyVM PartyModel { get; set; } = new PartyVM();
    }

    public class JobCardItemVM
    {
        public int ServiceRequestComplaintId { get; set; }
        public double ServiceCharge { get; set; }
        public ServiceTypeVM ServiceTypeModel { get; set; } = new ServiceTypeVM();
    }

    public class JobCardSpareVM
    {
        public int JobCardSpareId { get; set; }
        public int ServiceRequestId { get; set; }
        public ItemVM ItemModel { get; set; } = new();
        public double Quantity { get; set; } = 1.0;
        public double Mrp { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double DiscountInRs { get; set; }
        public double TaxableAmount { get; set; }
        public int GstId { get; set; }
        public float GstPer { get; set; }
        public float CgstPer { get; set; }
        public float SgstPer { get; set; }
        public float IgstPer { get; set; }
        public double CgstRs { get; set; }
        public double SgstRs { get; set; }
        public double IgstRs { get; set; }
        public double GstAmount { get; set; }
        public double TotalAmount { get; set; }

        public int SpareId
        {
            get => JobCardSpareId;
            set => JobCardSpareId = value;
        }
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
        public double SalesPrice
        {
            get => Rate;
            set => Rate = value;
        }
        public double DiscountRs
        {
            get => DiscountInRs;
            set => DiscountInRs = value;
        }
        public double CgstAmount
        {
            get => CgstRs;
            set => CgstRs = value;
        }
        public double SgstAmount
        {
            get => SgstRs;
            set => SgstRs = value;
        }
        public double IgstAmount
        {
            get => IgstRs;
            set => IgstRs = value;
        }
    }
}

