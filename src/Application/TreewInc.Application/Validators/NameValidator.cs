using FluentValidation;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.Validators;

public class NameValidator : AbstractValidator<Name>
{
	public NameValidator()
	{
		RuleFor(x => x.FirstName)
			.NotEmpty().WithMessage("First name is required")
			.Matches("^[a-zA-Z]*$").WithMessage("First name must contain only letters")
			.MaximumLength(50).WithMessage("First name must not exceed 50 characters");

		RuleFor(x => x.LastName)
			.NotEmpty().WithMessage("Last name is required")
			.Matches("^[a-zA-Z]*$").WithMessage("Last name must contain only letters")
			.MaximumLength(50).WithMessage("Last name must not exceed 50 characters");

		RuleFor(x => x.MiddleName)
			.MaximumLength(50).WithMessage("Middle name must not exceed 50 characters")
			.Matches("^[a-zA-Z]*$").WithMessage("Middle name must contain only letters")
			.When(x => x.MiddleName is not null);
	}
}
