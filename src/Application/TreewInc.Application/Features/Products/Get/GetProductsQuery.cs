using TreewInc.Application.Abstractions.Messaging;

namespace TreewInc.Application.Features.Products.Get;

public record GetProductsQuery(int PageNumber, int PageSize) : IPagedQuery<GetProductsQueryResponse>;