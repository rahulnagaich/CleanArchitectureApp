using AutoMapper;
using CleanArchitectureApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Interfaces.Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        void Remove(T entity);

        Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        IQueryable<T> Get();

        Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAllReadOnlyListAsync(CancellationToken cancellationToken = default);

        Task<TResult?> GetProjectedByIdAsync<TResult>(Expression<Func<T, bool>> filter,
                    IConfigurationProvider configurationProvider, CancellationToken cancellationToken = default);

        Task<PagedResponse<T>> GetPagedListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        Task<PagedResponse<T>> GetPagedListAsync(
                    int pageNumber, int pageSize,
                    string? orderBy = null, string sortDirection = "ASC",
                    Expression<Func<T, bool>>? filter = null,
                    CancellationToken cancellationToken = default);

        Task<PagedResponse<T>> GetProjectedPagedListAsync<TResult>(int pageNumber, int pageSize,
                    IConfigurationProvider configurationProvider, CancellationToken cancellationToken = default);

        //Task<PagedResponse<T>> GetProjectedPagedListAsync<TResult>(
        //            IConfigurationProvider configurationProvider,
        //            int pageNumber, int pageSize,
        //            string? orderBy = null, string sortDirection = "ASC",
        //            Expression<Func<T, bool>>? filter = null,
        //            CancellationToken cancellationToken = default);

        Task<PagedResponse<TResult>> GetProjectedPagedListAsync<TResult>(
            IConfigurationProvider configurationProvider,
            int pageNumber, int pageSize,
            string? orderBy = null, string sortDirection = "ASC",
            Expression<Func<T, bool>>? filter = null,
            CancellationToken cancellationToken = default);
    }
}
