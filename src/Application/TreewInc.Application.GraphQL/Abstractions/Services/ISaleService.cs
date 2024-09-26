using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Abstractions.Services;

public interface ISaleService
{

	Task<IDictionary<int, Client>> GetClientsByIdAsync(IEnumerable<int> clientIds, CancellationToken cancellationToken);
	Task<IDictionary<int, Product>> GetProductsByIdAsync(IEnumerable<int> productIds, CancellationToken cancellationToken);
}
