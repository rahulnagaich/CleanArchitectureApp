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
        public static void Seed(ModelBuilder builder) => builder.Entity<Product>().HasData(ProductList());

        private static List<Product> ProductList()
        {
            return
            [

                new Product(Guid.Parse("5EAECFB5-6783-48D6-9306-5FF666A29213"),"Smartphone", 599.99M,CategorySeeder.categoryId1)
                {
                    CreatedBy = "System",
                    CreatedDate = DateTime.Parse("2025-04-16 18:53:51.001")
                },
                new Product(Guid.Parse("8D5CA683-E1A2-49B2-B309-A5224342EE1F"),"Science Fiction Novel",19.99M,CategorySeeder.categoryId2)
                {
                    CreatedBy = "System",
                    CreatedDate = DateTime.Parse("2025-04-16 18:53:51.001")
                }
            ];
        }
    }
}
