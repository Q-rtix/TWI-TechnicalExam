using MediatR;
using Results;

namespace TreewInc.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
