using AutoMapper;
using CleanArchitectureApp.Application.Features.Products.Commands.CreateProduct;
using CleanArchitectureApp.Application.Features.Products.Queries;
using CleanArchitectureApp.Domain.Entities;

namespace CleanArchitectureApp.Application.Features.Products.Mapping
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, static opt => opt.MapFrom(static src => src.Category == null? string.Empty: src.Category.Name));

            CreateMap<CreateProductCommand, Product>();
        }
    }
}
