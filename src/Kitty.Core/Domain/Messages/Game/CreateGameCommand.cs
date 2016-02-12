using Kitty.Core.Infrastructure;
using MediatR;

namespace Kitty.Core.Domain.Messages.Game
{
    public class CreateGameCommand : IRequest<Result<GameResult>>
    {
        public string Name { get; set; }
    }
}