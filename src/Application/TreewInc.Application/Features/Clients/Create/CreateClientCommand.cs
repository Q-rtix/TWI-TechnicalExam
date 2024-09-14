using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.Features.Clients.Create;

public record CreateClientCommand(Name Name, string Email, PhoneNumber Phone) : ICommand<CreateClientCommandResponse>;