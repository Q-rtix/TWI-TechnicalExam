using Paging;
using TreewInc.Application.Dtos;

namespace TreewInc.Application.Features.Clients.Get;

public record GetClientsQueryResponse(PagedList<ClientDto> Clients);