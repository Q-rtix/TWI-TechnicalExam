using Paging.PagedCollections;

namespace TreewInc.Application.Features.Product.Get;

public record GetProductsQueryResponse(PagedList<Core.Domain.Entities.Product> Products);