using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.")
                .MustAsync(BeUniqueName).WithMessage("Category name must be unique.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> BeUniqueName(UpdateCategoryCommand command, string name, CancellationToken cancellationToken)
        {
            var existingCategory = await _categoryRepository.GetByNameAsync(name, cancellationToken);

            // If category exists and it's not the same ID being updated, it's a conflict
            if (existingCategory != null && existingCategory.Id != command.CategoryId)
                return false;

            return true;
        }
    }
}
