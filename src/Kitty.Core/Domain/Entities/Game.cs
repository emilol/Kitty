using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Kitty.Core.Domain.Entities
{
    public class Game : Entity
    {
        protected Game()
        {
            Players = new List<Player>();
        }

        public Game(Guid id, User owner, string name, int bankBalance) : base(id)
        {
            Players = new List<Player>();
            Bank = new Bank(Guid.NewGuid(), bankBalance);
            Name = name;

            AddPlayer(owner);
        }

        public virtual ICollection<Player> Players { get; protected set; }
        public Guid BankId { get; protected set; }
        public virtual Bank Bank { get; protected set; }
        public string Name { get; protected set; }

        public void SetBank(Bank bank)
        {
            Bank = bank;
        }
        public void CreateTransaction(User user, int amount)
        {
            var player = Players.SingleOrDefault(p => p.User.Id == user.Id);
            if (player == null) throw new DomainException("Cannot add transaction for player that is not in game");

            Bank.AddTransaction(new BankTransaction(Guid.NewGuid(), player, amount, DateTimeOffset.Now));
        }

        public void AddPlayer(User user)
        {
            if (Players.Any(p => p.User.Id == user.Id)) throw new DomainException("Cannot add player - player is already in game");

            Players.Add(new Player(Guid.NewGuid(), this, user));
        }
    }
}