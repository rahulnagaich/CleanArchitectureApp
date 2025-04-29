using CleanArchitectureApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Entities
{
    public class Category: BaseEntity<Guid>
    {
        public string Name { get; private set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; private set; } = [];

        [SetsRequiredMembers]
        public Category(Guid id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = true;
        }

        public void UpdateName(string newName) => Name = newName;
    }
}
