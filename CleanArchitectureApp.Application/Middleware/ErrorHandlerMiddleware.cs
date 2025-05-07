
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using CleanArchitectureApp.Domain.Responses;
using CleanArchitectureApp.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace CleanArchitectureApp.Application.Middleware
{
    public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var responseModel = new BaseResponse<string>
            {
                Succeeded = false,
                Message = exception.Message
            };
            var httpStatusCode = exception switch
            {
                ValidationException => (int)HttpStatusCode.UnprocessableEntity,
                BadRequestException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                ApiException => (int)HttpStatusCode.InternalServerError,
                _ => (int)HttpStatusCode.InternalServerError
            };

            response.StatusCode = httpStatusCode;
            responseModel.StatusCode = (HttpStatusCode)httpStatusCode;

            // Add inner exception if exists
            if (exception.InnerException != null)
            {
                responseModel.Message += $" | Inner: {exception.InnerException.Message}";
            }

            _logger.LogError(exception, "Unhandled Exception - {Message}", exception.Message);

            var resultJson = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(resultJson);
        }
    }
}
