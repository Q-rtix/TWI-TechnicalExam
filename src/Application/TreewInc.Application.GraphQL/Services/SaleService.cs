using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Services;

public class SaleService : ISaleService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IDataLoaderContextAccessor _accessor;

	public SaleService(IUnitOfWork unitOfWork, IDataLoaderContextAccessor accessor)
	{
		_unitOfWork = unitOfWork;
		_accessor = accessor;
	}

	public async Task<IDictionary<int, Client>> GetClientsByIdAsync(IEnumerable<int> clientIds, CancellationToken cancellationToken)
		=> await _unitOfWork.Repository<Client>()
			.GetMany([c => clientIds.Contains(c.Id)], asNoTracking: true)
			.ToDictionaryAsync(c => c.Id, cancellationToken);

	public async Task<IDictionary<int, Product>> GetProductsByIdAsync(IEnumerable<int> productIds, CancellationToken cancellationToken)
	=> await _unitOfWork.Repository<Product>()
		.GetMany([p => productIds.Contains(p.Id)], asNoTracking: true)
		.ToDictionaryAsync(p => p.Id, cancellationToken);
}
