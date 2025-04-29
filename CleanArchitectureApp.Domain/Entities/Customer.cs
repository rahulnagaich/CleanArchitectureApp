using CleanArchitectureApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Domain.Entities
{
    public class Customer : BaseEntity<Guid>
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }

        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        [SetsRequiredMembers]
        public Customer(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public void UpdateContact(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }

}
