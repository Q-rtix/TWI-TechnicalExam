using Microsoft.AspNetCore.Http;
using Results;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Abstractions.Auth;
using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Domain.Helpers;

namespace TreewInc.Application.Features.Authentication.Login;

public class LoginQueryHandler : IHandler<LoginQuery, LoginQueryResponse>
{
	private readonly IRepository<Client> _repository;
	private readonly IJwtHandler _jwtHandler;
	
	public LoginQueryHandler(IUnitOfWork unitOfWork, IJwtHandler jwtHandler)
	{
		_jwtHandler = jwtHandler;
		_repository = unitOfWork.Repository<Client>();
	}

	public async Task<Result<LoginQueryResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
	{
		var client = await _repository.GetOneAsync([c => c.Email == request.Email], true, cancellationToken)
			.ConfigureAwait(false);
		if (client is null)
			return ResultFactory.Error<LoginQueryResponse>("Does not exist a client with the provided email.", StatusCodes.Status400BadRequest);
		
		if (!PassHelper.VerifyPassword(request.Password, client.Password))
			return ResultFactory.Error<LoginQueryResponse>(["Invalid password."], StatusCodes.Status400BadRequest);

		var token = _jwtHandler.Generate(client.Email);
		return ResultFactory.Ok(new LoginQueryResponse(token), StatusCodes.Status200OK);
	}
}