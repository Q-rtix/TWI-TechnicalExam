using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Sales.Create;

namespace TreewInc.Presentation.WebApi.Controllers;

/// <summary>
/// Controller for handling sales-related operations.
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
[ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
public class SalesController : ControllerBase
{
	private readonly IMediator _mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="SalesController"/> class.
	/// </summary>
	/// <param name="mediator">The mediator instance for handling requests.</param>
	public SalesController(IMediator mediator) => _mediator = mediator;

	/// <summary>
	/// Creates a new sale.
	/// </summary>
	/// <param name="command">The command containing sale details.</param>
	/// <returns>A response containing the created sale details.</returns>
	[HttpPost]
	[ProducesResponseType(typeof(CreateSaleCommandResponse), StatusCodes.Status201Created)]
	public async Task<ActionResult<CreateSaleCommandResponse>> CreateSale([FromBody] CreateSaleCommand command)
	{
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<CreateSaleCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
}
