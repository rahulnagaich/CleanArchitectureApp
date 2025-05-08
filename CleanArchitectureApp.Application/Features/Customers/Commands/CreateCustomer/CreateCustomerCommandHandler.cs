
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

namespace CleanArchitectureApp.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseResponse<Guid>>
    {
        private readonly ICustomerRepository _repository;

        public CreateCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(Guid.NewGuid(), request.Name, request.Email);
            
            await _repository.CreateAsync(customer, cancellationToken);

            return ResponseHandler.Created(customer.Id, "Customer created.");
        }
    }

}
