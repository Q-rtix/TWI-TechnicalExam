using GraphQL.Types;
using TreewInc.Application.GraphQL.GraphTypes.Types;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.GraphTypes.MutationTypes;

public sealed class CreateClientMutationType : InputObjectGraphType<Client>
{
	public CreateClientMutationType()
	{
		Name = "CreateClient";
		Field<NonNullGraphType<NameInputType>>()
			.Name("name")
			.Resolve(context => context.Source.Name);
		Field<NonNullGraphType<StringGraphType>>()
			.Name("email")
			.Resolve(context => context.Source.Email);
		Field<NonNullGraphType<PhoneInputType>>()
			.Name("phone")
			.Resolve(context => context.Source.Phone);
		Field<NonNullGraphType<StringGraphType>>()
			.Name("password")
			.Resolve(context => context.Source.Password);
	}
}
