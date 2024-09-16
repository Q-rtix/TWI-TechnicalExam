using TreewInc.Application.Dtos;

namespace TreewInc.Application.Features.Clients.SearchBy;

public record SearchClientsByQueryResponse(IEnumerable<ClientDto> SearchResult);