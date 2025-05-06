using CleanArchitectureApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Persistence.Seeders
{
    public static class ProductSeeder
    {
        private static readonly Guid categoryId1 = Guid.Parse("D57907AD-C4EA-441F-A51C-9156427C8634");
        private static readonly Guid categoryId2 = Guid.Parse("DD3AFFFC-2BD7-49CE-95DE-2649C7D84481");

        public static void Seed(ModelBuilder builder) => builder.Entity<Product>().HasData(ProductList());

        private static List<Product> ProductList()
        {
            return
            [
                new Product(Guid.Parse("5EAECFB5-6783-48D6-9306-5FF666A29213"), "Smartphone", 599.99M, categoryId1)
        {
            CategoryId = categoryId1, // ✅ Explicitly required by EF for seeding
            CreatedBy = "System",
            CreatedDate = DateTime.Parse("2025-04-16 18:53:51.001")
        },
        new Product(Guid.Parse("8D5CA683-E1A2-49B2-B309-A5224342EE1F"), "Science Fiction Novel", 19.99M, categoryId2)
        {
            CategoryId = categoryId2, // ✅ Explicitly required
            CreatedBy = "System",
            CreatedDate = DateTime.Parse("2025-04-16 18:53:51.001")
        }
            ];
        }
    }
}
