using System;
using System.Collections.Generic;

namespace Kitty.Core.Domain.Entities
{
    public class User : Entity
    {
        protected User() { }

        public User(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; protected set; }
        public virtual ICollection<Player> Players { get; protected set; }
    }
}