using GraphQL.DataLoader;
using GraphQL.Types;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Application.GraphQL.GraphTypes.Types;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.GraphTypes.QueryTypes;

public sealed class ClientQueryType : ObjectGraphType<Client>
{
	public ClientQueryType(IClientService service, IDataLoaderContextAccessor accessor)
	{
		Field(c => c.Id);
		Field(c => c.Name, type: typeof(NameType));
		Field(c => c.Email);
		Field(c => c.Phone, type: typeof(PhoneType));
		Field<ListGraphType<SaleQueryType>, IEnumerable<Sale>>()
			.Name("sales")
			.ResolveAsync(context =>
				accessor.Context.GetOrAddCollectionBatchLoader<int, Sale>("GetSalesByClientId", service.GetSalesByClientIdsAsync)
					.LoadAsync(context.Source.Id)
			);
	}
}