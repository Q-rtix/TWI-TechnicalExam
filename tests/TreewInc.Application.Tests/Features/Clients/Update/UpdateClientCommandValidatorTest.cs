using FluentValidation.TestHelper;
using TreewInc.Application.Features.Clients.Update;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.Tests.Features.Clients.Update;

public class UpdateClientCommandValidatorTest
{
	private readonly UpdateClientCommandValidator _validatorTest;

	public UpdateClientCommandValidatorTest() => _validatorTest = new UpdateClientCommandValidator();

	[Fact]
	public void Should_Have_Error_When_Name_Is_Null()
	{
		var command = new UpdateClientCommand(1, null, "email@example.com", new PhoneNumber("53", "656489874"));
		var result = _validatorTest.TestValidate(command);
		result.ShouldHaveValidationErrorFor(c => c.Name);
	}

	[Fact]
	public void Should_Have_Error_When_Email_Is_Invalid()
	{
		var command = new UpdateClientCommand(1, new Name("Joe", "Doe"), "invalid-email", new PhoneNumber("53", "656489874"));
		var result = _validatorTest.TestValidate(command);
		result.ShouldHaveValidationErrorFor(c => c.Email);
	}

	[Fact]
	public void Should_Have_Error_When_Phone_Is_Null()
	{
		var command = new UpdateClientCommand(1, new Name("Joe", "Doe"), "email@example.com", null);
		var result = _validatorTest.TestValidate(command);
		result.ShouldHaveValidationErrorFor(c => c.Phone);
	}

	[Fact]
	public void Should_Not_Have_Error_When_Command_Is_Valid()
	{
		var command = new UpdateClientCommand(1, new Name("Joe", "Doe"), "email@example.com", new PhoneNumber("53", "656489874"));
		var result = _validatorTest.TestValidate(command);
		result.ShouldNotHaveAnyValidationErrors();
	}
}
