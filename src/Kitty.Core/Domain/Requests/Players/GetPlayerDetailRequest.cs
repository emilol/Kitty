using System;
using Kitty.Core.Domain.Responses.Players;
using Kitty.Core.Infrastructure;
using MediatR;

namespace Kitty.Core.Domain.Requests.Players
{
    public class GetPlayerDetailRequest : IRequest<Result<PlayerDetailResponse>>
    {
        public GetPlayerDetailRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}