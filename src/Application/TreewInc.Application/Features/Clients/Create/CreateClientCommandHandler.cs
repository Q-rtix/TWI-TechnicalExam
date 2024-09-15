using Results;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Application.Helpers;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.Create;

public class CreateClientCommandHandler : IHandler<CreateClientCommand, CreateClientCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateClientCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Result<CreateClientCommandResponse>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
	{
		var client = new Client(request.Name, request.Email, request.Phone, PassHelper.HashPassword(request.Password));
		await _unitOfWork.Repository<Client>()
			.AddOneAsync(client, cancellationToken)
			.ConfigureAwait(false);
		await _unitOfWork.SaveAsync(cancellationToken);
		return ResultFactory.Ok(new CreateClientCommandResponse(client.Id));
	}
}
