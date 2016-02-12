using System;
using System.Collections.Generic;

namespace Kitty.Core.Domain.Responses.Players
{
    public class PlayerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }

        public PlayerResponse(Guid id, string name, Guid userId, Guid gameId)
        {
            Id = id;
            Name = name;
            UserId = userId;
            GameId = gameId;
        }
    }
}