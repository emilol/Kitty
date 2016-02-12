using System;
using Kitty.Core.Infrastructure;
using MediatR;

namespace Kitty.Core.Domain.Messages.Game
{
    public class GameQueryRequest : IRequest<Result<GameResult>>
    {
        public GameQueryRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}