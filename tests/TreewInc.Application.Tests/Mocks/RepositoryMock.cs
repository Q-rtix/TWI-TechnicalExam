using Moq;
using System.Linq.Expressions;
using TreewInc.Application.Abstractions;
using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Domain.Models;
using TreewInc.Core.Persistence.DateSeeds;

namespace TreewInc.Application.Tests.Mocks;

public static class RepositoryMock
{
	public static Mock<IRepository<Client>> GetClientRepositoryMock()
	{
		var clients = ClientDataSeed.Faker().Generate(5);
		clients.Add(new Client(new Name("first", "last"), "NotUnique", new PhoneNumber("53", "656489874"), "Pass1234"));
		
		var mock = new Mock<IRepository<Client>>();

		mock.Setup(r => r.AddOneAsync(It.IsAny<Client>(), It.IsAny<CancellationToken>()))
			.Returns((Client client, CancellationToken _) => Task.CompletedTask);

		mock.Setup(r => r.GetOneAsync(It.IsAny<Expression<Func<Client, bool>>[]>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
			.Returns((Expression<Func<Client, bool>>[] filters, bool _, CancellationToken _) =>
			{
				var client = filters.Aggregate(clients.AsQueryable(), (current, filter) => current.Where(filter))
					.FirstOrDefault();
				return Task.FromResult(client);
			});
		
		mock.Setup(r => r.UpdateOne(It.IsAny<Client>()))
			.Callback((Client client) =>
			{
				var index = clients.FindIndex(c => c.Id == client.Id);
				clients[index] = client;
			});
		
		return mock;
	}

	public static Mock<IRepository<Product>> GetProductRepositoryMock()
	{
		var mock = new Mock<IRepository<Product>>();
		return mock;
	}
}
