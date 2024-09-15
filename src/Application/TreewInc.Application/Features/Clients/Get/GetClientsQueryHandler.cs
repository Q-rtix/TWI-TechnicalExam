using Paging.Extensions;
using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Application.Dtos.Mappers;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.Get;

public class GetClientsQueryHandler : IHandler<GetClientsQuery, GetClientsQueryResponse>
{
	private readonly IRepository<Client> _repository;

	public GetClientsQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Client>();

	public Task<Result<GetClientsQueryResponse>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
	{
		var clients = _repository.GetMany(asNoTracking: true)
			.Select(c => c.MapToClientDto())
			.Paginated(request.PageNumber, request.PageSize);
		return Task.FromResult(ResultFactory.Ok(new GetClientsQueryResponse(clients)));
	}
}