
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
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, BaseResponse<IReadOnlyList<Customer>>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<IReadOnlyList<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            return ResponseHandler.Success(result);
        }
    }
}
