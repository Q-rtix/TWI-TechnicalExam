using MediatR;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Product.Create;
using TreewInc.Application.Features.Product.GetByName;

namespace TreewInc.Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProductsController(IMediator mediator) => _mediator = mediator;
	
	[HttpPost]
	[ProducesResponseType<CreateProductCommandResponse>(StatusCodes.Status200OK)]
	[ProducesResponseType<Error>(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<CreateProductCommandResponse>> CreateProduct([FromBody] CreateProductCommand command)
	{
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<CreateProductCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
	
	[HttpGet]
	[ProducesResponseType<GetProductByNameQuery>(StatusCodes.Status200OK)]
	[ProducesResponseType<Error>(StatusCodes.Status400BadRequest)]
	[ProducesResponseType<Error>(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetProductByNameQueryResponse>> GetProductByName([FromQuery] string name)
	{
		var query = new GetProductByNameQuery(name);
		var result = await _mediator.Send(query);
		return result.Match<ActionResult<GetProductByNameQueryResponse>>(
			success: response => Ok(response),
			fail: error => NotFound(error)
		);
	}
}
