using AutoMapper;

using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper) : IRequestHandler<GetProductByIdQuery, BaseResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            //var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            //if (product == null)
            //{
            //    return ResponseHandler.NotFound<ProductDto>("Product not found.");
            //}

            var productDto = await _productRepository.GetProjectedByIdAsync<ProductDto>(p=> p.Id == request.Id, _mapper.ConfigurationProvider, cancellationToken);

            if (productDto == null)
            {
                return ResponseHandler.NotFound<ProductDto>("Product not found.");
            }

            //var productDto = _mapper.Map<ProductDto>(product);

            return ResponseHandler.Success(productDto);
        }
    }
}
