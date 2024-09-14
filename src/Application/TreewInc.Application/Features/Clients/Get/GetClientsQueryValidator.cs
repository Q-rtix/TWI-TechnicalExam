using FluentValidation;

namespace TreewInc.Application.Features.Clients.Get;

public class GetClientsQueryValidator : AbstractValidator<GetClientsQuery>
{
	public GetClientsQueryValidator()
	{
		RuleFor(x => x.PageNumber)
			.GreaterThan(0).WithMessage("Page number must be greater than 0.");
		RuleFor(x => x.PageSize)
			.GreaterThan(0).WithMessage("Page size must be greater than 0.");
	}
}