using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Queries.GetCategoryDetail
{
    public class GetCategoryByIdQuery(Guid id) : IRequest<BaseResponse<CategoryDto>>
    {
        public Guid Id { get; set; } = id;
    }

}
