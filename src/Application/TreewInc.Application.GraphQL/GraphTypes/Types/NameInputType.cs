using GraphQL.Types;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.GraphQL.GraphTypes.Types;

public sealed class NameInputType : InputObjectGraphType<Name>
{
	public NameInputType()
	{
		Name = "NameInput";
		Field<NonNullGraphType<StringGraphType>>("firstName");
		Field<StringGraphType>("middleName");
		Field<NonNullGraphType<StringGraphType>>("lastName");
	}
}
