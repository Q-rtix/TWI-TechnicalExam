using FluentValidation;

namespace TreewInc.Application.Features.Products.SearchBy;

public class SearchProductByNameQueryValidator : AbstractValidator<SearchProductByNameQuery>
{
	public SearchProductByNameQueryValidator()
	{
		When(x => !string.IsNullOrEmpty(x.Name), () =>
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Product name must not be empty.")
				.Matches("^[a-zA-Z0-9]+(\\s[a-zA-Z0-9]+)*$").WithMessage("Invalid format. Product name can only contain letters and numbers.");
		});
		When(x => !string.IsNullOrEmpty(x.Description), () =>
		{
			RuleFor(x => x.Description)
				.NotEmpty().WithMessage("Product description must not be empty.")
				.Matches("^[a-zA-Z0-9]+(\\s[a-zA-Z0-9]+)*$").WithMessage("Invalid format. Product description can only contain letters and numbers.");
		});
		When(x => x.MinPrice.HasValue, () =>
		{
			RuleFor(x => x.MinPrice)
				.GreaterThanOrEqualTo(0).WithMessage("Minimum price must be greater than or equal to 0.");
		});
		When(x => x.MaxPrice.HasValue, () =>
		{
			RuleFor(x => x.MaxPrice)
				.GreaterThanOrEqualTo(0).WithMessage("Maximum price must be greater than or equal to 0.");
		});
		When(x => x.MinPrice.HasValue && x.MaxPrice.HasValue, () =>
		{
			RuleFor(x => x.MinPrice)
				.LessThanOrEqualTo(x => x.MaxPrice).WithMessage("Minimum price must be less than or equal to maximum price.");
		});
		
		When(x => x.MinStock.HasValue, () =>
		{
			RuleFor(x => x.MinStock)
				.GreaterThanOrEqualTo(0).WithMessage("Minimum stock must be greater than or equal to 0.");
		});
		When(x => x.MaxStock.HasValue, () =>
		{
			RuleFor(x => x.MaxStock)
				.GreaterThanOrEqualTo(0).WithMessage("Maximum stock must be greater than or equal to 0.");
		});
		When(x => x.MinStock.HasValue && x.MaxStock.HasValue, () =>
		{
			RuleFor(x => x.MinStock)
				.LessThanOrEqualTo(x => x.MaxStock).WithMessage("Minimum stock must be less than or equal to maximum stock.");
		});
	}
}
