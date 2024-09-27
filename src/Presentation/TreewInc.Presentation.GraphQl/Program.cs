using Microsoft.AspNetCore.Server.Kestrel.Core;
using TreewInc.Application.GraphQL;
using TreewInc.Core.Infrastructure;
using TreewInc.Core.Persistence;
using TreewInc.Application.GraphQL.Schemas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddPersistence(builder.Configuration, builder.Environment)
	.AddInfrastructure()
	.AddGraphQLApplication(builder.Environment);

builder.Services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGraphQL<TreewIncSchema>(path: "/graphql");

app.Run();