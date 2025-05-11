
using AutoMapper;
using CleanArchitectureApp.Application.Features.Categories.Queries;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Orders.Queries.GetOrderList
{
    public class GetAllOrdersQueryHandler(IOrderRepository repository, IMapper mapper) : IRequestHandler<GetAllOrdersQuery, PagedResponse<OrderDto>>
    {
        public async Task<PagedResponse<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Order, bool>>? filter = null;

            if (request.OrderDate.HasValue ||
                request.CustomerId.HasValue ||
                !string.IsNullOrWhiteSpace(request.CustomerName) ||
                !string.IsNullOrWhiteSpace(request.ProductName) ||
                request.TotalAmount.HasValue)
            {
                filter = o =>
                    (!request.OrderDate.HasValue || o.OrderDate.Date == request.OrderDate.Value.Date) &&
                    (!request.CustomerId.HasValue || o.CustomerId == request.CustomerId.Value) &&
                    (string.IsNullOrEmpty(request.CustomerName) || o.Customer != null && o.Customer.FullName.Contains(request.CustomerName)) &&
                    (string.IsNullOrEmpty(request.ProductName) || o.OrderProducts.Any(op => op.Product != null && op.Product.Name.Contains(request.ProductName))) &&
                    (!request.TotalAmount.HasValue || o.OrderProducts.Sum(i => i.Quantity * i.UnitPrice) == request.TotalAmount.Value);
            }

            var result = await repository.GetProjectedPagedListAsync<OrderDto>(
                configurationProvider: mapper.ConfigurationProvider,
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                orderBy: request.OrderBy,
                sortDirection: request.SortDirection,
                filter: filter,
                cancellationToken: cancellationToken
            );

            return ResponseHandler.PagedSuccess(result, "Orders fetched successfully");
        }
    }
}
