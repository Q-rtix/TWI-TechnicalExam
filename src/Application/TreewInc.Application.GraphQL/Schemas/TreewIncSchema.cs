using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using TreewInc.Application.GraphQL.Mutations;
using TreewInc.Application.GraphQL.Queries;

namespace TreewInc.Application.GraphQL.Schemas;

public class TreewIncSchema : Schema
{
	public TreewIncSchema(IServiceProvider provider) : base(provider)
	{
		Query = provider.GetRequiredService<TreewIncQuery>();
		// Mutation = provider.GetRequiredService<TreewIncMutatition>();
	}
}
