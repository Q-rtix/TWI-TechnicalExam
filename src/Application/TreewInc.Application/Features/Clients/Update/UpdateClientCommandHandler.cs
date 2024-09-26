using Microsoft.AspNetCore.Http;
using Results;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.Update;

public class UpdateClientCommandHandler : IHandler<UpdateClientCommand, UpdateClientCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public UpdateClientCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Result<UpdateClientCommandResponse>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
	{
		var repo = _unitOfWork.Repository<Client>();
		var client = await repo.GetOneAsync([c => c.Id == request.Id], cancellationToken: cancellationToken)
			.ConfigureAwait(false);
		if (client is null)
			return ResultFactory.Error<UpdateClientCommandResponse>([$"Client not found with Id: {request.Id}."], StatusCodes.Status400BadRequest);
		
		client.Update(request.Name, request.Email, request.Phone);
		repo.UpdateOne(client);
		await _unitOfWork.SaveAsync(cancellationToken);
		return ResultFactory.Ok(new UpdateClientCommandResponse(client.Id), StatusCodes.Status200OK);
	}
}