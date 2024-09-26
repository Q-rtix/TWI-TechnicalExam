using Microsoft.Extensions.Options;
using TreewInc.Core.Settings;

namespace TreewInc.Presentation.WebApi.Configurations.Jwt;

/// <summary>
/// Configures JWT settings by binding them to the configuration section.
/// </summary>
public class JwtSettingsConfigure : IConfigureOptions<JwtSettings>
{
	private readonly IConfiguration _configuration;

	/// <summary>
	/// Initializes a new instance of the <see cref="JwtSettingsConfigure"/> class.
	/// </summary>
	public JwtSettingsConfigure(IConfiguration configuration) => _configuration = configuration;

	/// <summary>
	/// Configures the JWT settings by binding them to the configuration section.
	/// </summary>
	public void Configure(JwtSettings options) => _configuration.GetSection(nameof(JwtSettings)).Bind(options);
}
