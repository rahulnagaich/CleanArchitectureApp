using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand(Guid id) : IRequest<BaseResponse<bool>>
    {
        public Guid CategoryId { get; set; } = id;
    }
}
