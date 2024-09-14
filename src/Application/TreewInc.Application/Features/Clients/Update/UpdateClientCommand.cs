using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.Features.Clients.Update;

public record UpdateClientCommand(int Id, Name Name, string Email, PhoneNumber Phone) : IQuery<UpdateClientCommandResponse>;