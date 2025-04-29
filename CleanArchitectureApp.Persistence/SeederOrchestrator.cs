using CleanArchitectureApp.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Persistence
{
    public static class SeederOrchestrator
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Call all individual seeders here
            CategorySeeder.Seed(modelBuilder);
            ProductSeeder.Seed(modelBuilder);
        }
    }
}
