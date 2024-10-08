﻿using Microsoft.AspNetCore.Http;
using Results;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;
using static Results.ResultFactory;

namespace TreewInc.Application.Features.Clients.Create;

public class CreateClientCommandHandler : IHandler<CreateClientCommand, CreateClientCommandResponse>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateClientCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

	public async Task<Result<CreateClientCommandResponse>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
	{
		var repo = _unitOfWork.Repository<Client>();
		var emailCheck = await repo.GetOneAsync([c => c.Email == request.Email], true, cancellationToken);
		if (emailCheck is not null)
			return Error<CreateClientCommandResponse>(["Email already in use"], StatusCodes.Status400BadRequest);
		var client = new Client(request.Name, request.Email, request.Phone, request.Password);
		await _unitOfWork.Repository<Client>()
			.AddOneAsync(client, cancellationToken)
			.ConfigureAwait(false);
		await _unitOfWork.SaveAsync(cancellationToken);
		return Ok(new CreateClientCommandResponse(client.Id), StatusCodes.Status201Created);
	}
}
