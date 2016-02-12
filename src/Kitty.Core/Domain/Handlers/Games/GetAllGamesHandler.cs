using System.Collections.Generic;
using System.Linq;
using Kitty.Core.Domain.Requests.Games;
using Kitty.Core.Domain.Responses.Games;
using Kitty.Core.Infrastructure;
using Kitty.Core.Infrastructure.Mappers;
using Kitty.Core.Persistence;
using MediatR;

namespace Kitty.Core.Domain.Handlers.Games
{
    public class GetAllGamesHandler : IRequestHandler<GetAllGamesRequest, Result<IEnumerable<GameResponse>>>
    {
        private readonly IKittyContext _kittyContext;

        public GetAllGamesHandler(IKittyContext kittyContext)
        {
            _kittyContext = kittyContext;
        }

        public Result<IEnumerable<GameResponse>> Handle(GetAllGamesRequest message)
        {
            // ToDo: Change to query executor pattern 
            return Result.Success(_kittyContext.Games.AsEnumerable()
                .Select(x => x.MapToGameResponse()));
        }
    }
}