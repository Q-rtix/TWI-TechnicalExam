using Microsoft.AspNetCore.Http;
using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Products.Update;

public class UpdateProductCommandHandler : IHandler<UpdateProductCommand, UpdateProductCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateProductCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Result<UpdateProductCommandResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{

		var product = await _unitOfWork.Repository<Core.Domain.Entities.Product>()
			.GetOneAsync([p => p.Id == request.Id], cancellationToken: cancellationToken);
		
		if (product is null)
			return ResultFactory.Error<UpdateProductCommandResponse>("Product not found", StatusCodes.Status400BadRequest);
		
		product.Update(request.Name, request.Description, request.Price, request.Stock);
		await _unitOfWork.SaveAsync(cancellationToken);
		return ResultFactory.Ok(new UpdateProductCommandResponse(product.Id), StatusCodes.Status200OK);
	}
}