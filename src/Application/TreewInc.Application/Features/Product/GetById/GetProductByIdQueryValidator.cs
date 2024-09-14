using FluentValidation;

namespace TreewInc.Application.Features.Product.GetById;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
	public GetProductByIdQueryValidator()
	{
		RuleFor(x => x.ProducId).NotEmpty().NotNull().WithMessage("Product Id is required");
	}
}