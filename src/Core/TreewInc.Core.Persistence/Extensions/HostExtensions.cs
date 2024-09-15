using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TreewInc.Core.Persistence.Contexts;

namespace TreewInc.Core.Persistence.Extensions;

public static class HostExtensions
{
	public static IHost ApplyMigrations(this IHost host)
	{
		using var scope = host.Services.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
		var migrations = context.Database.GetPendingMigrations();
		if (migrations.Any())
			context.Database.Migrate();
		return host;
	}
}
