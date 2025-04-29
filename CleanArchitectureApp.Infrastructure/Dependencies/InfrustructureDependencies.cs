using CleanArchitectureApp.Application.Interfaces.Infrastructure;
using CleanArchitectureApp.Domain.Settings;
using CleanArchitectureApp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureApp.Infrastructure.Dependencies
{
    public static class InfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
           // services.AddHttpContextAccessor(); will fix latter for user service

            return services;
        }
    }
}
