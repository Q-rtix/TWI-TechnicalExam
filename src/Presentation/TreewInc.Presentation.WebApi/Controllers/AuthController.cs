using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Authentication.Login;

namespace TreewInc.Presentation.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
public class AuthController : ControllerBase
{
	private readonly IMediator _mediator;

	public AuthController(IMediator mediator) => _mediator = mediator;
	
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
