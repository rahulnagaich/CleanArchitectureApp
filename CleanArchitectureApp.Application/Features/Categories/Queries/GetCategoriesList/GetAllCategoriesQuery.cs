using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetAllCategoriesQuery : IRequest<BaseResponse<List<CategoryDto>>>
    {
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; }
    }

}
