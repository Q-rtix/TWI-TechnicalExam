using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Results;
using System.Linq.Expressions;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Messaging;
using TreewInc.Application.Dtos.Mappers;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Features.Clients.SearchBy;

public class SearchClientsByQueryHandler : IHandler<SearchClientsByQuery, SearchClientsByQueryResponse>
{
	private readonly IRepository<Client> _repository;

	public SearchClientsByQueryHandler(IUnitOfWork unitOfWork) => _repository = unitOfWork.Repository<Client>();

	public async Task<Result<SearchClientsByQueryResponse>> Handle(SearchClientsByQuery request, CancellationToken cancellationToken)
	{
		var filters = GetFilters(request);
		var clients = await _repository.GetMany(filters: filters, asNoTracking: true)
			.Select(c => c.MapToClientDto())
			.ToListAsync(cancellationToken: cancellationToken)
			.ConfigureAwait(false);
		return ResultFactory.Ok(new SearchClientsByQueryResponse(clients), StatusCodes.Status200OK);
	}
	
	private static Expression<Func<Client, bool>>[] GetFilters(SearchClientsByQuery request)
	{
		var filters = new List<Expression<Func<Client, bool>>>();
		if (!string.IsNullOrEmpty(request.Email))
		{
			filters.Add(x => x.Email.Contains(request.Email, StringComparison.InvariantCultureIgnoreCase));
		}
		if (!string.IsNullOrEmpty(request.Name))
		{
			filters.Add(x => x.Name.FirstName.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase) 
				|| x.Name.LastName.Contains(request.Name, StringComparison.InvariantCultureIgnoreCase));
		}
		if (!string.IsNullOrEmpty(request.Phone))
		{
			filters.Add(x => x.Phone.Number.Contains(request.Phone, StringComparison.InvariantCultureIgnoreCase));
		}
		return filters.ToArray();
	}
}