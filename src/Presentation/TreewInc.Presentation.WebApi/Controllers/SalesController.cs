using MediatR;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Sales.Create;

namespace TreewInc.Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
public class SalesController : ControllerBase
{
	private readonly IMediator _mediator;

	public SalesController(IMediator mediator) => _mediator = mediator;

	[HttpPost]
	[ProducesResponseType(typeof(CreateSaleCommandResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<CreateSaleCommandResponse>> CreateSale([FromBody] CreateSaleCommand command)
	{
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<CreateSaleCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
}
