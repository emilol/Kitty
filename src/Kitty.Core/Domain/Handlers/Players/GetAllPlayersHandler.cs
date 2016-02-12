using System.Collections.Generic;
using System.Linq;
using Kitty.Core.Domain.Requests.Players;
using Kitty.Core.Domain.Responses.Players;
using Kitty.Core.Infrastructure;
using Kitty.Core.Infrastructure.Mappers;
using Kitty.Core.Persistence;
using MediatR;
using Microsoft.Data.Entity;

namespace Kitty.Core.Domain.Handlers.Players
{
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersRequest, Result<IEnumerable<PlayerResponse>>>
    {
        private readonly IKittyContext _kittyContext;

        public GetAllPlayersHandler(IKittyContext kittyContext)
        {
            _kittyContext = kittyContext;
        }

        public Result<IEnumerable<PlayerResponse>> Handle(GetAllPlayersRequest message)
        {
            return Result.Success(_kittyContext
                .Players
                .Include(x => x.User)
                .Include(x => x.Game)
                .AsEnumerable()
                .Select(x => x.MapToPlayerResponse()));
        }
    }
}