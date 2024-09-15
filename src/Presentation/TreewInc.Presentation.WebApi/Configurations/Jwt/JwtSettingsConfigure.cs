using Microsoft.Extensions.Options;
using TreewInc.Application.Settings;

namespace TreewInc.Presentation.WebApi.Configurations.Jwt;

public class JwtSettingsConfigure : IConfigureOptions<JwtSettings>
{
	private readonly IConfiguration _configuration;

	public JwtSettingsConfigure(IConfiguration configuration) => _configuration = configuration;

	public void Configure(JwtSettings options) => _configuration.GetSection(nameof(JwtSettings)).Bind(options);
}
