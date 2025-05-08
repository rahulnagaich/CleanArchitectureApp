using AutoMapper;
using CleanArchitectureApp.Application.Features.Products.Queries;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, BaseResponse<CategoryDto>>
    {
        private readonly ICategoryRepository _repository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);
           
            if (category == null)
            {
                return ResponseHandler.NotFound<CategoryDto>("Category not found.");
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return ResponseHandler.Success(categoryDto);
        }
    }

}
