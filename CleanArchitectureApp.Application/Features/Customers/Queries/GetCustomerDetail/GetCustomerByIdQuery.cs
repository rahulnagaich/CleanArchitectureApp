using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerByIdQuery : IRequest<BaseResponse<Customer>>
    {
        public Guid Id { get; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }

}
