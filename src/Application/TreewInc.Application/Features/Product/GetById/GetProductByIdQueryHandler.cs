using Results;
using System.Linq.Expressions;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.GetById;

public class GetProductByIdQueryHandler : IHandler<GetProductByIdQuery, GetProductByIdQueryResponse>
{
	private readonly IRepository<Core.Domain.Entities.Product> _repository;

	public GetProductByIdQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Core.Domain.Entities.Product>();
	
	public async Task<Result<GetProductByIdQueryResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
	{
		Expression<Func<Core.Domain.Entities.Product, bool>> filter = p => p.Id == request.ProducId;
		var product = await _repository.GetOneAsync([filter], true, cancellationToken)
			.ConfigureAwait(false);
		return product is null
			? ResultFactory.Error<GetProductByIdQueryResponse>($"Product not found with Id: {request.ProducId}", 404)
			: ResultFactory.Ok(new GetProductByIdQueryResponse(product));
	}
}