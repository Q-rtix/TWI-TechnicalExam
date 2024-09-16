using Microsoft.AspNetCore.Http;
using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Products.GetById;

public class GetProductByIdQueryHandler : IHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
{
	private readonly IRepository<Core.Domain.Entities.Product> _repository;

	public GetProductByIdQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Core.Domain.Entities.Product>();
	
	public async Task<Result<GetProductByIdQueryResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
	{
		var product = await _repository.GetOneAsync([p => p.Id == request.ProductId], true, cancellationToken)
			.ConfigureAwait(false);
		return product is null
			? ResultFactory.Error<GetProductByIdQueryResponse>([$"Product not found with Id: {request.ProductId}"], StatusCodes.Status404NotFound)
			: ResultFactory.Ok(new GetProductByIdQueryResponse(product), StatusCodes.Status200OK);
	}
}