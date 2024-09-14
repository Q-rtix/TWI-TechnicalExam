using Microsoft.EntityFrameworkCore;
using Results;
using System.Linq.Expressions;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Core.Domain.Entities;
using static Results.ResultFactory;

namespace TreewInc.Application.Features.Products.SearchBy;

public class SearchProductByNameQueryHandler : IHandler<SearchProductByNameQuery, SearchProductByNameQueryResponse>
{
	private readonly IRepository<Core.Domain.Entities.Product> _repository;

	public SearchProductByNameQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Core.Domain.Entities.Product>();

	public async Task<Result<SearchProductByNameQueryResponse>> Handle(SearchProductByNameQuery request, CancellationToken cancellationToken)
	{
		var filters = GetFilters(request);
		var product = await _repository.GetMany(filters: filters, asNoTracking: true)
			.ToListAsync(cancellationToken)
			.ConfigureAwait(false);
		return Ok(new SearchProductByNameQueryResponse(product));
	}
	
	private Expression<Func<Product, bool>>[] GetFilters(SearchProductByNameQuery request)
	{
		var filters = new List<Expression<Func<Product, bool>>>();
		if (!string.IsNullOrWhiteSpace(request.Name))
			filters.Add(p => p.Name.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase));
		if(!string.IsNullOrEmpty(request.Description))
			filters.Add(p => p.Description.Contains(request.Description, StringComparison.InvariantCultureIgnoreCase));
		if (request.MinPrice.HasValue)
			filters.Add(p => p.Price >= request.MinPrice);
		if (request.MaxPrice.HasValue)
			filters.Add(p => p.Price <= request.MaxPrice);
		if (request.MinStock.HasValue)
			filters.Add(p => p.Stock >= request.MinStock);
		if (request.MaxStock.HasValue)
			filters.Add(p => p.Stock <= request.MaxStock);
		return filters.ToArray();
	}
}
