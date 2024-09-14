using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Products.SearchBy;

public record SearchProductByNameQueryResponse(IEnumerable<Product> SearchResults);
