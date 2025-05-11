using CleanArchitectureApp.Application.Interfaces.Infrastructure;
using CleanArchitectureApp.Domain.Common;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitectureApp.Persistence.Context
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;

        public DatabaseService(DbContextOptions<DatabaseService> options, ICurrentUserService currentUserService, IDateTimeService dateTimeService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;//you don't need to explicitly call .AsNoTracking() for each query, because tracking is already disabled globally
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // First, call base
            base.OnModelCreating(builder);

            // Then apply your configurations
            ModelBuilderExtensions.ApplyConfigurations(builder);// <-- 👈 calling your clean extension method

            // Seed static data here
            SeederOrchestrator.Seed(builder);// Call the orchestrator instead of calling individual seeders
        }

        public new DbSet<T> Set<T>() where T : class => base.Set<T>();

        public new void Attach<T>(T entity) where T : class => base.Set<T>().Attach(entity);

        public new EntityEntry Entry(object entity) => base.Entry(entity);

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;
            var userId = _currentUserService.UserId ?? "System";// remove and handle from user service

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = _dateTimeService.UtcNow;
                    entry.Entity.CreatedBy = userId;
                    entry.Entity.LastModifiedDate = _dateTimeService.UtcNow;
                    entry.Entity.LastModifiedBy = userId;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedDate = _dateTimeService.UtcNow;
                    entry.Entity.LastModifiedBy = userId;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public int Save()
        {
            return this.SaveChanges();
        }
    }
}
