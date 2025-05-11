using AutoMapper;
using CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesListWithProducts
{
    public class GetAllCategoriesWithProductsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetAllCategoriesWithProductsQuery, PagedResponse<CategoryDto>>
    {
        public async Task<PagedResponse<CategoryDto>> Handle(GetAllCategoriesWithProductsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Category, bool>>? filter = null;

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                filter = c => c.Name.Contains(request.Name);
            }

            var result = await  categoryRepository.GetProjectedPagedListAsync<CategoryDto>(
                                configurationProvider: mapper.ConfigurationProvider,
                                pageNumber: request.PageNumber,
                                pageSize: request.PageSize,
                                orderBy: request.OrderBy,
                                sortDirection: request.SortDirection,
                                //filter: x => string.IsNullOrEmpty(request.Name) || x.Name.Contains(request.Name),
                                filter,
                                cancellationToken: cancellationToken);

            return ResponseHandler.PagedSuccess(result, "Categories fetched successfully");
        }
    }
}
