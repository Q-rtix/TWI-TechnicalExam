using Results;
using System.Linq.Expressions;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.GetByName;

public class GetProductByNameQueryHandler : IHandler<GetProductByNameQuery, GetProductByNameQueryResponse>
{
	private readonly IRepository<Core.Domain.Entities.Product> _repository;

	public GetProductByNameQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Core.Domain.Entities.Product>();

	public async Task<Result<GetProductByNameQueryResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
	{
		Expression<Func<Core.Domain.Entities.Product, bool>> filter = p => p.Name.Equals(request.ProductName, StringComparison.CurrentCultureIgnoreCase);
		var product = await _repository.GetOneAsync([filter], true, cancellationToken);
		return product is null 
			? ResultFactory.Error<GetProductByNameQueryResponse>([$"Product not found with name: {request.ProductName}"], 404) 
			: ResultFactory.Ok(product.MapToGetProductByNameQueryResponse());
	}
}
