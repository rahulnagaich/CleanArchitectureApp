using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(e => e)
             .MustAsync(CategoryNameAndDateUnique)
             .WithMessage("An category with the same name already exists.");
        }

        private async Task<bool> CategoryNameAndDateUnique(CreateCategoryCommand e, CancellationToken token)
        {
            return !(await _categoryRepository.IsCategoryName(e.Name, token));
        }
    }
}
