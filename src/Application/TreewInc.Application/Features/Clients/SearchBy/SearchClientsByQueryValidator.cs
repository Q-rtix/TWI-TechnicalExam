using FluentValidation;

namespace TreewInc.Application.Features.Clients.SearchBy;

public class SearchClientsByQueryValidator : AbstractValidator<SearchClientsByQuery>
{
	public SearchClientsByQueryValidator()
	{
		When(x => string.IsNullOrEmpty(x.Email), () =>
		{
			RuleFor(x => x.Email)
				.Matches("^[a-zA-Z0-9_.+-]*$").WithMessage("Email is not valid")
				.MaximumLength(150).WithMessage("Email must be less than 150 characters");
		});
		When(x => string.IsNullOrEmpty(x.Name), () =>
		{
			RuleFor(x => x.Name)
				.Matches("^[a-zA-Z]*$").WithMessage("Name must contain only letters")
				.MaximumLength(153).WithMessage("Name must be less than 150 characters");
		});
		When(x => string.IsNullOrEmpty(x.Phone), () =>
		{
			RuleFor(x => x.Phone)
				.Matches("^[0-9]*$").WithMessage("Phone number must contain only numbers")
				.MaximumLength(15).WithMessage("Phone must be less than 15 characters");
		});
	}
}