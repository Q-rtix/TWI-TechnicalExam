using FluentValidation;
using TreewInc.Application.Validators;

namespace TreewInc.Application.Features.Clients.Update;

public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
	public UpdateClientCommandValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty().WithMessage("Email is required")
			.EmailAddress().WithMessage("Invalid email format.");
		RuleFor(x => x.Name)
			.NotNull()
			.SetValidator(new NameValidator());
		RuleFor(x => x.Phone)
			.NotNull()
			.SetValidator(new PhoneNumberValidator());
	}
}