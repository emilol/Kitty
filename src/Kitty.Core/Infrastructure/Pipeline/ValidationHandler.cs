using System.ComponentModel.DataAnnotations;
using Kitty.Core.Infrastructure.MediatR;
using Serilog;
using System.Linq;

namespace Kitty.Core.Infrastructure.Pipeline
{
    public class ValidationHandler<TRequest, TResponse> : IPreRequestHandler<TRequest, TResponse>
        where TRequest : IValidatableObject
    {
        public Result<TResponse> Handle(TRequest request)
        {
            Log.Information("Validating request {@Command}", request);

            var context = new ValidationContext(request);
            var result = request.Validate(context).ToList();

            var msg = result.Any() ? "Fail" : "Success";
            var failureMessages = result.Select(x => x.ToString()).ToArray();

            Log.Information("Validation state: {State}: {Messages}",msg, failureMessages);

            return result.Any()
                ? Result<TResponse>.Failed(failureMessages)
                : Result<TResponse>.Success();
        }
    }
}