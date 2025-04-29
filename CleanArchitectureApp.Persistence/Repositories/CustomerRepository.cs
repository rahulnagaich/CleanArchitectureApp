using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Persistence.Repositories
{
    public class CustomerRepository(IDatabaseService dbContext) : GenericRepository<Customer>(dbContext), ICustomerRepository
    {
        public async Task<Customer?> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase), cancellationToken);
        }
    }
}
