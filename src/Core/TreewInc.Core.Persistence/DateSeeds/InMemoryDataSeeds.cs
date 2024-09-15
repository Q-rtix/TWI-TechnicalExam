using TreewInc.Core.Persistence.Contexts;

namespace TreewInc.Core.Persistence.DateSeeds;

public static class InMemoryDataSeeds
{
	public static void SeedInMemory(this AppDbContext context)
	{
		ProductDataSeed.InMemorySeed(context);
		ClientDataSeed.InMemorySeed(context);
	}
}
