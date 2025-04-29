using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Responses
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
            Succeeded = false;
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
        public List<string> Errors { get; set; } = [];
        public T? Data { get; set; }= default!;
    }
}
