using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.GetById;

public record GetProductByIdQuery(int ProducId) : IQuery<GetProductByIdQueryResponse>;