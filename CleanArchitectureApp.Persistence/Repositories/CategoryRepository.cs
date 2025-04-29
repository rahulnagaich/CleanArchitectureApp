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
    public class CategoryRepository(IDatabaseService dbContext) : GenericRepository<Category>(dbContext), ICategoryRepository
    {
        public async Task<List<Category>> GetCategoriesWithProducts(CancellationToken cancellationToken = default)
        {
            return await _dbSet.Include(x => x.Products).ToListAsync(cancellationToken);
        }

        public async Task<bool> IsCategoryName(string name, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(e => e.Name.Equals(name),cancellationToken);
        }

        public async Task<Category?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
        }
    }
}
