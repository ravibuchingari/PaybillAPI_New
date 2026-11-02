namespace Paybill.ViewModel
{
    public class CustomReceiptLineVM
    {
        public int CustomLineId { get; set; }
        public string CustomLineTitle { get; set; } = string.Empty;
        public string CustomLineDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } = 1;
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }

        public string LineText
        {
            get => !string.IsNullOrWhiteSpace(CustomLineDescription) ? CustomLineDescription : CustomLineTitle;
            set
            {
                CustomLineDescription = value ?? string.Empty;
                if (string.IsNullOrWhiteSpace(CustomLineTitle))
                    CustomLineTitle = value ?? string.Empty;
            }
        }
    }
    //public class CustomReceiptLineVM
    //{
    //    public int CustomLineId { get; set; }
    //    public string CustomLineTitle { get; set; } = string.Empty;
    //    public string CustomLineDescription { get; set; } = string.Empty;
    //    public bool IsActive { get; set; } = true;
    //}
}

