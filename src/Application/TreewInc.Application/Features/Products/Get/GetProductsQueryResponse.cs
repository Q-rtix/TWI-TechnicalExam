using Paging;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Products.Get;

public record GetProductsQueryResponse(PagedList<Product> Products);