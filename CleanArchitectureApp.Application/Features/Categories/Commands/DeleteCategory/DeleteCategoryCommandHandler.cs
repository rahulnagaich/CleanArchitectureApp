using AutoMapper;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitectureApp.Application.Features.Categories.Queries;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using CleanArchitectureApp.Domain.Entities;
using CleanArchitectureApp.Shared.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand, BaseResponse<bool>>
    {
        public async Task<BaseResponse<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

            if (categoryToDelete == null)
            {
                return ResponseHandler.NotFound<bool>("Category not found.");
            }

            await categoryRepository.DeleteAsync(categoryToDelete, cancellationToken);

            return ResponseHandler.Success(true, "Category deleted successfully.");
        }
    }
}
