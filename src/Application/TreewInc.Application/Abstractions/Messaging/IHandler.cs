using MediatR;
using Results;

namespace TreewInc.Application.Abstractions.Messaging;

public interface IHandler<in TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
	where TRequest : IRequest<Result<TResponse>>
{ }
