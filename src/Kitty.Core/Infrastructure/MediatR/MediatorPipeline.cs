using System.Collections.Generic;
using MediatR;

namespace Kitty.Core.Infrastructure.MediatR
{
    public class MediatorPipeline<TRequest, TResponse>
        : IRequestHandler<TRequest, Result<TResponse>>
        where TRequest : IRequest<Result<TResponse>>
    {
        private readonly IRequestHandler<TRequest, Result<TResponse>> _inner;
        private readonly IEnumerable<IPreRequestHandler<TRequest, Result<TResponse>>> _preRequestHandlers;
        private readonly IEnumerable<IPostRequestHandler<TRequest, Result<TResponse>>> _postRequestHandlers;

        public MediatorPipeline(
            IRequestHandler<TRequest, Result<TResponse>> inner,
            IEnumerable<IPreRequestHandler<TRequest, Result<TResponse>>> preRequestHandlers,
            IEnumerable<IPostRequestHandler<TRequest, Result<TResponse>>> postRequestHandlers
            )
        {
            _inner = inner;
            _preRequestHandlers = preRequestHandlers;
            _postRequestHandlers = postRequestHandlers;
        }

        public Result<TResponse> Handle(TRequest message)
        {
            foreach (var preRequestHandler in _preRequestHandlers)
            {
                var preResult = preRequestHandler.Handle(message);
                if (preResult.WasFailure) return preResult;
            }

            var result = _inner.Handle(message);

            foreach (var postRequestHandler in _postRequestHandlers)
            {
                postRequestHandler.Handle(message, result);
            }

            return result;
        }
    }
}