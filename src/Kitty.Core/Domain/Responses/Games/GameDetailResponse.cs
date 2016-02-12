using System;
using System.Collections.Generic;
using Kitty.Core.Domain.Responses.Banks;
using Kitty.Core.Domain.Responses.Players;

namespace Kitty.Core.Domain.Responses.Games
{
    public class GameDetailResponse : GameResponse
    {
        public GameDetailResponse(Guid id, string name, IEnumerable<PlayerResponse> players) : base(id, name)
        {
            Players = players;
        }

        public BankResponse Bank { get; private set; }

        public IEnumerable<PlayerResponse> Players { get; private set; }
    }
}