using Kitty.Core.Domain.Requests.Players;
using Kitty.Core.Domain.Responses.Players;
using Kitty.Core.Infrastructure;
using Kitty.Core.Persistence;
using MediatR;
using System.Linq;
using Kitty.Core.Infrastructure.Mappers;
using Microsoft.Data.Entity;

namespace Kitty.Core.Domain.Handlers.Players
{
    public class GetPlayerDetailHandler : IRequestHandler<GetPlayerDetailRequest, Result<PlayerDetailResponse>>
    {
        private readonly IKittyContext _kittyContext;

        public GetPlayerDetailHandler(IKittyContext kittyContext)
        {
            _kittyContext = kittyContext;
        }

        public Result<PlayerDetailResponse> Handle(GetPlayerDetailRequest message)
        {
            var player =  _kittyContext.Players
                .Include(x => x.User)
                .Include(x => x.Game)
                .FirstOrDefault(x => x.Id == message.Id);
            if (player == null) return Result<PlayerDetailResponse>.Failed($"Player with Id {message.Id} not found");

            return Result.Success(player.MapToPlayerDetailResponse());

        }
    }
}