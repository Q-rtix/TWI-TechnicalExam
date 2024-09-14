using Microsoft.Extensions.DependencyInjection;
using TreewInc.Application.Abstractions;
using TreewInc.Core.Infrastructure.Repositories;

namespace TreewInc.Core.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		return services;
	}
}
