using System;

namespace Kitty.Core.Domain.Entities
{
    public class BankTransaction : Entity
    {
        protected BankTransaction()
        {
            
        }

        public BankTransaction(Guid id, Player player, int amount, DateTimeOffset dateCreated) : base(id)
        {
            Player = player;
            Amount = amount;
            DateCreated = dateCreated;
        }
        public virtual Player Player { get; protected set; }
        public int Amount { get; protected set; }
        public DateTimeOffset DateCreated { get; protected set; }
    }
}