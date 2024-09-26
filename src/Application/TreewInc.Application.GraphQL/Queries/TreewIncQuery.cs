using GraphQL.DataLoader;
using GraphQL.Types;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Application.GraphQL.GraphTypes.QueryTypes;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Queries;

public sealed class TreewIncQuery : ObjectGraphType
{
	public TreewIncQuery(IClientService service, IDataLoaderContextAccessor accessor)
	{
		Field<StringGraphType>(
			name: "name",
			resolve: _ => "TreewInc"
		);
		
		Field<ListGraphType<ClientQueryType>, IEnumerable<Client>>()
			.Name("clients")
			.ResolveAsync(_ => accessor.Context.GetOrAddLoader("GetClients", service.GetClients)
				.LoadAsync());
	}
}
