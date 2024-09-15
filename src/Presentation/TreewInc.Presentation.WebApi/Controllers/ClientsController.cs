using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Results.ResultTypes;
using System.Diagnostics.CodeAnalysis;
using TreewInc.Application.Features.Clients.Create;
using TreewInc.Application.Features.Clients.Get;
using TreewInc.Application.Features.Clients.GetById;
using TreewInc.Application.Features.Clients.Remove;
using TreewInc.Application.Features.Clients.SearchBy;
using TreewInc.Application.Features.Clients.Update;

namespace TreewInc.Presentation.WebApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
[ProducesResponseType(typeof(Error), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
public class ClientsController : ControllerBase
{
	private readonly IMediator _mediator;

	public ClientsController(IMediator mediator) => _mediator = mediator;

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
