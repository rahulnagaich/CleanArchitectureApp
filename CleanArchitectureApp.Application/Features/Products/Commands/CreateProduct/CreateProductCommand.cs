using CleanArchitectureApp.Shared.Responses;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<BaseResponse<Guid>>
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }

}
