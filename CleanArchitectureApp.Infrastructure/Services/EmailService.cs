using CleanArchitectureApp.Application.Interfaces.Infrastructure;
using CleanArchitectureApp.Domain.Requests;
using CleanArchitectureApp.Infrastructure.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure.Services
{
    public class EmailService(IOptions<MailSettings> mailSettings, ILogger<EmailService> logger) : IEmailService
    {
        public MailSettings MailSettings { get; } = mailSettings.Value;
        public ILogger<EmailService> Logger { get; } = logger;

        public async Task SendAsync(EmailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(MailSettings.SenderEmail)
                };
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder
                {
                    //if (mailRequest.Attachments != null)
                    //{
                    //    byte[] fileBytes;
                    //    foreach (var file in mailRequest.Attachments)
                    //    {
                    //        if (file.Length > 0)
                    //        {
                    //            using (var ms = new MemoryStream())
                    //            {
                    //                file.CopyTo(ms);
                    //                fileBytes = ms.ToArray();
                    //            }
                    //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    //        }
                    //    }
                    //}
                    HtmlBody = mailRequest.Body
                };
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(MailSettings.SmtpServer, MailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(MailSettings.SenderEmail, MailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
