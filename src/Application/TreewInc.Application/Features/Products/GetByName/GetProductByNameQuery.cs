using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Products.GetByName;

public record GetProductByNameQuery(string ProductName) : IQuery<GetProductByNameQueryResponse>;