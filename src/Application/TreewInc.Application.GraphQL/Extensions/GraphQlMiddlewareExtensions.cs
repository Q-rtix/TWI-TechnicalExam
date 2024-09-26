using Microsoft.AspNetCore.Builder;
using TreewInc.Application.GraphQL.Middlewares;

namespace TreewInc.Application.GraphQL.Extensions;

public static class GraphQlMiddlewareExtensions
{
	public static IApplicationBuilder UseGraphQl(this IApplicationBuilder app)
		=> app.UseMiddleware<GraphQlMiddleware>();
}