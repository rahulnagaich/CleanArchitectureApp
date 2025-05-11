using AutoMapper;
using CleanArchitectureApp.Application.Features.Customers.Commands.CreateCustomer;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Features.Customers.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CreateCustomerCommand, Customer>();
        }
    }
}
