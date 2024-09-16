using MediatR;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Products.Create;
using TreewInc.Application.Features.Products.Get;
using TreewInc.Application.Features.Products.GetById;
using TreewInc.Application.Features.Products.Remove;
using TreewInc.Application.Features.Products.SearchBy;
using TreewInc.Application.Features.Products.Update;

namespace TreewInc.Presentation.WebApi.Controllers;

/// <summary>
/// Controller for managing products.
/// </summary>
[Route("api/[controller]")]
public class ProductsController : ApiBaseController
{
	public ProductsController(IMediator mediator) : base(mediator) { }

	/// <summary>
	/// Creates a new product.
	/// </summary>
	/// <param name="command">The command containing product details.</param>
	/// <returns>A response containing the created product details.</returns>
	[HttpPost]
	[ProducesResponseType(typeof(Ok<CreateProductCommandResponse>), StatusCodes.Status201Created)]
	public async Task<ActionResult<CreateProductCommandResponse>> CreateProduct([FromBody] CreateProductCommand command)
	{
		var result = await Mediator.Send(command);
		return HandleResult(result);
	}
	
	/// <summary>
	/// Searches for products based on the provided criteria.
	/// </summary>
	/// <param name="name">The name of the product (optional).</param>
	/// <param name="description">The description of the product (optional).</param>
	/// <param name="minPrice">The minimum price of the product (optional).</param>
	/// <param name="maxPrice">The maximum price of the product (optional).</param>
	/// <param name="minStock">The minimum stock of the product (optional).</param>
	/// <param name="maxStock">The maximum stock of the product (optional).</param>
	/// <returns>A response containing the search results.</returns>
	[HttpGet("search")]
	[ProducesResponseType(typeof(Ok<SearchProductByNameQuery>), StatusCodes.Status200OK)]
	public async Task<ActionResult<SearchProductByNameQueryResponse>> SearchBy([FromQuery] string? name,
		[FromQuery] string? description, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice,
		[FromQuery] int? minStock, [FromQuery] int? maxStock)
	{
		var query = new SearchProductByNameQuery(name, description, minPrice, maxPrice, minStock, maxStock);
		var result = await Mediator.Send(query);
		return HandleResult(result);
	}
	
	/// <summary>
	/// Retrieves a product by its unique identifier.
	/// </summary>
	/// <param name="id">The unique identifier of the product.</param>
	/// <returns>A response containing the product details if found.</returns>
	[HttpGet("{id:int}")]
	[ProducesResponseType(typeof(Ok<GetProductByIdQuery>), StatusCodes.Status200OK)]
	public async Task<ActionResult<GetProductByIdQueryResponse>> GetProductById([FromRoute] int id)
	{
		var query = new GetProductByIdQuery(id);
		var result = await Mediator.Send(query);
		return HandleResult(result);
	}
	
	/// <summary>
	/// Retrieves a list of products with optional pagination.
	/// </summary>
	/// <param name="pageNumber">The page number for pagination (optional).</param>
	/// <param name="pageSize">The page size for pagination (optional).</param>
	/// <returns>A response containing the list of products.</returns>
	[HttpGet]
	[ProducesResponseType(typeof(Ok<GetProductsQueryResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<GetProductsQueryResponse>> GetProducts([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
	{
		var query = new GetProductsQuery(pageNumber ?? 1, pageSize ?? 10);
		var result = await Mediator.Send(query);
		return HandleResult(result);
	}
	
	/// <summary>
	/// Updates an existing product.
	/// </summary>
	/// <param name="command">The command containing updated product details.</param>
	/// <returns>A response containing the updated product details.</returns>
	[HttpPut]
	[ProducesResponseType(typeof(Ok<UpdateProductCommandResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<UpdateProductCommandResponse>> UpdateProduct([FromBody] UpdateProductCommand command)
	{
		var result = await Mediator.Send(command);
		return HandleResult(result);
	}

	/// <summary>
	/// Removes a product by its unique identifier.
	/// </summary>
	/// <param name="productId">The unique identifier of the product to be removed.</param>
	/// <returns>A response indicating the result of the remove operation.</returns>
	[HttpDelete("{productId:int}")]
	[ProducesResponseType(typeof(Ok<RemoveProductCommandResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<RemoveProductCommandResponse>> RemoveProduct([FromRoute] int productId)
	{
		var command = new RemoveProductCommand(productId);
		var result = await Mediator.Send(command);
		return HandleResult(result);
	}
}
