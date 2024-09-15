using Microsoft.Extensions.DependencyInjection;
using TreewInc.Application.Abstractions;
using TreewInc.Application.Abstractions.Auth;
using TreewInc.Core.Infrastructure.Repositories;
using TreewInc.Core.Infrastructure.Services.Auth;

namespace TreewInc.Core.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IJwtHandler, JwtHandler>();
		return services;
	}
}
