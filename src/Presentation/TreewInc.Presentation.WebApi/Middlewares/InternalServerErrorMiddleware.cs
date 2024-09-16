using Results.ResultTypes;

namespace TreewInc.Presentation.WebApi.Middlewares;

public class InternalServerErrorMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<InternalServerErrorMiddleware> _logger;

	public InternalServerErrorMiddleware(RequestDelegate next, ILogger<InternalServerErrorMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception e)
		{
			_logger.LogCritical(e, $"An error occurred while processing the request");
			var error = new Error(e.Message, e.Source!);
			
			context.Response.StatusCode = StatusCodes.Status500InternalServerError;
			context.Response.ContentType = "application/json";
			await context.Response.WriteAsJsonAsync(error);
		}
	}
}
