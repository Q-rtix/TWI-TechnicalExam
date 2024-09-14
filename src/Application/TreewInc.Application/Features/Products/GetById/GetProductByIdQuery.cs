using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Products.GetById;

public record GetProductByIdQuery(int ProductId) : IQuery<GetProductByIdQueryResponse>;