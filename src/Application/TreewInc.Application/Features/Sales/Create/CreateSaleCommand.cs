using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Sales.Create;

public record CreateSaleCommand(int ClientId, int ProductId, int Quantity) : ICommand<CreateSaleCommandResponse>;