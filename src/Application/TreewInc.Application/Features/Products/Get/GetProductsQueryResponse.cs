using Paging.PagedCollections;

namespace TreewInc.Application.Features.Products.Get;

public record GetProductsQueryResponse(PagedList<Core.Domain.Entities.Product> Products);