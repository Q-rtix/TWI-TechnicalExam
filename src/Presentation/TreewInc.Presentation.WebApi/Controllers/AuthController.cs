using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Authentication.Login;

namespace TreewInc.Presentation.WebApi.Controllers;

/// <summary>
/// Controller responsible for handling authentication-related actions.
/// </summary>
[Route("api/[controller]")]
public class AuthController : ApiBaseController
{
	public AuthController(IMediator mediator) : base(mediator) { }
	
	/// <summary>
	/// Authenticates a user and returns a JWT token if successful.
	/// </summary>
	/// <param name="query">The login query containing user credentials.</param>
	/// <returns>A response containing the JWT token if authentication is successful.</returns>
	[HttpPost("login")]
	[AllowAnonymous]
	[ProducesResponseType(typeof(Ok<LoginQueryResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<LoginQueryResponse>> Login([FromBody] LoginQuery query)
	{
		var result = await Mediator.Send(query);
		return HandleResult(result);
	}
}
