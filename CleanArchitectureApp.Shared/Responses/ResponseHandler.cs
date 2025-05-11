using CleanArchitectureApp.Shared.Constants;
using System.Net;

namespace CleanArchitectureApp.Shared.Responses
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
                Message = string.IsNullOrWhiteSpace(message) ? ResponseMessage.Created: message
            };
        }

        public static PagedResponse<T> PagedSuccess<T>(PagedResponse<T> pagedResponse, string? message = null)
        {
            return new PagedResponse<T>(pagedResponse.Data, pagedResponse.PageNumber, pagedResponse.PageSize, pagedResponse.TotalCount, string.IsNullOrWhiteSpace(message) ? ResponseMessage.Success : message)
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        public static PagedResponse<T> PagedBadRequest<T>(string message, List<string>? errors = null)
        {
            return new PagedResponse<T>([], 0, 0, 0, string.IsNullOrWhiteSpace(message) ? ResponseMessage.BadRequest : message)
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Errors = errors ?? []
            };
        }

        public static PagedResponse<T> PagedNotFound<T>(string? message = null)
        {
            return new PagedResponse<T>([], 0, 0, 0, string.IsNullOrWhiteSpace(message) ? ResponseMessage.NotFound : message)
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? ResponseMessage.NotFound : message
            };
        }

        // we can add more paged versions as needed, e.g., Unauthorized, Conflict, etc.
    }
}
