using MediatR;
using Results;

namespace TreewInc.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }

public interface IPagedQuery<TResponse> : IRequest<Result<TResponse>>
{
	public int PageNumber { get; }
	public int PageSize { get; }
}
