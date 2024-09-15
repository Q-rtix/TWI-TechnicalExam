namespace TreewInc.Application.Helpers;

public static class PassHelper
{
	public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
	public static bool VerifyPassword(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash);
}
