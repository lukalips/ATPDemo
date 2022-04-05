using ATP.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ATP.DataAccess.API
{
    public class RankingsReader
    {
        private readonly ApplicationDbContext _db;
        private readonly IMemoryCache _memoryCache;

        public RankingsReader(ApplicationDbContext db, IMemoryCache memoryCache)
        {
            _db = db;
            _memoryCache = memoryCache;
        }

        public async Task<List<Player>> GetTopRankingsAsync(int totalRankings)
        {
            // Normally it would be a bad practice to hardcode the string
            var apiString = $"https://app.atptour.com/api/gateway/rankings.ranksglrollrange?fromrank=1&torank={totalRankings}";
            List<Player> playerList = new List<Player>();
            playerList = _memoryCache.Get<List<Player>>("players");
            if (playerList == null)
            {

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiString))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(apiResponse);
                        playerList = myDeserializedClass.Data.Rankings.Players.ToList();
                    }
                }
                _memoryCache.Set("players", playerList, TimeSpan.FromHours(1));
                AddPlayersToReferenceTable(playerList);
            }
            return playerList;
        }

        public void AddPlayersToReferenceTable(List<Player> players)
        {
            foreach (var player in players)
            {
                if (!_db.PlayerRef.Any(p => p.PlayerId == player.PlayerId))
                {
                    PlayerRef playerRef = new PlayerRef()
                    {
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        PlayerId = player.PlayerId
                    };


                    _db.PlayerRef.Add(playerRef);
                    _db.SaveChanges();
                }

            }

        }
        private class RankingsContentModel
        {
            public string RankingsSponsorUri { get; set; }
            public string TopCourtUri { get; set; }
        }


        private class Content
        {
            public RankingsContentModel RankingsContentModel { get; set; }
        }
        private class Rankings
        {
            public DateTime RankDate { get; set; }
            public string Type { get; set; }
            public List<Player> Players { get; set; }
        }

        private class Data
        {
            public Rankings Rankings { get; set; }
        }

        private class Root
        {
            public Content Content { get; set; }
            public Data Data { get; set; }
        }
    }


    public class Player
    {
        public object Type { get; set; }
        public string PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NatlId { get; set; }
        public string CountryName { get; set; }
        public int AgeAtRankDate { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
        public bool IsTie { get; set; }
        public int NbrEventsPlayed { get; set; }
        public int PrevRank { get; set; }
        public int PrevPoints { get; set; }
        public int PointsDropping { get; set; }
        public int NextBestPoints { get; set; }
        public int LastWeekPosMove { get; set; }
        public string PlayerGladiatorImageCmsUrl { get; set; }
        public string PlayerHeadshotImageCmsUrl { get; set; }
        public string TopCourtLink { get; set; }
    }

    public class Rankings
    {
        public DateTime RankDate { get; set; }
        public string Type { get; set; }
        public List<Player> Players { get; set; }
    }





}
