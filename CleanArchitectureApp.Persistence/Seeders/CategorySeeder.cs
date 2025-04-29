using CleanArchitectureApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Persistence.Seeders
{
    public class CategorySeeder
    {
       public static readonly Guid categoryId1 = Guid.Parse("D57907AD-C4EA-441F-A51C-9156427C8634");
       public static readonly Guid categoryId2 = Guid.Parse("DD3AFFFC-2BD7-49CE-95DE-2649C7D84481");
        
        public static void Seed(ModelBuilder builder) => builder.Entity<Product>().HasData(CategoryList());
        
        private static List<Category> CategoryList()
        {
            return
            [
                new Category(categoryId1, "Electronics", "Electronic items") { CreatedBy = "System", CreatedDate =  DateTime.Parse("2025-04-15 16:55:23.002")},
                new Category(categoryId2, "Books", "Various kinds of books") { CreatedBy = "System", CreatedDate =  DateTime.Parse("2025-04-17 18:55:23.002")}
            ];
        }
    }
}
