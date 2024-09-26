using Microsoft.EntityFrameworkCore;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Services;

public class ProductService : IProductService
{
	private readonly IUnitOfWork _unitOfWork;

	public ProductService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
	
	public async Task<ILookup<int, Sale>> GetSalesByProductIdsAsync(IEnumerable<int> productIds, CancellationToken cancellationToken)
	{
		var sales = await _unitOfWork.Repository<Sale>()
			.GetMany([s => productIds.Contains(s.Id)], asNoTracking: true)
			.ToListAsync(cancellationToken);

		return sales.ToLookup(s => s.ProductId);
	}
}
