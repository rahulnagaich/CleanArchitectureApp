using AutoMapper;
using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitectureApp.Application.Features.Categories.Commands.UpdateCategory;
using CleanArchitectureApp.Application.Features.Categories.Queries;
using CleanArchitectureApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Mapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            // CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();

            CreateMap<Product, CategoryProductDto>();

            CreateMap<CreateCategoryCommand, Category>();

            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
