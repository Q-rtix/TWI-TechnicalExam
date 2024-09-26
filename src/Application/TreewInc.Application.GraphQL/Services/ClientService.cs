using Microsoft.EntityFrameworkCore;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Services;

public class ClientService : IClientService
{
	private readonly IUnitOfWork _unitOfWork;

	public ClientService(IUnitOfWork unitOfWork)
		=> _unitOfWork = unitOfWork;

	public async Task<ILookup<int, Sale>> GetSalesByClientIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
	{
		var sales = await _unitOfWork.Repository<Sale>()
			.GetMany([s => ids.Contains(s.Id)], asNoTracking: true)
			.ToListAsync(cancellationToken);
		return sales.ToLookup(s => s.Id);
	}
}
