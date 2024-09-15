using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TreewInc.Core.Persistence.Contexts;

namespace TreewInc.Core.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
	{
		services.AddDbContext<AppDbContext>(builder =>
		{
			if (env.EnvironmentName == "Testing")
				builder.UseInMemoryDatabase("TreewIncStore");
			else
				builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		});
		return services;
	}
}
