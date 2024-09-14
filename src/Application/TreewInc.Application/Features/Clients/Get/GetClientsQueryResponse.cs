using Paging.PagedCollections;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.Get;

public record GetClientsQueryResponse(PagedList<Client> Clients);