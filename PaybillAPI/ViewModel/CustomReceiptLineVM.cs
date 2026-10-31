namespace PaybillAPI.ViewModel
{
    public class CustomReceiptLineVM
    {
        public int CustomLineId { get; set; }
        public string CustomLineTitle { get; set; } = string.Empty;
        public string CustomLineDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}

