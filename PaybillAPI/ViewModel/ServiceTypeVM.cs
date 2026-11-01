namespace Paybill.ViewModel
{
    public class ServiceTypeVM
    {
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; } = string.Empty;
        public double ServiceCharge { get; set; }
        public string? ServiceDescription { get; set; } = string.Empty;
        public string? SacCode { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public GstVM? GstModel { get; set; }

        public double Rate
        {
            get => ServiceCharge;
            set => ServiceCharge = value;
        }
        public GstVM? Gst
        {
            get => GstModel;
            set => GstModel = value;
        }
        public int GstId
        {
            get => GstModel?.GstId ?? 0;
            set
            {
                GstModel ??= new GstVM();
                GstModel.GstId = value;
            }
        }
    }
}
