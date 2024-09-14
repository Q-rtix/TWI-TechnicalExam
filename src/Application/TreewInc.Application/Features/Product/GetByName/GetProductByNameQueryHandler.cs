using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.GetByName;

public class GetProductByNameQueryHandler : IHandler<GetProductByNameQuery, GetProductByNameQueryResponse>
{
	private readonly IRepository<Core.Domain.Entities.Product> _repository;

	public GetProductByNameQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Core.Domain.Entities.Product>();

	public async Task<Result<GetProductByNameQueryResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
	{
		var product = await _repository.GetOneAsync([p => p.Name.Equals(request.ProductName, StringComparison.CurrentCultureIgnoreCase)], 
				true, 
				cancellationToken)
			.ConfigureAwait(false);
		return product is null 
			? ResultFactory.Error<GetProductByNameQueryResponse>([$"Product not found with name: {request.ProductName}"], 404) 
			: ResultFactory.Ok(new GetProductByNameQueryResponse(product));
	}
}
