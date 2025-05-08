using CleanArchitectureApp.Application.Interfaces.Infrastructure;
using CleanArchitectureApp.Infrastructure.Configuration;
using CleanArchitectureApp.Infrastructure.Export;
using CleanArchitectureApp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace CleanArchitectureApp.Infrastructure.Extensions
{
    public static class InfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.AddFeatureManagement();
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            //services.AddHttpContextAccessor(); // need to fix
            

            return services;
        }
    }
}
