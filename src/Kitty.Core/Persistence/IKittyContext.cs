using Kitty.Core.Domain.Entities;
using Microsoft.Data.Entity;

namespace Kitty.Core.Persistence
{
    public interface IKittyContext
    {
        DbSet<Game> Games { get; set; }

        DbSet<Player> Players { get; set; }
    }
}