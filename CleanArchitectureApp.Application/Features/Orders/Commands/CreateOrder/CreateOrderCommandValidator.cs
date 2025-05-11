using FluentValidation;

namespace CleanArchitectureApp.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required.");

            RuleFor(x => x.Items)
                .NotEmpty().WithMessage("At least one order item is required.");

            RuleForEach(x => x.Items).SetValidator(new OrderItemDtoValidator());
        }
    }

    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("ProductId is required.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("UnitPrice must be greater than 0.");
        }
    }
}
