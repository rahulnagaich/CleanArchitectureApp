using CleanArchitectureApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Persistence.Repositories
{
    public interface IOrderProductRepository
    {
        Task<IEnumerable<OrderProduct?>> GetByOrderIdAsync(Guid orderId);
        //Task AddAsync(OrderProduct orderProduct);
        //Task UpdateAsync(OrderProduct orderProduct);
        //Task DeleteAsync(Guid orderId, Guid productId);
    }
}
