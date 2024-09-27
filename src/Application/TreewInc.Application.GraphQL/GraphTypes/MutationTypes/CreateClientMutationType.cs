using GraphQL.Types;
using TreewInc.Application.GraphQL.GraphTypes.Types;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.GraphQL.GraphTypes.MutationTypes;

public sealed class CreateClientMutationType : InputObjectGraphType<Client>
{
	public CreateClientMutationType()
	{
		Name = "CreateClient";
		Field<NonNullGraphType<NameInputType>>("name");
		Field<NonNullGraphType<StringGraphType>>("email");
		Field<NonNullGraphType<PhoneInputType>>("phone");
		Field<NonNullGraphType<StringGraphType>>("password");
	}
}
