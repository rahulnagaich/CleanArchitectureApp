using AutoMapper;
using CleanArchitectureApp.Application.Features.Products.Queries.GetProductDetail;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Domain.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetAllCategoriesQuery, BaseResponse<List<CategoryDto>>>
    {
        private readonly ICategoryRepository _repository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<List<CategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            // var categories = await _repository.GetAllAsync(cancellationToken);

            //var categoryDto = _mapper.Map<List<CategoryDto>>(categories);

            //return ResponseHandler.Success(categoryDto);

            var query = _repository.Get();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(p => p.Name.Contains(request.Name));
            }

            if (request.CategoryId.HasValue)
            {
                query = query.Where(p => p.Id == request.CategoryId.Value);
            }

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
                return query
                    .Select(p => new CategoryDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        IsActive = p.IsActive,
                    })
                    .ToList();
            }, cancellationToken);

            return ResponseHandler.Success(result);
        }
    }

}
