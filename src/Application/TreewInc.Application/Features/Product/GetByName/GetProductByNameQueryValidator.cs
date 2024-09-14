using FluentValidation;

namespace TreewInc.Application.Features.Product.GetByName;

public class GetProductByNameQueryValidator : AbstractValidator<GetProductByNameQuery>
{
	public GetProductByNameQueryValidator()
	{
		RuleFor(x => x.ProductName)
			.NotNull().NotEmpty().WithMessage("Product name is required")
			.Matches("^[a-zA-Z0-9]+(\\s[a-zA-Z0-9]+)*$").WithMessage("Invalid format. Product name can only contain letters and numbers.");
	}
}
