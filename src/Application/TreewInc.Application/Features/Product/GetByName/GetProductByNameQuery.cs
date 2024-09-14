using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.GetByName;

public record GetProductByNameQuery(string ProductName) : IQuery<GetProductByNameQueryResponse>;