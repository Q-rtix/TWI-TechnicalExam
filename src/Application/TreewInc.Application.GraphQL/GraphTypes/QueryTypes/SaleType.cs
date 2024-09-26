using GraphQL.DataLoader;
using GraphQL.Types;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.GraphTypes.QueryTypes;

public sealed class SaleType : ObjectGraphType<Sale>
{
	public SaleType(ISaleService service, IDataLoaderContextAccessor accessor)
	{
		Field(s => s.Id);
		Field(s => s.Date);
		Field(s => s.Quantity);
		Field(s => s.TotalPrice);
		Field<ClientType, Client>()
			.Name("client")
			.ResolveAsync(context => 
				accessor.Context.GetOrAddBatchLoader<int, Client>("GetClientsById", service.GetClientsByIdAsync)
					.LoadAsync(context.Source.ClientId)
			);
	}
}
