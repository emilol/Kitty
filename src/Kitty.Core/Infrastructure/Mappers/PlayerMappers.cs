using System.Linq;
using Kitty.Core.Domain.Entities;
using Kitty.Core.Domain.Responses.Players;

namespace Kitty.Core.Infrastructure.Mappers
{
    public static class PlayerMappers
    {
        public static PlayerResponse MapToPlayerResponse(this Player player)
        {
            return new PlayerResponse(player.Id, player.User.Name, player.User.Id, player.Game.Id);
        }

        public static PlayerDetailResponse MapToPlayerDetailResponse(this Player player)
        {
            var game = player.Game.MapToGameResponse();

            return new PlayerDetailResponse(player.Id, player.User.Name, game);
        }
    }
}