using AutoMapper;
using CleanArchitectureApp.Application.Features.Orders.Commands.CreateOrder;
using CleanArchitectureApp.Application.Features.Orders.Queries;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Features.Orders.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
          CreateMap<Order, OrderDto>()
         .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<CreateOrderCommand, Order>();
        }
    }
}
