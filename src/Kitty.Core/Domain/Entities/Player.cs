using System;
using System.Collections.Generic;

namespace Kitty.Core.Domain.Entities
{
    public class Player : Entity
    {
        protected Player() { }

        public Player(Guid id, Game game, User user) : base(id)
        {
            Game = game;
            User = user;
        }

        public Guid GameId { get; protected set; }
        public virtual Game Game { get; protected set; }
        public Guid UserId { get; protected set; }
        public virtual User User { get; protected set; }
    }
}