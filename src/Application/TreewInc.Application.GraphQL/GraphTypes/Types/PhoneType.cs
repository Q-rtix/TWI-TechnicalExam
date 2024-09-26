using GraphQL.Types;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.GraphQL.GraphTypes.Types;

public sealed class PhoneType : ObjectGraphType<PhoneNumber>
{
	public PhoneType()
	{
		Field(p => p.CountryCode);
		Field(p => p.Number);
	}
}
