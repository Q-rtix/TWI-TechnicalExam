using FluentValidation;

namespace TreewInc.Application.Features.Product.Get;

public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
{
	public GetProductsQueryValidator()
	{
		RuleFor(x => x.PageNumber)
			.NotEmpty().NotNull().WithMessage("Page number is required.")
			.GreaterThan(0).WithMessage("Page number must be greater than 0.");
		RuleFor(x => x.PageSize)
			.NotEmpty().NotNull().WithMessage("Page size is required.")
			.GreaterThan(0).WithMessage("Page size must be greater than 0.");
	}
}