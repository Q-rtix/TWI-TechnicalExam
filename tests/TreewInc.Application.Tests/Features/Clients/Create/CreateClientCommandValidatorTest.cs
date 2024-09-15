using FluentValidation.TestHelper;
using TreewInc.Application.Features.Clients.Create;
using TreewInc.Core.Domain.Models;

namespace TreewInc.Application.Tests.Features.Clients.Create;

public class CreateClientCommandValidatorTest
{
    private readonly CreateClientCommandValidator _validator;

    public CreateClientCommandValidatorTest() => _validator = new CreateClientCommandValidator();

    [Fact]
    public void Should_Have_Error_When_Name_Is_Null()
    {
        var command = new CreateClientCommand(null, "email@example.com", new PhoneNumber("53", "656489874"), "Pass1234");
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        var command = new CreateClientCommand(new Name("first", "last"), "invalid-email", new PhoneNumber("53", "656489874"), "Pass1234");
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Email);
    }

    [Fact]
    public void Should_Have_Error_When_Phone_Is_Null()
    {
        var command = new CreateClientCommand(new Name("first", "last"), "email@example.com", null, "Pass1234");
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Phone);
    }

    [Fact]
    public void Should_Have_Error_When_Password_Is_Too_Short()
    {
        var command = new CreateClientCommand(new Name("first", "last"), "email@example.com", new PhoneNumber("53", "656489874"), "short");
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Password);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Command_Is_Valid()
    {
        var command = new CreateClientCommand(new Name("first", "last"), "email@example.com", new PhoneNumber("53", "656489874"), "Pass1234");
        var result = _validator.TestValidate(command);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
