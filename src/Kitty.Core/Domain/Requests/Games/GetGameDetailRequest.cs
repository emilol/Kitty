using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kitty.Core.Domain.Responses.Games;
using Kitty.Core.Infrastructure;
using MediatR;

namespace Kitty.Core.Domain.Requests.Games
{
    public class GetGameDetailRequest : IRequest<Result<GameDetailResponse>>, IValidatableObject
    {
        public GetGameDetailRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id == Guid.Empty)
            {
                yield return new ValidationResult("Id must not be default Guid", new[] {"Id"});
            }
        }
    }
}