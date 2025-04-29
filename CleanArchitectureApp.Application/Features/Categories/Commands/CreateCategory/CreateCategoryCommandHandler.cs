using CleanArchitectureApp.Domain.Entities;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using System.Net;
using CleanArchitectureApp.Domain.Responses;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<CreateCategoryCommand, BaseResponse<Guid>>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCategoryCommandValidator(_categoryRepository);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return ResponseHandler.BadRequest<Guid>("Validation failed", errors);
            }

            var category = _mapper.Map<Category>(request);

            await _categoryRepository.CreateAsync(category, cancellationToken);

            return ResponseHandler.Created(category.Id,"Category created successfully");
        }
    }
}
