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

namespace CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetAllCustomersQuery : PagedRequest, IRequest<PagedResponse<CustomerDto>>
    {
        public Guid? Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
