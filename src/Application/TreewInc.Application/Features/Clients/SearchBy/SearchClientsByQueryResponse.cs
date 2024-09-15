using TreewInc.Application.Dtos;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.SearchBy;

public record SearchClientsByQueryResponse(IEnumerable<ClientDto> SearchResult);