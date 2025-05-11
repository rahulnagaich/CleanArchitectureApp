using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureApp.Application.Features.Categories.Mapping;
using CleanArchitectureApp.Application.Features.Customers.Mapping;
using CleanArchitectureApp.Application.Features.Orders.Mapping;
using CleanArchitectureApp.Application.Features.Products.Mapping;

namespace CleanArchitectureApp.Application.Mappings
{
    public static class MappingProfileRegistration
    {
        public static IServiceCollection AddApplicationMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                // Registers all profiles in assembly
                cfg.AddMaps(typeof(CategoryMappingProfile).Assembly);
                cfg.AddMaps(typeof(ProductMappingProfile).Assembly);
                cfg.AddMaps(typeof(CustomerMappingProfile).Assembly);
                cfg.AddMaps(typeof(OrderMappingProfile).Assembly);
            });

            return services;
        }
    }
}
