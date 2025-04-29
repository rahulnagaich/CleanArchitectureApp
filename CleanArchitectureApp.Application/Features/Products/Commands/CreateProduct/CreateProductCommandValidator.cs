using CleanArchitectureApp.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitectureApp.Application.Interfaces.Persistence.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateProductCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(e => e)
             .MustAsync(CategoryNameExistsAsync)
             .WithMessage("Category not exists.");
        }

        private async Task<bool> CategoryNameExistsAsync(CreateProductCommand e, CancellationToken token = default)
        {
            return (await _categoryRepository.ExistsAsync(p=> p.Id == e.CategoryId, token));
        }
    }
}
