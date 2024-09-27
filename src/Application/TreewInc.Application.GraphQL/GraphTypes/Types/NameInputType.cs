﻿using GraphQL.Types;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.GraphQL.GraphTypes.Types;

public sealed class NameInputType : InputObjectGraphType<Name>
{
	public NameInputType()
	{
		Name = "Name";
		Field<NonNullGraphType<StringGraphType>>()
			.Name("firstName")
			.Resolve(context => context.Source.FirstName);
		Field<StringGraphType>()
			.Name("middleName")
			.Resolve(context => context.Source.MiddleName);
		Field<NonNullGraphType<StringGraphType>>()
			.Name("lastName")
			.Resolve(context => context.Source.LastName);
	}
}
