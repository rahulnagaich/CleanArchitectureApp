using CleanArchitectureApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Entities
{
    public class Product: BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; } = [];

        [SetsRequiredMembers]
        public Product(Guid id, string name, decimal price, Guid categoryId)
        {
            Id = id;
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public void UpdatePrice(decimal newPrice) => Price = newPrice;
        public void Rename(string newName) => Name = newName;
    }
}
