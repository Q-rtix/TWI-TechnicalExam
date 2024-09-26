using Microsoft.EntityFrameworkCore;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Services;

public class SaleService : ISaleService
{
	private readonly IUnitOfWork _unitOfWork;

	public SaleService(IUnitOfWork unitOfWork)
		=> _unitOfWork = unitOfWork;

	public async Task<IDictionary<int, Client>> GetClientsByIdAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
		=> await _unitOfWork.Repository<Client>()
			.GetMany([c => ids.Contains(c.Id)], asNoTracking: true)
			.ToDictionaryAsync(c => c.Id, cancellationToken);
}
