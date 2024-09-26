using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Abstractions.Services;

public interface ISaleService
{

	Task<IDictionary<int, Client>> GetClientsByIdAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
}
