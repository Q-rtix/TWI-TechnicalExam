using FluentValidation;

namespace TreewInc.Application.Features.Product.Remove;

public class RemoveProductCommandValidator : AbstractValidator<RemoveProductCommand>
{
	public RemoveProductCommandValidator()
	{
		RuleFor(x => x.ProductId).NotEmpty().NotNull().WithMessage("Product Id is required");
	}
}