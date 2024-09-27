using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Text.Json;
using TreewInc.Application.GraphQL.Requests;
using TreewInc.Application.GraphQL.Settings;

namespace TreewInc.Application.GraphQL.Middlewares;

public class GraphQlMiddleware
{
	private readonly RequestDelegate _next;
	private readonly GraphQlSettings _settings;
	private readonly IDocumentExecuter _executer;
	private readonly IDocumentWriter _writer;
	private readonly IWebHostEnvironment _env;

	public GraphQlMiddleware(RequestDelegate next,
		IDocumentExecuter executer, 
		IDocumentWriter writer, 
		IOptions<GraphQlSettings> settings, 
		IWebHostEnvironment env)
	{
		_next = next;
		_executer = executer;
		_writer = writer;
		_env = env;
		_settings = settings.Value;
	}

	public async Task InvokeAsync(HttpContext context, ISchema schema, IServiceProvider provider)
	{
		if (!context.Request.Path.StartsWithSegments(_settings.Endpoint)
			&& !context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
		{
			await _next(context);
		}

		var request = await JsonSerializer.DeserializeAsync<GraphQlRequest>(
			context.Request.Body,
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
		
		var result = await _executer.ExecuteAsync(doc =>
		{
			doc.Schema = schema;
			doc.Query = request!.Query;
			doc.Inputs = request.Variables.ToInputs();
			doc.Listeners.Add(provider.GetRequiredService<DataLoaderDocumentListener>());
			doc.ThrowOnUnhandledException = _env.IsDevelopment();
		}).ConfigureAwait(false);
		
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = StatusCodes.Status200OK;
		
		await _writer.WriteAsync(context.Response.Body, result);
	}
}
