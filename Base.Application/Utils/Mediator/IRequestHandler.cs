using Base.Application.Utils.Result;

namespace Base.Application.Utils.Mediator
{
    public interface IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<Result<TResponse>> Handle(TRequest request);
    }

    public interface IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        Task Handle(TRequest request);
    }
}