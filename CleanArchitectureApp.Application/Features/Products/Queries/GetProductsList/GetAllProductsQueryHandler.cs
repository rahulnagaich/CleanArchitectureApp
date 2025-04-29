using AutoMapper;

using CleanArchitectureApp.Application.Features.Categories.Queries;
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

namespace CleanArchitectureApp.Application.Features.Products.Queries.GetProductsList
{
    public class GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper) : IRequestHandler<GetAllProductsQuery, BaseResponse<List<ProductDto>>>
    {
        private readonly IProductRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(cancellationToken);
            var productDto = _mapper.Map<List<ProductDto>>(products);
            return ResponseHandler.Success(productDto);

        }
    }

}
