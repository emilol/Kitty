using Kitty.Core.Domain.Requests.Games;
using Kitty.Core.Domain.Responses.Games;
using Kitty.Core.Infrastructure;
using Kitty.Core.Persistence;
using MediatR;
using Microsoft.Data.Entity;
using Serilog;
using System.Linq;
using Kitty.Core.Infrastructure.Mappers;

namespace Kitty.Core.Domain.Handlers.Games
{
    public class GetGameDetailHandler : IRequestHandler<GetGameDetailRequest, Result<GameDetailResponse>>
    {
        private readonly IKittyContext _kittyContext;

        public GetGameDetailHandler(IKittyContext kittyContext)
        {
            _kittyContext = kittyContext;
        }

        public Result<GameDetailResponse> Handle(GetGameDetailRequest message)
        {
            Log.Information("Fetching game for id {Id}", message.Id);

            var result = _kittyContext.Games
                .Include(x => x.Players)
                .FirstOrDefault(x => x.Id == message.Id);

            return result == null
                ? Result<GameDetailResponse>.Failed($"Game with Id {message.Id} not found")
                : Result.Success(result.MapToGameDetailResponse());
        }
    }
}