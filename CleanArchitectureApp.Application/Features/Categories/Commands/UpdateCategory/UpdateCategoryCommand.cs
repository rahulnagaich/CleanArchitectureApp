using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<BaseResponse<bool>>
    {
        public Guid CategoryId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
