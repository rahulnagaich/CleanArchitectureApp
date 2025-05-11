//using Microsoft.AspNetCore.Http;

namespace CleanArchitectureApp.Shared.Requests
{
    public class EmailRequest
    {
        public required string ToEmail { get; set; }
        public required string Subject { get; set; }
        public required string Body { get; set; }
        //public List<IFormFile> Attachments { get; set; }

    }
}
