using FluentValidation;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.Validators;

public class PhoneNumberValidator : AbstractValidator<PhoneNumber>
{
	public PhoneNumberValidator()
	{
		RuleFor(x => x.Number)
			.NotEmpty().WithMessage("Phone number is required")
			.Matches("^[0-9]*$").WithMessage("Phone number must contain only numbers")
			.MaximumLength(11).WithMessage("Phone number must not exceed 11 characters");

		RuleFor(x => x.CountryCode)
			.NotEmpty().WithMessage("Country code is required")
			.Matches("^[0-9]*$").WithMessage("Country code must contain only numbers")
			.MaximumLength(3).WithMessage("Country code must not exceed 3 characters");
	}
}
