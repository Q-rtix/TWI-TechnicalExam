using Paging.Extensions;
using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.Get;

public class GetClientsQueryHandler : IHandler<GetClientsQuery, GetClientsQueryResponse>
{
	private readonly IRepository<Client> _repository;

	public GetClientsQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Client>();

	public Task<Result<GetClientsQueryResponse>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
	{
		var clients = _repository.GetMany(asNoTracking: true)
			.Paginated(request.PageNumber, request.PageSize);
		return Task.FromResult(ResultFactory.Ok(new GetClientsQueryResponse(clients)));
	}
}