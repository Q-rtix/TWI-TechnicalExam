namespace TreewInc.Application.Settings;

public class JwtSettings
{
	public string SecretKey { get; set; }
	public ICollection<string> Audiences { get; set; }
	public ICollection<string> Issuers { get; set; }
}
