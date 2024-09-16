using Microsoft.AspNetCore.Http;
using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.Remove;

public class RemoveClientCommandHandler : IHandler<RemoveClientCommand, RemoveClientCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public RemoveClientCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Result<RemoveClientCommandResponse>> Handle(RemoveClientCommand request, CancellationToken cancellationToken)
	{
		var repo = _unitOfWork.Repository<Client>();
		var client = await repo.GetOneAsync([c => c.Id == request.ClientId], cancellationToken: cancellationToken)
			.ConfigureAwait(false);
		if (client is null)
			return ResultFactory.Error<RemoveClientCommandResponse>([$"Client not found with Id: {request.ClientId}."], StatusCodes.Status400BadRequest);
		
		repo.RemoveOne(client);
		await _unitOfWork.SaveAsync(cancellationToken);
		return ResultFactory.Ok(new RemoveClientCommandResponse(client.Id), StatusCodes.Status200OK);
	}
}