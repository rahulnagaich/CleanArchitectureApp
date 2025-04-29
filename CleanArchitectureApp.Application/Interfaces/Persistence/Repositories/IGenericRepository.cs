using AutoMapper;
using CleanArchitectureApp.Domain.Responses;
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
        IQueryable<T> Get();

        //Task<T> GetByIdAsync(int id);

        Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        void Remove(T entity);

        Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        //Task<bool> ExistsAsync(CancellationToken cancellationToken = default);

        Task<List<TResult>> GetProjectedListAsync<TResult>(Expression<Func<T, bool>> filter, IConfigurationProvider configurationProvider, CancellationToken cancellationToken = default);

        Task<TResult?> GetProjectedByIdAsync<TResult>(Expression<Func<T, bool>> filter, IConfigurationProvider configurationProvider, CancellationToken cancellationToken = default);

        Task<PagedResponse<T>> ToPagedListAsync(int pageNumber, int pageSize);
    }
}
