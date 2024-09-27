using GraphQL;
using GraphQL.Types;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Application.GraphQL.GraphTypes.MutationTypes;
using TreewInc.Application.GraphQL.GraphTypes.QueryTypes;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.Mutations;

public sealed class TreewIncMutation : ObjectGraphType
{
	public TreewIncMutation(IClientService clientService)
	{
		Field<ClientQueryType>("createClient")
			.Argument<NonNullGraphType<CreateClientMutationType>>("client")
			.ResolveAsync(async context =>
			{
				var client = context.GetArgument<Client>("client");
				return await clientService.CreateClientAsync(client);
			});
	}
}
