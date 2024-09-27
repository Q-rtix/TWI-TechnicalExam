using GraphQL.Types;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.GraphQL.GraphTypes.Types;

public sealed class PhoneInputType : InputObjectGraphType<PhoneNumber>
{
	public PhoneInputType()
	{
		Name = "PhoneInput";
		Field<NonNullGraphType<StringGraphType>>("countryCode");
		Field<NonNullGraphType<StringGraphType>>("number");
	}
}
