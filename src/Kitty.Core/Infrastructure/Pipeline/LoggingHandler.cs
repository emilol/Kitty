using Kitty.Core.Infrastructure.MediatR;
using Serilog;

namespace Kitty.Core.Infrastructure.Pipeline
{
    public class LoggingPreHandler<TRequest, TResponse> : IPreRequestHandler<TRequest, TResponse>
    {
        public Result<TResponse> Handle(TRequest request)
        {
            Log.Information("Executing request: {@Request}", request);
            return Result<TResponse>.Success();
        }
    }

    public class LoggingPostHandler<TRequest, TResponse> : IPostRequestHandler<TRequest, TResponse>
    {
        public void Handle(TRequest request, TResponse response)
        {
            Log.Information("Executed request: {@Request} and got {@Response}", request, response);
        }
    }
}