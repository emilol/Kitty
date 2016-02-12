using System;

namespace Kitty.Core.Domain.Responses.Games
{
    public class GameResponse
    {
        public GameResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}