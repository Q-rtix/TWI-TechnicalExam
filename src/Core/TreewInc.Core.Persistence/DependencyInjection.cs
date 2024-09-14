using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TreewInc.Core.Persistence.Contexts;

namespace TreewInc.Core.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(builder =>
		{
			builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		});
		return services;
	}
}
