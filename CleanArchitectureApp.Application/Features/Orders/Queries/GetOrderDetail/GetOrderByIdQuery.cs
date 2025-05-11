using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Orders.Queries.GetOrderDetail
{
    public class GetOrderByIdQuery(Guid id) : IRequest<BaseResponse<OrderDto>>
    {
        public Guid Id { get; } = id;
    }
}
