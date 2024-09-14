using FluentValidation;

namespace TreewInc.Application.Features.Clients.Remove;

public class RemoveClientCommandValidator : AbstractValidator<RemoveClientCommand>
{
	public RemoveClientCommandValidator()
	{
		RuleFor(x => x.ClientId)
			.NotEmpty().NotNull().WithMessage("Client Id is required")
			.GreaterThan(0).WithMessage("Client Id must be greater than 0");
	}
}