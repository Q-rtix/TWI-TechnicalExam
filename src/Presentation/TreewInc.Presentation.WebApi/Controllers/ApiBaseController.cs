using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results;
using Results.ResultTypes;

namespace TreewInc.Presentation.WebApi.Controllers;

[ApiController]
[Authorize]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
[ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
public abstract class ApiBaseController : ControllerBase
{
	protected IMediator Mediator;

	protected ApiBaseController(IMediator mediator)
	{
		Mediator = mediator;
	}

	[NonAction]
	public ActionResult<T> HandleResult<T>(Result<T> result)
		=> StatusCode(result.StatusCode!.Value, result.IsSucceed
			? result.Ok()
			: result.Error());
}
