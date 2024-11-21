namespace PaybillAPI.ViewModel
{
    public class ServiceTypeVM
    {
        public int ServiceTypeId { get; set; }

        public string ServiceTypeName { get; set; } = null!;

        public double ServiceCharge { get; set; }

        public string? ServiceDescription { get; set; }

        public string? SacCode { get; set; }

        public bool IsActive { get; set; }

        public GstVM? GstModel { get; set; }
    }
}
