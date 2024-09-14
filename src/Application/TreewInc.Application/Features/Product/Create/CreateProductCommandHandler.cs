using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.Create;

public class CreateProductCommandHandler : IHandler<CreateProductCommand, CreateProductCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Result<CreateProductCommandResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var product = new Core.Domain.Entities.Product(request.Name, request.Description ?? string.Empty, request.Price, request.Stock);
		await _unitOfWork.Repository<Core.Domain.Entities.Product>()
			.AddOneAsync(product, cancellationToken)
			.ConfigureAwait(false);
		await _unitOfWork.SaveAsync(cancellationToken);
		return ResultFactory.Ok(new CreateProductCommandResponse(product.Id));
	}
}