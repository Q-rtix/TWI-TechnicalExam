using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.SearchBy;

public record SearchClientsByQueryResponse(IEnumerable<Client> SearchResult);