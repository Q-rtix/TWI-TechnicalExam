using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.Remove;

public record RemoveProductCommand(int ProductId) : ICommand<RemoveProductCommandResponse>;