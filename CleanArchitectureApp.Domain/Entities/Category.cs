using CleanArchitectureApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public required string Name { get; set; } // Added 'required' modifier
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; } = [];

        [SetsRequiredMembers]
        public Category(Guid id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = true;
        }

        // EF Core requires a parameterless constructor
        [SetsRequiredMembers]
        protected Category()
        {
            Name = string.Empty;
            IsActive = true;
        }

        public void UpdateName(string newName) => Name = newName;
    }
}
