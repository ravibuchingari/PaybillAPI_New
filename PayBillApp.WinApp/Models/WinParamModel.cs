namespace PayBillApp.WinApp.Models
{
    public class WinParamModel
    {
        public int ClientID { get; set; }
        public string UserID { get; set; }
        public string MachineID { get; set; }
        public string SecurityKey { get; set; }
        public int WinQRCodeID { get; set; }
        public string SearchParam { get; set; }
        public string CommonParam { get; set; }
    }
}
