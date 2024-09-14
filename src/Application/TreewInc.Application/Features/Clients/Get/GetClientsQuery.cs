using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Clients.Get;

public record GetClientsQuery(int PageNumber, int PageSize) : IPagedQuery<GetClientsQueryResponse>;