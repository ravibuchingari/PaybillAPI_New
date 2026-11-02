namespace Paybill.ViewModel
{
    public class MessageTemplateVM
    {
        public int MessageId { get; set; }
        public string MessageType { get; set; } = "Sales Invoice Message";
        public string MessageDescription { get; set; } = string.Empty;
        public bool IsSelected { get; set; }

        public string Description
        {
            get => MessageDescription;
            set => MessageDescription = value ?? string.Empty;
        }
    }
}

