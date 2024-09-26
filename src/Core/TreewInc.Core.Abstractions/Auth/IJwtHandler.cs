namespace TreewInc.Core.Abstractions.Auth;

public interface IJwtHandler
{
	string Generate(string email);
}
