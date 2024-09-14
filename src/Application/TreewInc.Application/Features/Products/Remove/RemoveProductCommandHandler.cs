using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Products.Remove;

public class RemoveProductCommandHandler : IHandler<RemoveProductCommand, RemoveProductCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public RemoveProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Result<RemoveProductCommandResponse>> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
	{
		var repo = _unitOfWork.Repository<Core.Domain.Entities.Product>();
		var product = await repo.GetOneAsync([p => p.Id == request.ProductId], cancellationToken: cancellationToken);
		if (product is null)
			return ResultFactory.Error<RemoveProductCommandResponse>("Product not found", 404);
		
		repo.RemoveOne(product);
		await _unitOfWork.SaveAsync(cancellationToken);
		return ResultFactory.Ok(new RemoveProductCommandResponse(product.Id));
	}
}