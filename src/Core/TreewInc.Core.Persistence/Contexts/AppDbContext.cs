using Microsoft.EntityFrameworkCore;

namespace TreewInc.Core.Persistence.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}
