using MediatR;
using Results;

namespace TreewInc.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result<Empty>> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
