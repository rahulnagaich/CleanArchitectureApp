
using CleanArchitectureApp.Shared.Responses;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<BaseResponse<Guid>>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
