using ATP.Models;
using Microsoft.EntityFrameworkCore;

namespace ATP.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<FavoritePlayer> FavoritePlayers { get; set; }

        public DbSet<PlayerRef> PlayerRef { get; set; }

    }
}
