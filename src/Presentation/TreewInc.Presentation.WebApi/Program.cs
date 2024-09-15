using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TreewInc.Application;
using TreewInc.Application.Settings;
using TreewInc.Core.Infrastructure;
using TreewInc.Core.Persistence;
using TreewInc.Presentation.WebApi.Configurations.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration)
	.AddInfrastructure()
	.AddApplication()
	.AddControllers();

builder.Services.ConfigureOptions<JwtSettingsConfigure>();

var jwtSettings = builder.Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
ArgumentNullException.ThrowIfNull(jwtSettings, nameof(JwtSettings));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(config => config.TokenValidationParameters = new TokenValidationParameters
	{
		ValidIssuer = jwtSettings.Issuer,
		ValidAudience = jwtSettings.Audience,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true
	});

builder.Services.AddEndpointsApiExplorer()
	.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
