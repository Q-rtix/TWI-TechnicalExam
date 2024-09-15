using FluentValidation;
using TreewInc.Application.Validators;

namespace TreewInc.Application.Features.Clients.Create;

public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
	public CreateClientCommandValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty().WithMessage("Email is required")
			.EmailAddress().WithMessage("Invalid email format.");
		RuleFor(x => x.Name)
			.SetValidator(new NameValidator());
		RuleFor(x => x.Phone)
			.SetValidator(new PhoneNumberValidator());
		RuleFor(x => x.Password)
			.NotEmpty().NotNull().WithMessage("Password is required")
			.Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$")
			.WithMessage("Password must contain at least 8 characters, one uppercase letter, one lowercase letter and one number.");
	}
}