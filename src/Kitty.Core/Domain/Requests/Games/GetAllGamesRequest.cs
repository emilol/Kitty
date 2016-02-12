using System.Collections.Generic;
using Kitty.Core.Domain.Responses.Games;
using Kitty.Core.Infrastructure;
using MediatR;

namespace Kitty.Core.Domain.Requests.Games
{
    public class GetAllGamesRequest : IRequest<Result<IEnumerable<GameResponse>>> 
    {

    }
}