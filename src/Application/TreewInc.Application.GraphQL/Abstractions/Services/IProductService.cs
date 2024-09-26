using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Abstractions.Services;

public interface IProductService
{
	Task<ILookup<int, Sale>> GetSalesByProductIdsAsync(IEnumerable<int> productIds, CancellationToken cancellationToken);
}
