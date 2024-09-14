using TreewInc.Application;
using TreewInc.Core.Infrastructure;
using TreewInc.Core.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence(builder.Configuration)
	.AddInfrastructure()
	.AddApplication()
	.AddControllers();

builder.Services.AddEndpointsApiExplorer()
	.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();