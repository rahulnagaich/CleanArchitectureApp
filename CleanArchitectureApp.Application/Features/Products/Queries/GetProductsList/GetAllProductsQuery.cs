using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Products.Queries.GetProductsList
{
    public class GetAllProductsQuery : IRequest<BaseResponse<List<ProductDto>>>
    {
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; }
    }

}
