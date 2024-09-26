using Microsoft.AspNetCore.Http;
using Results;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Abstractions;
using static Results.ResultFactory;

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
			return Error<RemoveProductCommandResponse>([$"Product not found with Id: {request.ProductId}"], StatusCodes.Status400BadRequest);
		
		repo.RemoveOne(product);
		await _unitOfWork.SaveAsync(cancellationToken);
		return Ok(new RemoveProductCommandResponse(product.Id), StatusCodes.Status200OK);
	}
}