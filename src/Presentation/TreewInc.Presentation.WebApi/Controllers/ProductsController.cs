using MediatR;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Product.Create;
using TreewInc.Application.Features.Product.Get;
using TreewInc.Application.Features.Product.GetById;
using TreewInc.Application.Features.Product.GetByName;
using TreewInc.Application.Features.Product.Update;

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
	
	[HttpGet("{id:int}")]
	[ProducesResponseType<GetProductByIdQuery>(StatusCodes.Status200OK)]
	[ProducesResponseType<Error>(StatusCodes.Status400BadRequest)]
	[ProducesResponseType<Error>(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<GetProductByIdQueryResponse>> GetProductById([FromRoute] int id)
	{
		var query = new GetProductByIdQuery(id);
		var result = await _mediator.Send(query);
		return result.Match<ActionResult<GetProductByIdQueryResponse>>(
			success: response => Ok(response),
			fail: error => NotFound(error)
		);
	}
	
	[HttpGet("page")]
	[ProducesResponseType<GetProductsQueryResponse>(StatusCodes.Status200OK)]
	[ProducesResponseType<Error>(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetProductsQueryResponse>> GetProducts([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
	{
		var query = new GetProductsQuery(pageNumber ?? 1, pageSize ?? 10);
		var result = await _mediator.Send(query);
		return result.Match<ActionResult<GetProductsQueryResponse>>(
			success: response => Ok(response),
			fail: error => NotFound(error)
		);
	}
	
	[HttpPut]
	[ProducesResponseType<UpdateProductCommandResponse>(StatusCodes.Status200OK)]
	[ProducesResponseType<Error>(StatusCodes.Status400BadRequest)]
	[ProducesResponseType<Error>(StatusCodes.Status404NotFound)]
	public async Task<ActionResult<UpdateProductCommandResponse>> UpdateProduct([FromBody] UpdateProductCommand command)
	{
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<UpdateProductCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
}
