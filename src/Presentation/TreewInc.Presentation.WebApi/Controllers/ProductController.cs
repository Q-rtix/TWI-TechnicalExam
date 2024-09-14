using MediatR;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Product.Create;

namespace TreewInc.Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProductController(IMediator mediator) => _mediator = mediator;
	
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
}
