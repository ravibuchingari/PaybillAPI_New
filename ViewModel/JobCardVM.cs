using Paybill.Models;

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
        public PartyVM PartyModel { get; set; } = new();

        public string? StatusName { get; set; }
        public double TotalCharges { get; set; }

        public string RequestDate
        {
            get => ServiceRequestDate;
            set => ServiceRequestDate = value ?? string.Empty;
        }
        public int JobCardStatusId
        {
            get => ServiceRequestStatusId;
            set => ServiceRequestStatusId = value;
        }
        public string Status
        {
            get => !string.IsNullOrWhiteSpace(StatusName)
                ? StatusName
                : ServiceRequestStatusId switch
                {
                    1 => "Received",
                    2 => "In Progress",
                    3 => "Completed",
                    4 => "Delivered",
                    5 => "Cancelled",
                    _ => "Pending"
                };
            set => StatusName = value;
        }
        public PartyVM Party
        {
            get => PartyModel;
            set => PartyModel = value ?? new PartyVM();
        }
        public int PartyId
        {
            get => PartyModel.PartyId;
            set => PartyModel.PartyId = value;
        }
        public string Summary
        {
            get => ServiceRequestDescription;
            set => ServiceRequestDescription = value ?? string.Empty;
        }
        public string? Remarks { get; set; } = string.Empty;
        public List<JobCardItemVM> ServiceTypes
        {
            get => Complaints;
            set => Complaints = value ?? [];
        }
        public double TotalTaxableAmount => Complaints.Sum(c => c.TaxableAmount > 0 ? c.TaxableAmount : c.ServiceCharge) + Spares.Sum(s => s.TaxableAmount);
        public double TotalCgst => Complaints.Sum(c => c.CgstAmount) + Spares.Sum(s => s.CgstRs);
        public double TotalSgst => Complaints.Sum(c => c.SgstAmount) + Spares.Sum(s => s.SgstRs);
        public double TotalIgst => Complaints.Sum(c => c.IgstAmount) + Spares.Sum(s => s.IgstRs);
        public double TotalNetAmount => TotalCharges > 0
            ? TotalCharges
            : Complaints.Sum(c => c.TotalAmount > 0 ? c.TotalAmount : c.ServiceCharge) + Spares.Sum(s => s.TotalAmount);
    }

    public class JobCardItemVM
    {
        public int ServiceRequestComplaintId { get; set; }
        public int ServiceRequestId { get; set; }
        public double ServiceCharge { get; set; }
        public ServiceTypeVM ServiceTypeModel { get; set; } = new();
        public string? CustomerRemarks { get; set; } = string.Empty;
        public string? TechnicianRemarks { get; set; } = string.Empty;
        public double Quantity { get; set; } = 1;
        public double TaxableAmount { get; set; }
        public int GstId { get; set; }
        public float CgstPer { get; set; }
        public float SgstPer { get; set; }
        public float IgstPer { get; set; }
        public double CgstAmount { get; set; }
        public double SgstAmount { get; set; }
        public double IgstAmount { get; set; }
        public double DiscountRs { get; set; }
        public double TotalAmount { get; set; }

        public int ComplaintId
        {
            get => ServiceRequestComplaintId;
            set => ServiceRequestComplaintId = value;
        }
        public int ServiceTypeId
        {
            get => ServiceTypeModel.ServiceTypeId;
            set => ServiceTypeModel.ServiceTypeId = value;
        }
        public string ServiceTypeName
        {
            get => ServiceTypeModel.ServiceTypeName;
            set => ServiceTypeModel.ServiceTypeName = value ?? string.Empty;
        }
        public double Price
        {
            get => ServiceCharge;
            set => ServiceCharge = value;
        }
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
