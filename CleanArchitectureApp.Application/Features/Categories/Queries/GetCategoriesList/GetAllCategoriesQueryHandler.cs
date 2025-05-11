using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Shared.Responses;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoriesQuery, BaseResponse<List<CategoryDto>>>
    {
        //private readonly ICategoryRepository _repository = categoryRepository;
        //private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            // var categories = await _repository.GetAllAsync(cancellationToken);

            //var categoryDto = _mapper.Map<List<CategoryDto>>(categories);

            //return ResponseHandler.Success(categoryDto);

            var query = categoryRepository.Get();

            // Filters (optional, domain-specific)
            if (request.CategoryId.HasValue)
                query = query.Where(c => c.Id == request.CategoryId);

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(c => c.Name.Contains(request.Name));

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
                query = query.Where(c =>
                    c.Name.Contains(request.SearchTerm) ||
                    (c.Description != null && c.Description.Contains(request.SearchTerm)));

            // Apply Sorting & Paging using extensions
            //query = query
            //    .ApplySorting(request.OrderBy, request.SortDirection)
            //    .ApplyPaging(request.PageNumber, request.PageSize);


            //.OrderBy(p => p.Name)
            //.Skip((pageNumber - 1) * pageSize)
            //.Take(pageSize)

            // Projection using Select (manual mapping to DTO)
            //var result =  query
            //    .Select(p => new CategoryDto
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        IsActive = p.IsActive,
            //    })
            //    .ToList();

            //return ResponseHandler.Success(result);

            // Execute manually inside Task.Run to make it "async"
            var result = await Task.Run(() =>
            {
                return query.OrderByDescending(p => p.CreatedDate)
                    .Select(p => new CategoryDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        IsActive = p.IsActive,
                    })
                    .ToList();
            }, cancellationToken);

            return ResponseHandler.Success(result);
        }
    }
}
