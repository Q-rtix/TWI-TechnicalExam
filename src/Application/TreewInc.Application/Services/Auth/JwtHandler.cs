using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TreewInc.Application.Abstractions.Auth;
using TreewInc.Application.Settings;

namespace TreewInc.Application.Services.Auth;

public class JwtHandler : IJwtHandler
{
	private readonly JwtSettings _jwtSettings;
	
	public JwtHandler(IOptions<JwtSettings> jwtSettings) => _jwtSettings = jwtSettings.Value;

	public string Generate(string email)
	{
		List<Claim> claims = [new Claim(JwtRegisteredClaimNames.Email, email)];
		claims.AddRange(_jwtSettings.Issuers.Select(i => new Claim(JwtRegisteredClaimNames.Iss, i)));
		claims.AddRange(_jwtSettings.Audiences.Select(a => new Claim(JwtRegisteredClaimNames.Aud, a)));
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
		var token = new JwtSecurityToken(claims: claims, signingCredentials: credentials, expires: DateTime.UtcNow.AddMinutes(60));
		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}