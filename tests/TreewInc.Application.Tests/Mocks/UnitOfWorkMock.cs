using Moq;
using TreewInc.Application.Abstractions;
using TreewInc.Core.Domain.Entities;

namespace TreewInc.Application.Tests.Mocks;

public static class UnitOfWorkMock
{
	public static Mock<IUnitOfWork> GetUnitOfWorkMock()
	{
		var mock = new Mock<IUnitOfWork>();

		mock.Setup(u => u.Repository<Client>())
			.Returns(() => RepositoryMock.GetClientRepositoryMock().Object);
		mock.Setup(u => u.Repository<Product>())
			.Returns(() => RepositoryMock.GetProductRepositoryMock().Object);

		mock.Setup(u => u.SaveAsync(It.IsAny<CancellationToken>()))
			.Returns(() => Task.FromResult(1));
		
		return mock;
	}
}
