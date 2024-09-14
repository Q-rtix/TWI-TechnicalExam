using FluentValidation;

namespace TreewInc.Application.Features.Clients.GetById;

public class GetClientByIdQueryValidator : AbstractValidator<GetClientByIdQuery>
{
	public GetClientByIdQueryValidator()
	{
		RuleFor(x => x.ClientId)
			.NotEmpty().NotNull().WithMessage("Client Id is required");
	}
}