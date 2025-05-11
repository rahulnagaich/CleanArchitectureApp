using AutoMapper;

using CleanArchitectureApp.Application.Features.Categories.Queries;
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

namespace CleanArchitectureApp.Application.Features.Products.Queries.GetProductsList
{
    public class GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper) : IRequestHandler<GetAllProductsQuery, BaseResponse<List<ProductDto>>>
    {
        public async Task<BaseResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync(cancellationToken);

            if (products == null || !products.Any())
            {
                return ResponseHandler.NotFound<List<ProductDto>>("No products found.");
            }

            var productDto = mapper.Map<List<ProductDto>>(products);

            return ResponseHandler.Success(productDto);
        }
    }
}
