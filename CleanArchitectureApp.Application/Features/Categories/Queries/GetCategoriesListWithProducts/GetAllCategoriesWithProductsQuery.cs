using CleanArchitectureApp.Shared.Requests;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
    public class GetAllCategoriesWithProductsQuery : PagedRequest, IRequest<PagedResponse<CategoryDto>>
    {
        public string? Name { get; set; }
    }
}
