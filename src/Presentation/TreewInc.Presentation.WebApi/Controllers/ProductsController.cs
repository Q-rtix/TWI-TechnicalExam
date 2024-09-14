using MediatR;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Products.Create;
using TreewInc.Application.Features.Products.Get;
using TreewInc.Application.Features.Products.GetById;
using TreewInc.Application.Features.Products.GetByName;
using TreewInc.Application.Features.Products.Remove;
using TreewInc.Application.Features.Products.Update;

namespace TreewInc.Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
public class ProductsController : ControllerBase
{
	private readonly IMediator _mediator;

	public ProductsController(IMediator mediator) => _mediator = mediator;
	
	[HttpPost]
	[ProducesResponseType(typeof(CreateProductCommandResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<CreateProductCommandResponse>> CreateProduct([FromBody] CreateProductCommand command)
	{
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<CreateProductCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
	
	[HttpGet]
	[ProducesResponseType(typeof(GetProductByNameQuery), StatusCodes.Status200OK)]
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
	[ProducesResponseType(typeof(GetProductByIdQuery), StatusCodes.Status200OK)]
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
	[ProducesResponseType(typeof(GetProductsQueryResponse), StatusCodes.Status200OK)]
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
	[ProducesResponseType(typeof(UpdateProductCommandResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<UpdateProductCommandResponse>> UpdateProduct([FromBody] UpdateProductCommand command)
	{
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<UpdateProductCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}

	[HttpDelete]
	[ProducesResponseType(typeof(RemoveProductCommandResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<RemoveProductCommandResponse>> RemoveProduct([FromRoute] int productId)
	{
		var command = new RemoveProductCommand(productId);
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<RemoveProductCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
}
