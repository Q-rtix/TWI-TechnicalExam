using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Services;

public class ClientService : IClientService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IDataLoaderContextAccessor _accessor;

	public ClientService(IUnitOfWork unitOfWork, IDataLoaderContextAccessor accessor)
	{
		_unitOfWork = unitOfWork;
		_accessor = accessor;
	}

	public async Task<ILookup<int, Sale>> GetSalesByClientIdsAsync(IEnumerable<int> clientIds, CancellationToken cancellationToken)
	{
		var sales = await _unitOfWork.Repository<Sale>()
			.GetMany([s => clientIds.Contains(s.Id)], asNoTracking: true)
			.ToListAsync(cancellationToken);
		return sales.ToLookup(s => s.ClientId);
	}

	public async Task<IEnumerable<Client>> GetClients()
		=> await _unitOfWork.Repository<Client>().GetMany(asNoTracking: true).ToListAsync();

	public async Task<Client> CreateClientAsync(Client client)
	{
		await _unitOfWork.Repository<Client>().AddOneAsync(client);
		await _unitOfWork.SaveAsync();
		
		return client;
	}
}
