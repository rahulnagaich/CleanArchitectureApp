
using CleanArchitectureApp.Application.Features.Categories.Queries;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerList
{
    // Existing code...

    public class GetAllCustomersQueryHandler(ICustomerRepository repository) : IRequestHandler<GetAllCustomersQuery, PagedResponse<CustomerDto>>
    {
        public async Task<PagedResponse<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var query = repository.Get();

            // Filters
            if (request.Id != Guid.Empty)
                query = query.Where(c => c.Id == request.Id);

            if (!string.IsNullOrWhiteSpace(request.FullName))
                query = query.Where(c => c.FullName.Contains(request.FullName));

            if (!string.IsNullOrWhiteSpace(request.Email))
                query = query.Where(c => c.Email.Contains(request.Email));

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var searchTerm = request.SearchTerm.Trim().ToLower();
                query = query.Where(c =>
                    c.FullName.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase) ||
                    (!string.IsNullOrEmpty(c.Email) && c.Email.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)));
            }

            // Projection
            var projectedQuery = query.Select(c => new CustomerDto
            {
                Id = c.Id,
                FullName = c.FullName,
                Email = c.Email
            });

            // Paging
            var totalRecords = await Task.Run(() =>
            {
                return projectedQuery.Count();
            }, cancellationToken);

            var items = await Task.Run(() =>
            {
                return projectedQuery.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            }, cancellationToken);

            var response = new PagedResponse<CustomerDto>(items, totalRecords, request.PageNumber, request.PageSize, "Customers fetched successfully");

            return ResponseHandler.PagedSuccess(response, "Customers fetched successfully");
        }
    }
}
