using CleanArchitectureApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Persistence.Repositories
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {
        Task<Customer?> GetCustomerByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
