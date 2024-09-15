using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using TreewInc.Application.Features.Clients.Create;
using TreewInc.Application.Features.Clients.Get;
using TreewInc.Application.Features.Clients.GetById;
using TreewInc.Application.Features.Clients.Remove;
using TreewInc.Application.Features.Clients.SearchBy;
using TreewInc.Application.Features.Clients.Update;

namespace TreewInc.Presentation.WebApi.Controllers;

/// <summary>
/// Controller responsible for handling client-related actions.
/// </summary>
[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
public class ClientsController : ControllerBase
{
	private readonly IMediator _mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="ClientsController"/> class.
	/// </summary>
	/// <param name="mediator">The mediator instance for sending commands and queries.</param>
	public ClientsController(IMediator mediator) => _mediator = mediator;

	/// <summary>
	/// Creates a new client.
	/// </summary>
	/// <param name="command">The command containing client details.</param>
	/// <returns>A response containing the created client details.</returns>
	[HttpPost]
	[AllowAnonymous]
	[ProducesResponseType(typeof(CreateClientCommandResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<CreateClientCommandResponse>> CreateClient([FromBody] CreateClientCommand command)
	{
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<CreateClientCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
	
	/// <summary>
	/// Retrieves a client by their unique identifier.
	/// </summary>
	/// <param name="id">The unique identifier of the client.</param>
	/// <returns>A response containing the client details if found.</returns>
	[HttpGet("{id:int}")]
	[ProducesResponseType(typeof(GetClientByIdQueryResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<GetClientByIdQueryResponse>> GetClientById([FromRoute] int id)
	{
		var query = new GetClientByIdQuery(id);
		var result = await _mediator.Send(query);
		return result.Match<ActionResult<GetClientByIdQueryResponse>>(
			success: response => Ok(response),
			fail: error => NotFound(error)
		);
	}
	
	/// <summary>
	/// Retrieves a list of clients with optional pagination.
	/// </summary>
	/// <param name="pageNumber">The page number for pagination (optional).</param>
	/// <param name="pageSize">The page size for pagination (optional).</param>
	/// <returns>A response containing the list of clients.</returns>
	[HttpGet]
	[ProducesResponseType(typeof(GetClientsQueryResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<GetClientsQueryResponse>> GetClients([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
	{
		var query = new GetClientsQuery(pageNumber ?? 1, pageSize ?? 10);
		var result = await _mediator.Send(query);
		return result.Match<ActionResult<GetClientsQueryResponse>>(
			success: response => Ok(response),
			fail: error => NotFound(error)
		);
	}
	
	/// <summary>
	/// Updates an existing client.
	/// </summary>
	/// <param name="command">The command containing updated client details.</param>
	/// <returns>A response containing the updated client details.</returns>
	[HttpPut]
	[ProducesResponseType(typeof(UpdateClientCommandResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<UpdateClientCommandResponse>> UpdateClient([FromBody] UpdateClientCommand command)
	{
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<UpdateClientCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
	
	/// <summary>
	/// Removes a client by their unique identifier.
	/// </summary>
	/// <param name="id">The unique identifier of the client to be removed.</param>
	/// <returns>A response indicating the result of the remove operation.</returns>
	[HttpDelete("{id:int}")]
	[ProducesResponseType(typeof(RemoveClientCommandResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<RemoveClientCommandResponse>> RemoveClient(int id)
	{
		var command = new RemoveClientCommand(id);
		var result = await _mediator.Send(command);
		return result.Match<ActionResult<RemoveClientCommandResponse>>(
			success: response => Ok(response),
			fail: error => BadRequest(error)
		);
	}
	
	
	/// <summary>
	/// Searches for clients based on the provided criteria.
	/// </summary>
	/// <param name="name">The name of the client (optional).</param>
	/// <param name="email">The email of the client (optional).</param>
	/// <param name="phone">The phone number of the client (optional).</param>
	/// <returns>A response containing the search results.</returns>
	[HttpGet("search")]
	[ProducesResponseType(typeof(SearchClientsByQueryResponse), StatusCodes.Status200OK)]
	public async Task<ActionResult<SearchClientsByQueryResponse>> SearchBy(string? name, string? email, string? phone)
	{
		var query = new SearchClientsByQuery(name, email, phone);
		var result = await _mediator.Send(query);
		return result.Match<ActionResult<SearchClientsByQueryResponse>>(
			success: response => Ok(response),
			fail: error => NotFound(error)
		);
	}
}
