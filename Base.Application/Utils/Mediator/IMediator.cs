using Base.Application.Utils.Result;

namespace Base.Application.Utils.Mediator
{
    public interface IMediator
    {
        Task<Result<TResponse>> Send<TResponse>(IRequest<TResponse> request);
        Task Send(IRequest request);
    }
}
