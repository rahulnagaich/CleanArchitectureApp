using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetAllCustomersQuery : IRequest<BaseResponse<IReadOnlyList<Customer>>> { }

}
