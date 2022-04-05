using ATP.DataAccess;
using ATP.Models;

namespace ATP.Business
{
    public class Utilities : IUtilities
    {
        private readonly ApplicationDbContext _db;
        public Utilities(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddToPlayerFavorites(string playerId)
        {
            // If it's already in favorites, don't add again
            if (!_db.FavoritePlayers.Any(p => p.PlayerId == playerId && p.UserId == 1))
            {
                var playerRef = _db.PlayerRef.Find(playerId);

                FavoritePlayer fp = new FavoritePlayer()
                {
                    PlayerId = playerId,
                    FirstName = playerRef.FirstName,
                    LastName = playerRef.LastName,
                    UserId = 1,
                };
                _db.FavoritePlayers.Add(fp);
                _db.SaveChanges();
            }
        }

        public void RemovePlayerFromVavorites(int user, string playerId)
        {
            _db.FavoritePlayers.RemoveRange(_db.FavoritePlayers.Where(x => x.UserId == 1 && x.PlayerId == playerId));
            _db.SaveChanges();
        }

        public void ClearFavorites(int userId)
        {
            _db.FavoritePlayers.RemoveRange(_db.FavoritePlayers.Where(x => x.UserId == 1));
            _db.SaveChanges();
        }

    }
}
