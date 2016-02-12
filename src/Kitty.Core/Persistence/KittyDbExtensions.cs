using System;
using System.Linq;
using Kitty.Core.Domain.Entities;

namespace Kitty.Core.Persistence
{
    public static class KittyDbExtensions
    {
        public static void EnsureSeedData(this KittyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Games.Any()) return;

            var george = new User(Guid.NewGuid(), "George");
            var emily = new User(Guid.NewGuid(), "Emily");
            var greg = new User(Guid.NewGuid(), "Greg");
            var ana = new User(Guid.NewGuid(), "Ana");
            var dean = new User(Guid.NewGuid(), "Dean");

            context.KittyUsers.Add(george);
            context.KittyUsers.Add(emily);
            context.KittyUsers.Add(greg);
            context.KittyUsers.Add(ana);
            context.KittyUsers.Add(dean);

            var game1 = new Game(Guid.NewGuid(), george, "New game name", 10000);

            game1.AddPlayer(emily);
            game1.AddPlayer(greg);
            game1.AddPlayer(ana);

            game1.CreateTransaction(george, -30);
            game1.CreateTransaction(emily, -26);
            game1.CreateTransaction(greg, -15);
            game1.CreateTransaction(ana, -25);

            var game2 = new Game(Guid.NewGuid(), emily, "Word", 10000);

            game2.AddPlayer(greg);
            game2.AddPlayer(ana);
            game2.AddPlayer(dean);

            game2.CreateTransaction(dean, -45);
            game2.CreateTransaction(emily, -22);
            game2.CreateTransaction(greg, -56);
            game2.CreateTransaction(ana, -100);

            context.Games.Add(game1);
            context.Games.Add(game2);

            context.SaveChanges();
        }
    }
}