using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kitty.Core.Domain.Entities
{
    public class Bank : Entity
    {
        protected Bank()
        {
            Transactions = new Collection<BankTransaction>();
        }

        public Bank(Guid id, int startingBalance) : base(id)
        {
            StartingBalance = startingBalance;
            Transactions = new Collection<BankTransaction>();
        }

        public int StartingBalance { get; protected set; }

        public virtual ICollection<BankTransaction> Transactions { get; protected set; }

        public void AddTransaction(BankTransaction transaction)
        {
            Transactions.Add(transaction);
        }

        public Guid GameId { get; protected set; }
        public virtual Game Game { get; protected set; }
    }
}