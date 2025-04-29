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
    public class ProductRepository(IDatabaseService dbContext) : GenericRepository<Product>(dbContext), IProductRepository
    {
        public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
        }

        public async Task<List<Product>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync(cancellationToken);
        }

        public async Task<List<Product>> ProductsWithGetCategory(CancellationToken cancellationToken = default)
        {
            return await _dbSet.Include(x => x.Category).ToListAsync(cancellationToken);
        }
    }
}
