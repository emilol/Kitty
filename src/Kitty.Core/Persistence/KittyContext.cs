using System;
using Kitty.Core.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Kitty.Core.Persistence
{
    public class ApplicationUser : IdentityUser { }

    public class KittyContext : DbContext, IKittyContext
    {
        public KittyContext(DbContextOptions options) : base(options) { } 

        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<User> KittyUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Game>()
                .HasOne(x => x.Bank)
                .WithOne(x => x.Game);

            builder.Entity<Player>()
                .HasOne(x => x.Game)
                .WithMany(x => x.Players);
            
            builder.Entity<Player>()
                .HasOne(x => x.User)
                .WithMany(x => x.Players);
        }
    }
}