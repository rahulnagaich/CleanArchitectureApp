using CleanArchitectureApp.Application.Features.Categories.Mapping;
using CleanArchitectureApp.Application.Features.Products.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Extensions
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
            });

            return services;
        }
    }
}
