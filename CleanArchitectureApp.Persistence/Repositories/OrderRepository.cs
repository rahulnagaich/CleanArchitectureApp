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
    public class OrderRepository(IDatabaseService dbContext) : GenericRepository<Order>(dbContext), IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken=default)
        {
            return await _dbSet
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.OrderProducts)
                .ToListAsync(cancellationToken);
        }

        public async Task<Order?> GetWithItemsAsync(Guid orderId, CancellationToken cancellationToken=default)
        {
            return await _dbSet
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.Id == orderId,cancellationToken);
        }
    }
}
