using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.Update;

public record UpdateProductCommand(int Id, string Name, string? Description, decimal Price, int Stock) : ICommand<UpdateProductCommandResponse>;