using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Clients.Remove;

public record RemoveClientCommand(int ClientId) : IQuery<RemoveClientCommandResponse>;