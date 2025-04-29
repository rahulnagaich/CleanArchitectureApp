using CleanArchitectureApp.Domain.Common;
using CleanArchitectureApp.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Responses
{
    public static class ResponseHandler
    {
        public static BaseResponse<T> Deleted<T>()
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = ResponseMessage.Deleted
            };
        }

        public static BaseResponse<T> Success<T>(T entity, string? message = null)
        {
            return new BaseResponse<T>
            {
                Data = entity,
                Succeeded = true,
                Message = string.IsNullOrWhiteSpace(message) ? ResponseMessage.Success : message,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static BaseResponse<T> Unauthorized<T>()
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = ResponseMessage.Unauthorized
            };
        }

        public static BaseResponse<T> BadRequest<T>(string message, List<string>? errors = null)
        {
            return new BaseResponse<T>
            {
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? ResponseMessage.BadRequest : message,
                Errors = errors ?? [],
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public static BaseResponse<T> Conflict<T>(string? message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.Conflict,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? ResponseMessage.Conflict : message
            };
        }

        public static BaseResponse<T> UnprocessableEntity<T>(string? message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? ResponseMessage.UnprocessableEntity : message
            };
        }

        public static BaseResponse<T> NotFound<T>(string? message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? ResponseMessage.NotFound : message
            };
        }

        public static BaseResponse<T> Created<T>(T entity, string? message = null)
        {
            return new BaseResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = ResponseMessage.Created
            };
        }
    }
}
