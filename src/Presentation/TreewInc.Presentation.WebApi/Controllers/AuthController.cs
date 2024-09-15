using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Authentication.Login;

namespace TreewInc.Presentation.WebApi.Controllers;

/// <summary>
/// Controller responsible for handling authentication-related actions.
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
public class AuthController : ControllerBase
{
	private readonly IMediator _mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="AuthController"/> class.
	/// </summary>
	/// <param name="mediator">The mediator instance for sending commands and queries.</param>
	public AuthController(IMediator mediator) => _mediator = mediator;
	
	/// <summary>
	/// Authenticates a user and returns a JWT token if successful.
	/// </summary>
	/// <param name="query">The login query containing user credentials.</param>
	/// <returns>A response containing the JWT token if authentication is successful.</returns>
	[HttpPost("login")]
	[AllowAnonymous]
	[ProducesResponseType(typeof(LoginQueryResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<LoginQueryResponse>> Login([FromBody] LoginQuery query)
	{
		var result = await _mediator.Send(query);
		return result.Match<ActionResult<LoginQueryResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
}
