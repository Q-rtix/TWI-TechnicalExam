using Microsoft.Extensions.DependencyInjection;
using TreewInc.Application.GraphQL.Abstractions.Services;
using TreewInc.Application.GraphQL.Services;
using GraphQL;
using Microsoft.Extensions.Hosting;
using TreewInc.Application.GraphQL.GraphTypes.MutationTypes;
using TreewInc.Application.GraphQL.GraphTypes.QueryTypes;
using TreewInc.Application.GraphQL.GraphTypes.Types;
using TreewInc.Application.GraphQL.Mutations;
using TreewInc.Application.GraphQL.Queries;
using TreewInc.Application.GraphQL.Schemas;
using ServiceLifetime = GraphQL.DI.ServiceLifetime;

namespace TreewInc.Application.GraphQL;

public static class DependencyInjection
{
	public static IServiceCollection AddGraphQLApplication(this IServiceCollection services, IHostEnvironment env)
		=> services.AddServices()
			.AddGraphQL(options =>
				options.AddSchema<TreewIncSchema>(ServiceLifetime.Scoped)
					.AddSystemTextJson()
					.AddDataLoader()
					.AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = env.IsDevelopment())
			).AddScoped<TreewIncQuery>()
			.AddScoped<TreewIncMutation>()
			.AddGraphQLTypes();
	
	private static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddScoped<IClientService, ClientService>();
		services.AddScoped<ISaleService, SaleService>();
		services.AddScoped<IProductService, ProductService>();
		
		return services;
	}

	private static IServiceCollection AddQueryTypes(this IServiceCollection services)
		=> services.AddScoped<ClientQueryType>()
			.AddScoped<SaleQueryType>()
			.AddScoped<ProductQueryType>();

	private static IServiceCollection AddMutationTypes(this IServiceCollection services) 
		=> services.AddScoped<CreateClientMutationType>();

	private static IServiceCollection AddGraphQLTypes(this IServiceCollection services)
		=> services.AddQueryTypes()
			.AddMutationTypes()
			.AddScoped<NameType>()
			.AddScoped<NameInputType>()
			.AddScoped<PhoneType>()
			.AddScoped<PhoneInputType>();
}
