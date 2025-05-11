using CleanArchitectureApp.Application.Features.Categories.Queries;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Requests;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Orders.Queries.GetOrderList
{
    public class GetAllOrdersQuery : PagedRequest, IRequest<PagedResponse<OrderDto>>
    {
        public DateTime? OrderDate { get; set; }
        public Guid? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? ProductName { get; set; } 
        public decimal? TotalAmount { get; set; }
    }
}
