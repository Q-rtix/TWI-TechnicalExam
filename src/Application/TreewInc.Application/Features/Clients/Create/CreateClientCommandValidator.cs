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
	}
}