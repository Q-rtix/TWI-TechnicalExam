using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.GetById;

public class GetClientByIdQueryHandler : IHandler<GetClientByIdQuery, GetClientByIdQueryResponse>
{
	private readonly IRepository<Client> _repository;
	
	public GetClientByIdQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Client>();

	public async Task<Result<GetClientByIdQueryResponse>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
	{
		var client = await _repository.GetOneAsync([c => c.Id == request.ClientId], true, cancellationToken)
			.ConfigureAwait(false);
		return client is null 
			? ResultFactory.Error<GetClientByIdQueryResponse>($"Client not found with Id: {request.ClientId}") 
			: ResultFactory.Ok(new GetClientByIdQueryResponse(client));
	}
}