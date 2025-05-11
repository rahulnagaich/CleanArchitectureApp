using System.Net;
using System.Text.Json.Serialization;

namespace CleanArchitectureApp.Shared.Responses
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
        }
        public BaseResponse(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public BaseResponse(string message)
        {
            Message = message;
        }
        public BaseResponse(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public HttpStatusCode StatusCode { get; set; }

        public bool Succeeded { get; set; } = false;

        public string? Message { get; set; } = string.Empty;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Errors { get; set; } = [];

        public T? Data { get; set; }= default!;
    }
}
