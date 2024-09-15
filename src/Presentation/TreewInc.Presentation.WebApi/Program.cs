using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using TreewInc.Application;
using TreewInc.Application.Settings;
using TreewInc.Core.Infrastructure;
using TreewInc.Core.Persistence;
using TreewInc.Core.Persistence.Contexts;
using TreewInc.Core.Persistence.DateSeeds;
using TreewInc.Core.Persistence.Extensions;
using TreewInc.Presentation.WebApi.Configurations.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration, builder.Environment)
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
	.AddSwaggerGen(options =>
	{
		options.SwaggerDoc("v1", new OpenApiInfo
		{
			Title = "TreewInc.WebApi", 
			Version = "v1",
			Description = "API for managing products and sales, including operations such as creating, updating, and removing products, as well as handling sales transactions.",
		});
		options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
		{
			Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
			Name = "Authorization",
			In = ParameterLocation.Header,
			Type = SecuritySchemeType.ApiKey,
			Scheme = "Bearer"
		});
		options.AddSecurityRequirement(new OpenApiSecurityRequirement
		{
			{
				new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				},
                Array.Empty<string>()
            }
		});
		var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
		var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
		options.IncludeXmlComments(xmlPath);
	});

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Testing"))
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
if (!app.Environment.IsEnvironment("Testing"))
	app.ApplyMigrations();
else
{
	using var context = app.Services.GetRequiredService<AppDbContext>();
	context.SeedInMemory();
}
	

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
