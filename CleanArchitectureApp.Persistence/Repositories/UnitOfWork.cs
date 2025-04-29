using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Persistence.Repositories
{
    public class UnitOfWork(IDatabaseService databaseService) : IUnitOfWork
    {
        private readonly IDatabaseService _databaseService = databaseService;

        private readonly Dictionary<Type, object> _repositories = new();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _databaseService.SaveChangesAsync(cancellationToken);
        }

        int IUnitOfWork.Save()
        {
            return _databaseService.Save();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                var repo = new GenericRepository<T>(_databaseService);

                _repositories[type] = repo;
            }

            return (IGenericRepository<T>)_repositories[type];
        }
    }
}
