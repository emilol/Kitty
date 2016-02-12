using System.Linq;
using Kitty.Core.Domain.Entities;
using Kitty.Core.Domain.Responses.Games;

namespace Kitty.Core.Infrastructure.Mappers
{
    public static class GameMappers
    {
        public static GameResponse MapToGameResponse(this Game game)
        {
            return new GameResponse(game.Id, game.Name);
        }

        public static GameDetailResponse MapToGameDetailResponse(this Game game)
        {
            var players = game.Players.Select(x => x.MapToPlayerResponse());

            return new GameDetailResponse(game.Id,game.Name, players);
        }
    }
}