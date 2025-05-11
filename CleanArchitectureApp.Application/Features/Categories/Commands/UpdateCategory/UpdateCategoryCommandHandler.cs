using AutoMapper;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<UpdateCategoryCommand, BaseResponse<bool>>
    {
        public async Task<BaseResponse<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var categoryToUpdate = await categoryRepository.GetByIdAsync(request.CategoryId,cancellationToken);

            if (categoryToUpdate == null)
            {
                return ResponseHandler.NotFound<bool>("Category not found.");
            }

            mapper.Map(request, categoryToUpdate, typeof(UpdateCategoryCommand), typeof(Category));

            await categoryRepository.UpdateAsync(categoryToUpdate, cancellationToken);

            return ResponseHandler.Success(true, "Category updated successfully.");
        }
    }
}
