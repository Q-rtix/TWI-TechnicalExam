using FluentValidation;

namespace TreewInc.Application.Features.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotNull().NotEmpty().WithMessage("The name is required")
			.Matches("^[a-zA-Z0-9]+(\\s[a-zA-Z0-9]+)*$").WithMessage("Invalid format. The name can only contain letters and numbers.")
			.MaximumLength(150).WithMessage("The name must not exceed 150 characters.");
		RuleFor(x => x.Description)
			.MaximumLength(512).WithMessage("The description must not exceed 512 characters.");
		RuleFor(x => x.Price)
			.GreaterThan(0).WithMessage("The price must be greater than 0.")
			.PrecisionScale(18, 2, false).WithMessage("The price must have a maximum of 18 digits and 2 decimals.");
		RuleFor(x => x.Stock)
			.NotNull().WithMessage("The stock is required.")
			.GreaterThanOrEqualTo(0).WithMessage("The stock must be greater than or equal to 0.");
		
		When(x => x.Description is not null, () =>
		{
			RuleFor(x => x.Description)
				.Matches("^[a-zA-Z0-9]+(\\s[a-zA-Z0-9]+)*$").WithMessage("Invalid format. The description can only contain letters and numbers and must not be empty.");
		});
	}
}