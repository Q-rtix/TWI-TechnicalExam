using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Clients.GetById;

public record GetClientByIdQuery(int ClientId) : IQuery<GetClientByIdQueryResponse>;