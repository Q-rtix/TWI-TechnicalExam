using GraphQL.DataLoader;
using Microsoft.Extensions.DependencyInjection;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Application.GraphQL.GraphTypes.QueryTypes;
using TreewInc.Application.GraphQL.Services;
using TreewInc.Application.GraphQL.Settings;

namespace TreewInc.Application.GraphQL;

public static class DependencyInjection
{
	public static IServiceCollection AddGraphQl(this IServiceCollection services, Action<GraphQlSettings> configure)
	{
		services.Configure(configure);
		services.AddGraphQlDataLoader()
			.AddGraphQlServices()
			.AddGraphQlQueryTypes();

		return services;
	}

	private static IServiceCollection AddGraphQlDataLoader(this IServiceCollection services)
	{
		services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
		services.AddSingleton<DataLoaderDocumentListener>();
		
		return services;
	}

	private static IServiceCollection AddGraphQlServices(this IServiceCollection services)
	{
		services.AddScoped<IClientService, ClientService>();
		services.AddScoped<ISaleService, SaleService>();
		
		return services;
	}

	private static IServiceCollection AddGraphQlQueryTypes(this IServiceCollection services)
	{
		services.AddScoped<ClientType>();
		services.AddScoped<SaleType>();
		
		return services;
	}
}
