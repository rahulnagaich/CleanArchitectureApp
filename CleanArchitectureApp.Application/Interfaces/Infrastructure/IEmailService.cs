using CleanArchitectureApp.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Infrastructure
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
