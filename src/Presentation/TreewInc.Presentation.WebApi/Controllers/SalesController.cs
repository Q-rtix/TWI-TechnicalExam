using MediatR;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Sales.Create;

namespace TreewInc.Presentation.WebApi.Controllers;

/// <summary>
/// Controller for handling sales-related operations.
/// </summary>
[Route("api/[controller]")]
public class SalesController : ApiBaseController
{
	public SalesController(IMediator mediator) : base(mediator) { }

	/// <summary>
	/// Creates a new sale.
	/// </summary>
	/// <param name="command">The command containing sale details.</param>
	/// <returns>A response containing the created sale details.</returns>
	[HttpPost]
	[ProducesResponseType(typeof(Ok<CreateSaleCommandResponse>), StatusCodes.Status201Created)]
	public async Task<ActionResult<CreateSaleCommandResponse>> CreateSale([FromBody] CreateSaleCommand command)
	{
		var result = await Mediator.Send(command);
		 return HandleResult(result);
	}
}
