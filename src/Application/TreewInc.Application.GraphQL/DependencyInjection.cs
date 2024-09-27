using GraphQL;
using GraphQL.DataLoader;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Application.GraphQL.GraphTypes.MutationTypes;
using TreewInc.Application.GraphQL.GraphTypes.QueryTypes;
using TreewInc.Application.GraphQL.GraphTypes.Types;
using TreewInc.Application.GraphQL.Mutations;
using TreewInc.Application.GraphQL.Queries;
using TreewInc.Application.GraphQL.Schemas;
using TreewInc.Application.GraphQL.Services;
using TreewInc.Application.GraphQL.Settings;

namespace TreewInc.Application.GraphQL;

public static class DependencyInjection
{
	public static IServiceCollection AddGraphQl(this IServiceCollection services, Action<GraphQlSettings> configure)
	{
		services.Configure(configure);
		
		services.AddGraphQlExecuters()
			.AddGraphQlDataLoader()
			.AddGraphQlSchemas()
			.AddGraphQlQueries()
			.AddGraphQlMutations()
			.AddGraphQlServices()
			.AddGraphQlQueryTypes()
			.AddGraphQlMutationTypes();

		return services;
	}
	
	private static IServiceCollection AddGraphQlQueryTypes(this IServiceCollection services)
	{
		services.AddScoped<ClientQueryType>();
		services.AddScoped<SaleQueryType>();
		services.AddScoped<NameType>();
		services.AddScoped<PhoneType>();
		services.AddScoped<ProductQueryType>();
		
		return services;
	}
	
	private static IServiceCollection AddGraphQlMutationTypes(this IServiceCollection services)
	{
		services.AddScoped<NameInputType>();
		services.AddScoped<PhoneInputType>();
		services.AddScoped<CreateClientMutationType>();
		
		return services;
	}

	private static IServiceCollection AddGraphQlDataLoader(this IServiceCollection services)
	{
		services.AddScoped<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
		services.AddScoped<DataLoaderDocumentListener>();
		
		return services;
	}

	private static IServiceCollection AddGraphQlServices(this IServiceCollection services)
	{
		services.AddScoped<IClientService, ClientService>();
		services.AddScoped<ISaleService, SaleService>();
		services.AddScoped<IProductService, ProductService>();
		
		return services;
	}

	private static IServiceCollection AddGraphQlSchemas(this IServiceCollection services)
	{
		services.AddScoped<ISchema, TreewIncSchema>();

		return services;
	}

	private static IServiceCollection AddGraphQlQueries(this IServiceCollection services)
	{
		services.AddScoped<TreewIncQuery>();
		
		return services;
	}

	private static IServiceCollection AddGraphQlMutations(this IServiceCollection services)
	{
		services.AddScoped<TreewIncMutation>();

		return services;
	}

	private static IServiceCollection AddGraphQlExecuters(this IServiceCollection services)
	{
		services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
		services.AddSingleton<IDocumentWriter, DocumentWriter>();

		return services;
	}
}
