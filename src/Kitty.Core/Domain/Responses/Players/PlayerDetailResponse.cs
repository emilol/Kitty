using System;
using System.Collections.Generic;
using Kitty.Core.Domain.Responses.Games;

namespace Kitty.Core.Domain.Responses.Players
{
    public class PlayerDetailResponse
    {
        public PlayerDetailResponse(Guid id, string name, GameResponse game)
        {
            this.Id = id;
            this.Name = name;
            this.Game = game;
        }

        public GameResponse Game { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}