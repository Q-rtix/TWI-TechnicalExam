using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Clients.SearchBy;

public record SearchClientsByQuery(string? Email = null, string? Name = null, string? Phone = null) : IQuery<SearchClientsByQueryResponse>;