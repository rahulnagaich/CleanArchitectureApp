using CleanArchitectureApp.Domain.Responses;
using MediatR;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<BaseResponse<Guid>>
    {
        public string Name { get; set; } = string.Empty;
    }
}
