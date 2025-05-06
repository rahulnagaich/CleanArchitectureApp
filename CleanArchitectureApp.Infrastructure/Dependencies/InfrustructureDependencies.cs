using CleanArchitectureApp.Application.Interfaces.Infrastructure;
using CleanArchitectureApp.Infrastructure.Configuration;
using CleanArchitectureApp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureApp.Infrastructure.Dependencies
{
    public static class InfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            //services.AddHttpContextAccessor(); // need to fix

            return services;
        }
    }
}
