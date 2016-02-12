using System.Collections.Generic;
using Kitty.Core.Domain.Responses.Players;
using Kitty.Core.Infrastructure;
using MediatR;

namespace Kitty.Core.Domain.Requests.Players
{
    public class GetAllPlayersRequest : IRequest<Result<IEnumerable<PlayerResponse>>>
    {
         
    }
}