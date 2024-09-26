using FluentAssertions;
using Moq;
using TreewInc.Application.Features.Clients.Update;
using TreewInc.Application.Tests.Mocks;
using TreewInc.Core.Abstractions;
using TreewInc.Core.Domain.Entities;
using TreewInc.Core.Persistence.DateSeeds;

namespace TreewInc.Application.Tests.Features.Clients.Update;

public class UpdateClientCommandHandlerTest
{
	private readonly Mock<IUnitOfWork> _unitOfWorkMock;
	private readonly UpdateClientCommandHandler _handler;
	
	public UpdateClientCommandHandlerTest()
	{
	    _unitOfWorkMock = UnitOfWorkMock.GetUnitOfWorkMock();
	    _handler = new UpdateClientCommandHandler(_unitOfWorkMock.Object);
	}
	
	[Fact]
	public async Task Handle_ShouldUpdateClient_WhenClientExists()
	{
	    // Arrange
	    var newClient = ClientDataSeed.Faker().Generate();
	    const string email = "newemail@mail.com";
	    var command = new UpdateClientCommand(newClient.Id, newClient.Name, email, newClient.Phone);
	
	    // Act
	    var response = await _handler.Handle(command, CancellationToken.None);
	
	    // Assert
	    response.Should().NotBeNull();
	    response.IsSucceed.Should().BeTrue();
	    response.Value.ClientId.Should().Be(newClient.Id);
	    _unitOfWorkMock.Verify(u => u.Repository<Client>().UpdateOne(It.IsAny<Client>()), Times.Once);
	    _unitOfWorkMock.Verify(u => u.SaveAsync(It.IsAny<CancellationToken>()), Times.Once);
	}
	
	[Fact]
	public async Task Handle_ShouldReturnFailure_WhenClientDoesNotExist()
	{
	    // Arrange
	    var client = ClientDataSeed.Faker().Generate(1)[0];
	    var command = new UpdateClientCommand(100, client.Name, client.Email, client.Phone);
	
	    // Act
	    var response = await _handler.Handle(command, CancellationToken.None);
	
	    // Assert
	    response.Should().NotBeNull();
	    response.IsSucceed.Should().BeFalse();
	    _unitOfWorkMock.Verify(u => u.Repository<Client>().UpdateOne(It.IsAny<Client>()), Times.Never);
	    _unitOfWorkMock.Verify(u => u.SaveAsync(It.IsAny<CancellationToken>()), Times.Never);
	}
}
