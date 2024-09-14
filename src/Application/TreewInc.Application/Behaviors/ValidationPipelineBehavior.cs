using FluentValidation;
using MediatR;
using Results;
using Results.Abstractions;
using Results.ResultTypes;
using TreewInc.Application.Models;

namespace TreewInc.Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
	where TResponse : class, IResult
{
	private readonly IEnumerable<IValidator<TRequest>> _validators;

	public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default)
	{
		if (!_validators.Any())
			return await next();

		var errors = _validators.Select(validator => validator.Validate(request))
			.SelectMany(validationResult => validationResult.Errors)
			.Where(validationFailure => validationFailure is not null)
			.Select(failure => new ValidationError(failure.PropertyName, failure.ErrorMessage))
			.Distinct()
			.ToList();
		
		if (errors.Count == 0)
			return await next();
		
		var validationResult = typeof(Result<>)
			.GetGenericTypeDefinition()
			.MakeGenericType(typeof(TResponse).GenericTypeArguments[0])
			.GetConstructor([typeof(ResultType), typeof(int?)])!
			.Invoke([new Error(errors), null]);
		
		return (TResponse)validationResult;
	}
}