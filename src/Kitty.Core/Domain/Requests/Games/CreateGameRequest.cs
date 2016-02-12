using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kitty.Core.Domain.Responses.Games;
using Kitty.Core.Infrastructure;
using MediatR;

namespace Kitty.Core.Domain.Requests.Games
{
    public class CreateGameRequest : IRequest<Result<GameResponse>>, IValidatableObject
    {
        public string Name { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name of game must not be null or white space", new [] {"Name"});
            }
        }
    }
}