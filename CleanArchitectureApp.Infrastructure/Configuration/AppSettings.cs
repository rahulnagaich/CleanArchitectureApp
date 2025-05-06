using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure.Configuration
{
    public class AppSettings
    {
        public required JWTSettings JWTConfigurations { get; set; }
        public required MailSettings MailConfigurations { get; set; }
        public bool UseInMemoryDatabase { get; set; }
        public required CorsSettings Cors { get; set; }
        public required BaseUrlSettings BaseURL { get; set; }
        public bool EnableExternalHealthCheck { get; set; }
        public required ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public required string DefaultConnection { get; set; }
    }

    public class CorsSettings
    {
        public bool AllowAnyOrigin { get; set; }
        public List<string> AllowedOrigins { get; set; } = [];
    }

    public class JWTSettings
    {
        public required string Key { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }

    public class MailSettings
    {
        public required string SmtpServer { get; set; }
        public int Port { get; set; }
        public required string SenderName { get; set; }
        public required string SenderEmail { get; set; }
        public required string Password { get; set; }
    }

    public class BaseUrlSettings
    {
        public required string HttpUrl { get; set; }
        public required string HttpsUrl { get; set; }
    }

}
