using FluentValidation;

namespace TreewInc.Application.Features.Sales.Create;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
	public CreateSaleCommandValidator()
	{
		RuleFor(x => x.ClientId).NotEmpty().GreaterThan(0);
		RuleFor(x => x.ProductId).NotEmpty().GreaterThan(0);
		RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
	}
}