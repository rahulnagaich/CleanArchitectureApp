using AutoMapper;
using CleanArchitectureApp.Application.Features.Products.Queries;
using CleanArchitectureApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Products.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, static opt => opt.MapFrom(static src => src.Category == null? string.Empty: src.Category.Name));
        }
    }
}
