namespace Paybill.Models
{
    public class ResponseMessage
    {
        public ResponseMessage()
        {
        }

        public ResponseMessage(bool isSuccess, string message = "", object? data = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data?.ToString();
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Data { get; set; }
    }
}
