using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Product.Get;

public record GetProductsQuery(int PageNumber, int PageSize) : IPagedQuery<GetProductsQueryResponse>;