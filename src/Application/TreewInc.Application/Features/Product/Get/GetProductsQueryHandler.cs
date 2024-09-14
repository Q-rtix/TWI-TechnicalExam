using Paging.Extensions;
using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.Get;

public class GetProductsQueryHandler : IHandler<GetProductsQuery, GetProductsQueryResponse>
{
	private readonly IRepository<Core.Domain.Entities.Product> _repository;

	public GetProductsQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Core.Domain.Entities.Product>();

	public Task<Result<GetProductsQueryResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
	{
		var products = _repository.GetMany(asNoTracking: true)
			.Paginated(request.PageNumber, request.PageSize);
		return Task.FromResult(ResultFactory.Ok(new GetProductsQueryResponse(products)));
	}
}