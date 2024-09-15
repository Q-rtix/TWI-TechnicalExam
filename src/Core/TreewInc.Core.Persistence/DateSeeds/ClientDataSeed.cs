using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;
using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Domain.Models;
using TreewInc.Core.Persistence.Contexts;

[assembly:InternalsVisibleTo("TreewInc.Application.Tests")]

namespace TreewInc.Core.Persistence.DateSeeds;

internal static class ClientDataSeed
{
	internal static Faker<Client> Faker()
	{
		int ids = 1;
		return new Faker<Client>()
			.RuleFor(c => c.Id, _ => ids++)
			.RuleFor(c => c.Name, f => new Name(f.Name.FirstName(), f.Name.LastName(), f.Name.FirstName().OrNull(f)))
			.RuleFor(c => c.Email, f => f.Internet.Email())
			.RuleFor(c => c.Phone, f =>
			{
				var phone = f.Phone.PhoneNumber("1 7691651548");
				var split = phone.Split(' ');
				return new PhoneNumber(split[0], split[1]);
			})
			.RuleFor(c => c.Password, _ => "Pass1234");
	}
	
	public static void Seed(this EntityTypeBuilder<Client> entity)
		=> entity.HasData(Faker().Generate(10));
	
	public static void InMemorySeed(AppDbContext context)
	{
		var clients = context.Set<Client>();
		if (clients.Any())
			return;
		
		clients.AddRange(Faker().Generate(25));
		context.SaveChanges();
	}
}
