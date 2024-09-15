namespace TreewInc.Application.Abstractions.Auth;

public interface IJwtHandler
{
	string Generate(string email);
}
