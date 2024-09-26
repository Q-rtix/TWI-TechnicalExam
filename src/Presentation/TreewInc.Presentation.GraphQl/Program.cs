using Microsoft.AspNetCore.Server.Kestrel.Core;
using TreewInc.Application.GraphQL;
using TreewInc.Application.GraphQL.Extensions;
using TreewInc.Core.Infrastructure;
using TreewInc.Core.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistence(builder.Configuration, builder.Environment)
	.AddInfrastructure()
	.AddGraphQl(options => options.Endpoint = "/graphql");

builder.Services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGraphQl();

app.Run();