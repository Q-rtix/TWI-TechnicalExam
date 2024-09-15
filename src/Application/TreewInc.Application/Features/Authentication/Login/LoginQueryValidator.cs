using FluentValidation;

namespace TreewInc.Application.Features.Authentication.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
	public LoginQueryValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty().EmailAddress();
		RuleFor(x => x.Password)
			.Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$")
			.WithMessage("Password must contain at least 8 characters, one uppercase letter, one lowercase letter and one number.");
	}
}