using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Persistence.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, string? orderBy, string sortDirection)
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.PropertyOrField(parameter, orderBy);
            var lambda = Expression.Lambda(property, parameter);

            string methodName = sortDirection.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? "OrderByDescending" : "OrderBy";
            var resultExpression = Expression.Call(
                typeof(Queryable),
                methodName,
                [typeof(T), property.Type],
                query.Expression,
                Expression.Quote(lambda));

            return query.Provider.CreateQuery<T>(resultExpression);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
