using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Products.Remove;

public record RemoveProductCommand(int ProductId) : ICommand<RemoveProductCommandResponse>;