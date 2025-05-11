
using AutoMapper;
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

namespace CleanArchitectureApp.Application.Features.Orders.Queries.GetOrderDetail
{
    public class GetOrderByIdQueryHandler(IOrderRepository repository, IMapper mapper) : IRequestHandler<GetOrderByIdQuery, BaseResponse<OrderDto>>
    {
        public async Task<BaseResponse<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var orderDto = await repository.GetProjectedByIdAsync<OrderDto>(
                filter: x => x.Id == request.Id,
                configurationProvider: mapper.ConfigurationProvider,
                cancellationToken: cancellationToken);

            if (orderDto is null)
                return ResponseHandler.NotFound<OrderDto>("Order not found.");

            return ResponseHandler.Success(orderDto);
        }
    }
}
