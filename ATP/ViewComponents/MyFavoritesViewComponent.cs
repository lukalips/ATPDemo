using ATP.DataAccess;
using ATP.Models;
using Microsoft.AspNetCore.Mvc;

namespace ATP.ViewComponents
{
    public class MyFavoritesViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public MyFavoritesViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int UserId = 1)
        {
            IEnumerable<FavoritePlayer> objFavPlayers = _db.FavoritePlayers.OrderBy(x => x.Id).Where(x => x.UserId == UserId);

            return View(objFavPlayers);
        }
    }
}
