using GraphQL.Types;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.GraphQL.GraphTypes.Types;

public sealed class PhoneInputType : InputObjectGraphType<PhoneNumber>
{
	public PhoneInputType()
	{
		Name = "Phone";
		Field<NonNullGraphType<StringGraphType>>()
			.Name("countryCode")
			.Resolve(context => context.Source.CountryCode);
		Field<NonNullGraphType<StringGraphType>>()
			.Name("number")
			.Resolve(context => context.Source.Number);
	}
}
