using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Shared.Constants
{
    public static class ResponseMessage
    {
        public const string Success = "Operation completed successfully.";
        public const string Created = "Resource created successfully.";
        public const string NotFound = "Resource not found.";
        public const string BadRequest = "Bad request.";
        public const string InternalServerError = "An unexpected error occurred.";
        public const string Conflict = "A conflict occurred.";
        public const string Deleted = "Deleted Successfully";
        public const string Unauthorized = "UnAuthorized";
        public const string UnprocessableEntity = "Unprocessable Entity";
        public const string InternalError = "Something went wrong. Please try again later.";
        public const string NotFoundMessage = "The requested resource could not be found.";
        public const string AppConfigurationMessage = "Unable to retrieve application settings.";
        public const string TransactionNotCommit = "The transaction could not be committed.";
        public const string TransactionNotExecute = "The transaction could not be executed.";
    }
}
