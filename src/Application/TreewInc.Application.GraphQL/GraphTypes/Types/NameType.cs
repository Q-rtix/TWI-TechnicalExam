using GraphQL.Types;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.GraphQL.GraphTypes.Types;

public sealed class NameType : ObjectGraphType<Name>
{
	public NameType()
	{
		Field(n => n.FirstName);
		Field(n => n.MiddleName, nullable: true);
		Field(n => n.LastName);
	}
}
