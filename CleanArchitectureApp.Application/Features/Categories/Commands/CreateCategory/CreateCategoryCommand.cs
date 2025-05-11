
using CleanArchitectureApp.Shared.Responses;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<BaseResponse<Guid>>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
