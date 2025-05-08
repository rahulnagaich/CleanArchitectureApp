using AutoMapper;

using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
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

namespace CleanArchitectureApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository repository, ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<CreateProductCommand, BaseResponse<Guid>>
    {
        private readonly IProductRepository _repository = repository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator(_categoryRepository);

            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return ResponseHandler.BadRequest<Guid>("Validation failed", errors);
            }

            var product = _mapper.Map<Product>(request);

            await _repository.CreateAsync(product, cancellationToken);

            return ResponseHandler.Created(product.Id, "Product created successfully");
        }
    }
}
