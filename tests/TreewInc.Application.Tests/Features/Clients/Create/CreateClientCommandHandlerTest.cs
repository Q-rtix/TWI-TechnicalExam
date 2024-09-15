using FluentAssertions;
using TreewInc.Application.Features.Clients.Create;
using TreewInc.Application.Tests.Mocks;
using TreewInc.Core.Persistence.DateSeeds;

namespace TreewInc.Application.Tests.Features.Clients.Create;

public class CreateClientCommandHandlerTest
{
	private const string Pass = "Pass1234";

	[Fact]
	public async Task Handle_ShouldCreateClient_WhenCommandIsValid()
	{
		// Arrange
		var client = ClientDataSeed.Faker().Generate(1)[0];
		var command = new CreateClientCommand(client.Name, client.Email, client.Phone, client.Password);
		var handler = new CreateClientCommandHandler(UnitOfWorkMock.GetUnitOfWorkMock().Object);

		// Act
		var result = await handler.Handle(command, default);

		// Assert
		result.Should().NotBeNull();
		result.IsSucceed.Should().BeTrue();
		result.Value.Should().NotBeNull();
		result.Value.ClientId.Should<int>().NotBeNull();
	}
	
	[Fact]
	public async Task Handle_ShouldReturnError_WhenEmailAlreadyExists()
	{
	    // Arrange
	    var existingClient = ClientDataSeed.Faker().Generate(1)[0];
	    const string email = "NotUnique";
	    var command = new CreateClientCommand(existingClient.Name, email, existingClient.Phone, existingClient.Password);
	    var handler = new CreateClientCommandHandler(UnitOfWorkMock.GetUnitOfWorkMock().Object);
	
	    // Act
	    var result = await handler.Handle(command, default);
	
	    // Assert
	    result.Should().NotBeNull();
	    result.IsFaulted.Should().BeTrue();
	    result.Errors.Should().NotBeEmpty()
		    .And.ContainSingle(e => (string)e == "Email already in use");
	    
	}
}
