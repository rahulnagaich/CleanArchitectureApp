
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

namespace CleanArchitectureApp.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, BaseResponse<Customer>>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerByIdQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<Customer>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id,cancellationToken);

            if (customer == null)
                return ResponseHandler.NotFound<Customer>("Customer not found.");

            return ResponseHandler.Success(customer);
        }
    }

}
