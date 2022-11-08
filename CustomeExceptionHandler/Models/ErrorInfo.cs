using System.Text.Json;

namespace CustomeExceptionHandler.Models
{
    public class ErrorInfo
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
