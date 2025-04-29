using AutoMapper;
using CleanArchitectureApp.Application.Features.Orders.Queries;
using CleanArchitectureApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Orders.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
          CreateMap<Order, OrderDto>()
         .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<OrderProduct, OrderItemDto>();
        }
    }
}
