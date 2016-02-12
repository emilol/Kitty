namespace Kitty.Core.Infrastructure.MediatR
{
    public interface IPreRequestHandler<TRequest, TResponse>
    {
        Result<TResponse> Handle(TRequest request);
    }
}