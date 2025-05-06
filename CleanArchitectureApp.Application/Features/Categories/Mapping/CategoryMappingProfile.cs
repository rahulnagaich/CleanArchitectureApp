using AutoMapper;
using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
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
            CreateMap<CategoryDto, Category>();
            CreateMap<CreateCategoryCommand, Category>();
        }
    }
}
