using GraphQL.DataLoader;
using GraphQL.Types;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Application.GraphQL.GraphTypes.QueryTypes;
using TreewInc.Core.Domain.Entities;
using GraphQL;

namespace TreewInc.Application.GraphQL.Queries;

public sealed class TreewIncQuery : ObjectGraphType
{
	public TreewIncQuery(IClientService service, IDataLoaderContextAccessor accessor)
	{
		Field<StringGraphType>(name: "name")
			.Resolve(_ => "TreewInc GraphQL API");
		
		Field<ListGraphType<ClientQueryType>, IEnumerable<Client>>("clients")
			.ResolveAsync(_ => accessor.Context.GetOrAddLoader("GetClients", service.GetClients)
				.LoadAsync());
	}
}
