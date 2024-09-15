using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;
using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Persistence.Contexts;

[assembly:InternalsVisibleTo("TreewInc.Application.Tests")]

namespace TreewInc.Core.Persistence.DateSeeds;

internal static class ProductDataSeed
{
	internal static Faker<Product> Faker()
	{
		int ids = 1;
		return new Faker<Product>()
			.RuleFor(p => p.Id, _ => ids++)
			.RuleFor(p => p.Name, f => f.Commerce.ProductName())
			.RuleFor(p => p.Price, f => f.Finance.Amount(10, 1000))
			.RuleFor(p => p.Description, f => f.Lorem.Sentence())
			.RuleFor(p => p.Stock, f => f.Random.Number(0, 100));
	}
	
	internal static void Seed(this EntityTypeBuilder<Product> entity)
		=> entity.HasData(Faker().Generate(10));
	
	internal static void InMemorySeed(AppDbContext context)
	{
		var products = context.Set<Product>();
		if (products.Any())
			return;
		
		products.AddRange(Faker().Generate(25));
		context.SaveChanges();
	}
}
