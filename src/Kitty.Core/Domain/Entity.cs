using System;

namespace Kitty.Core.Domain
{
    public class Entity
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}