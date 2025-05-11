
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Persistence.Extensions;
using CleanArchitectureApp.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDatabaseService _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(IDatabaseService dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        //public virtual async Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        //public virtual async Task<T?> GetByIdAsync(object id)
        //{
        //    var entity = await _dbContext.Set<T>().FindAsync(id);
        //    return entity ?? default!;//default! is used to suppress the compiler warning in case T is a non-nullable reference type
        //}

        //public async Task<IReadOnlyList<T>> GetAllAsync()
        //{
        //    return await _dbContext
        //         .Set<T>()
        //         .ToListAsync();
        //}

        //public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        //{
        //    return await _dbContext
        //        .Set<T>()
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .AsNoTracking()
        //        .ToListAsync();
        //}

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Attach(entity); // Attach ensures the entity is tracked
            _dbContext.Entry(entity).State = EntityState.Modified;//EntityState.Modified marks the entire entity as changed — useful, but if you want partial updates,

            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(predicate, cancellationToken);

        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);

        public async Task<IReadOnlyList<T>> GetAllReadOnlyListAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);

        public async Task<TResult?> GetProjectedByIdAsync<TResult>(Expression<Func<T, bool>> filter, 
            IConfigurationProvider configurationProvider, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>()
                .Where(filter)
                .ProjectTo<TResult>(configurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<PagedResponse<T>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var count = await _dbSet.CountAsync(cancellationToken);
            var items = await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync(cancellationToken);
            return new PagedResponse<T>(items, pageNumber, pageSize, count, string.Empty); // Added the missing 'v' parameter with a default value
        }

        public async Task<PagedResponse<T>> GetPagedListAsync(
            int pageNumber, int pageSize,
            string? orderBy = null, string sortDirection = "ASC",
            Expression<Func<T, bool>>? filter = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            query = query.ApplySorting(orderBy, sortDirection); // Dynamic ordering
            query = query.ApplyPaging(pageNumber, pageSize); // Apply paging

            var count = await query.CountAsync(cancellationToken);
            var items = await query.ToListAsync(cancellationToken);

            return new PagedResponse<T>(items, pageNumber, pageSize, count, string.Empty); // Added the missing 'v' parameter with a default value
        }

        public async Task<PagedResponse<TResult>> GetProjectedPagedListAsync<TResult>(
            IConfigurationProvider configurationProvider,
            int pageNumber, int pageSize,
            string? orderBy = null, string sortDirection = "ASC",
            Expression<Func<T, bool>>? filter = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            var count = await query.CountAsync(cancellationToken);

            var projectedQuery = query.ProjectTo<TResult>(configurationProvider);

            projectedQuery = projectedQuery.ApplySorting(orderBy, sortDirection);
            projectedQuery = projectedQuery.ApplyPaging(pageNumber, pageSize);

            var items = await projectedQuery.ToListAsync(cancellationToken);

            return new PagedResponse<TResult>(items, pageNumber, pageSize, count, string.Empty); 
        }

        //// Removed one of the duplicate methods causing CS0111 error
        //public async Task<PagedResponse<T>> GetPagedListAsync(
        //    int pageNumber, int pageSize,
        //    string? orderBy = null, string sortDirection = "ASC",
        //    Expression<Func<T, bool>>? filter = null,
        //    CancellationToken cancellationToken = default)
        //{
        //    IQueryable<T> query = _dbSet;

        //    if (filter != null)
        //        query = query.Where(filter);

        //    query = query.ApplySorting(orderBy, sortDirection); // Dynamic ordering
        //    query = query.ApplyPaging(pageNumber, pageSize); // Apply paging

        //    var count = await query.CountAsync(cancellationToken);
        //    var items = await query.ToListAsync(cancellationToken);

        //    return new PagedResponse<T>(items, pageNumber, pageSize, count, string.Empty);
        //}

        public async Task<PagedResponse<T>> GetProjectedPagedListAsync<TResult>(int pageNumber, int pageSize,
            IConfigurationProvider configurationProvider, CancellationToken cancellationToken = default)
        {
            var count = await _dbSet.CountAsync(cancellationToken);

            IQueryable<T> query = _dbSet;
            query = (IQueryable<T>)query.ProjectTo<TResult>(configurationProvider);
            query = query.ApplyPaging(pageNumber, pageSize); // Apply paging

            var items = await query.ToListAsync(cancellationToken);

            return new PagedResponse<T>(items, pageNumber, pageSize, count, string.Empty);
        }

        // Removed one of the duplicate methods causing CS0111 error
        //public async Task<PagedResponse<TResult>> GetProjectedPagedListAsync<TResult>(
        //    IConfigurationProvider configurationProvider,
        //    int pageNumber, int pageSize,
        //    string? orderBy = null, string sortDirection = "ASC",
        //    Expression<Func<T, bool>>? filter = null,
        //    CancellationToken cancellationToken = default)
        //{
        //    IQueryable<T> query = _dbSet;

        //    if (filter != null)
        //        query = query.Where(filter);

        //    var count = await query.CountAsync(cancellationToken);

        //    var projectedQuery = query.ProjectTo<TResult>(configurationProvider);

        //    projectedQuery = projectedQuery.ApplySorting(orderBy, sortDirection);
        //    projectedQuery = projectedQuery.ApplyPaging(pageNumber, pageSize);

        //    var items = await projectedQuery.ToListAsync(cancellationToken);

        //    return new PagedResponse<TResult>(items, pageNumber, pageSize, count, string.Empty);
        //}
    }
}
