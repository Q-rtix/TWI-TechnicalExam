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
[Route("api/[controller]")]
public class ClientsController : ApiBaseController
{
	public ClientsController(IMediator mediator) : base(mediator) { }

	/// <summary>
	/// Creates a new client.
	/// </summary>
	/// <param name="command">The command containing client details.</param>
	/// <returns>A response containing the created client details.</returns>
	[HttpPost]
	[AllowAnonymous]
	[ProducesResponseType(typeof(Ok<CreateClientCommandResponse>), StatusCodes.Status201Created)]
	public async Task<ActionResult<CreateClientCommandResponse>> CreateClient([FromBody] CreateClientCommand command)
	{
		var result = await Mediator.Send(command);
		return HandleResult(result);
	}
	
	/// <summary>
	/// Retrieves a client by their unique identifier.
	/// </summary>
	/// <param name="id">The unique identifier of the client.</param>
	/// <returns>A response containing the client details if found.</returns>
	[HttpGet("{id:int}")]
	[ProducesResponseType(typeof(Ok<GetClientByIdQueryResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<GetClientByIdQueryResponse>> GetClientById([FromRoute] int id)
	{
		var query = new GetClientByIdQuery(id);
		var result = await Mediator.Send(query);
		return HandleResult(result);
	}
	
	/// <summary>
	/// Retrieves a list of clients with optional pagination.
	/// </summary>
	/// <param name="pageNumber">The page number for pagination (optional).</param>
	/// <param name="pageSize">The page size for pagination (optional).</param>
	/// <returns>A response containing the list of clients.</returns>
	[HttpGet]
	[ProducesResponseType(typeof(Ok<GetClientsQueryResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<GetClientsQueryResponse>> GetClients([FromQuery] int? pageNumber, [FromQuery] int? pageSize)
	{
		var query = new GetClientsQuery(pageNumber ?? 1, pageSize ?? 10);
		var result = await Mediator.Send(query);
		return HandleResult(result);
	}
	
	/// <summary>
	/// Updates an existing client.
	/// </summary>
	/// <param name="command">The command containing updated client details.</param>
	/// <returns>A response containing the updated client details.</returns>
	[HttpPut]
	[ProducesResponseType(typeof(Ok<UpdateClientCommandResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<UpdateClientCommandResponse>> UpdateClient([FromBody] UpdateClientCommand command)
	{
		var result = await Mediator.Send(command);
		return HandleResult(result);
	}
	
	/// <summary>
	/// Removes a client by their unique identifier.
	/// </summary>
	/// <param name="id">The unique identifier of the client to be removed.</param>
	/// <returns>A response indicating the result of the remove operation.</returns>
	[HttpDelete("{id:int}")]
	[ProducesResponseType(typeof(Ok<RemoveClientCommandResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<RemoveClientCommandResponse>> RemoveClient(int id)
	{
		var command = new RemoveClientCommand(id);
		var result = await Mediator.Send(command);
		return HandleResult(result);
	}
	
	
	/// <summary>
	/// Searches for clients based on the provided criteria.
	/// </summary>
	/// <param name="name">The name of the client (optional).</param>
	/// <param name="email">The email of the client (optional).</param>
	/// <param name="phone">The phone number of the client (optional).</param>
	/// <returns>A response containing the search results.</returns>
	[HttpGet("search")]
	[ProducesResponseType(typeof(Ok<SearchClientsByQueryResponse>), StatusCodes.Status200OK)]
	public async Task<ActionResult<SearchClientsByQueryResponse>> SearchBy(string? name, string? email, string? phone)
	{
		var query = new SearchClientsByQuery(name, email, phone);
		var result = await Mediator.Send(query);
		return HandleResult(result);
	}
}
