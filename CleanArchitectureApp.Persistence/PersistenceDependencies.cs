using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Persistence.Context;
using CleanArchitectureApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Persistence
{
    public static class PersistenceDependencies
    {
        public static IServiceCollection AddPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<DatabaseService>(options =>
            //  options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            //  b => b.MigrationsAssembly(typeof(DatabaseService).Assembly.FullName)));

            // Register DbContext
            services.AddDbContext<DatabaseService>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Bind interface to concrete
            services.AddScoped<IDatabaseService>(provider => provider.GetRequiredService<DatabaseService>());

            // Register repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
