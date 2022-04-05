using ATP.Business;
using ATP.DataAccess;
using ATP.DataAccess.API;
using ATP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ATP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly RankingsReader _rankingsReader;
        private readonly IUtilities _utilities;

        public HomeController(ApplicationDbContext db, RankingsReader rankingsReader, IUtilities utilities)
        {
            _db = db;
            _rankingsReader = rankingsReader;
            _utilities = utilities;
        }

        public async Task<ViewResult> Index()
        {
            var results = await Task.Run(() => Task.FromResult(_rankingsReader.GetTopRankingsAsync(Constants.MAXROWS)));
            return View(results.Result);
        }


        public IActionResult GetDetails(string id)
        {
            return ViewComponent("PlayerDetail", id);
        }

        public IActionResult ClearFavorites()
        {
            _utilities.ClearFavorites(1);
            return RedirectToAction("Index");
        }
        public IActionResult AddToFavorites(string playerId)
        {
            _utilities.AddToPlayerFavorites(playerId);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFavorite(string playerId)
        {
            _utilities.RemovePlayerFromVavorites(1, playerId);
            return RedirectToAction("Index");
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult RankMyFavorites()
        {
            IEnumerable<FavoritePlayer> FavPlayers = _db.FavoritePlayers.OrderBy(x => x.Id).Where(x => x.UserId == Constants.USER);

            return View(FavPlayers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class RankingsContentModel
    {
        public string RankingsSponsorUri { get; set; }
        public string TopCourtUri { get; set; }
    }

    public class Content
    {
        public RankingsContentModel RankingsContentModel { get; set; }
    }


}