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
    public class OrderProductRepository(IDatabaseService dbContext) : GenericRepository<OrderProduct>(dbContext), IOrderProductRepository
    {
        public async Task<IEnumerable<OrderProduct?>> GetByOrderIdAsync(Guid orderId)
        {
            return await _dbSet
                .Include(op => op.Product)
                .Where(op => op.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<OrderProduct?> GetByIdsAsync(Guid orderId, Guid productId)
        {
            return await _dbSet.FirstOrDefaultAsync(op => op.OrderId == orderId && op.ProductId == productId);
        }

        //public async Task AddAsync(OrderProduct orderProduct)
        //{
        //    await dbContext.OrderProducts.AddAsync(orderProduct);
        //    await dbContext.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(OrderProduct orderProduct)
        //{
        //    dbContext.OrderProducts.Update(orderProduct);
        //    await dbContext.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(Guid orderId, Guid productId)
        //{
        //    var entity = await GetByIdsAsync(orderId, productId);
        //    if (entity != null)
        //    {
        //        dbContext.OrderProducts.Remove(entity);
        //        await dbContext.SaveChangesAsync();
        //    }
        //}
    }
}
