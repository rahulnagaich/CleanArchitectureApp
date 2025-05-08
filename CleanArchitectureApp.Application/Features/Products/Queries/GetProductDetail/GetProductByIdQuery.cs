using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductByIdQuery : IRequest<BaseResponse<ProductDto>>
    {
        public required Guid Id { get; set; }
    }
}
