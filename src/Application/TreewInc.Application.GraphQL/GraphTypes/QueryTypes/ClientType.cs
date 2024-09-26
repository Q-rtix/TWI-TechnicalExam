using GraphQL.DataLoader;
using GraphQL.Types;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.GraphTypes.QueryTypes;

public sealed class ClientType : ObjectGraphType<Client>
{
	public ClientType(IClientService service, IDataLoaderContextAccessor accessor)
	{
		Field(c => c.Id);
		Field(c => c.Name);
		Field(c => c.Email);
		Field(c => c.Phone);
		Field<ListGraphType<SaleType>, IEnumerable<Sale>>()
			.Name("sales")
			.ResolveAsync(context =>
				accessor.Context.GetOrAddCollectionBatchLoader<int, Sale>("GetSalesByClientId", service.GetSalesByClientIdsAsync)
					.LoadAsync(context.Source.Id)
			);
	}
}