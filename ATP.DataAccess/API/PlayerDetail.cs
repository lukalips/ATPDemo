using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace ATP.DataAccess.API
{
    public class PlayerDetail
    {
        private readonly IMemoryCache _memoryCache;
        public PlayerDetail(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public async Task<Data> GetPlayerDetail(string playerId)
        {
            // Normally it would be a bad practice to hardcode the url
            var apiString = $"https://app.atptour.com/api/gateway/players.PlayerProfileBio?playerid={playerId}";
            Data playerDetail = new Data();
            var cacheKey = "playerDetail" + playerId;
            playerDetail = _memoryCache.Get<Data>(cacheKey);

            if (playerDetail == null)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiString))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(apiResponse);
                        playerDetail = myDeserializedClass.Data;
                    }
                }
                _memoryCache.Set(cacheKey, playerDetail, TimeSpan.FromDays(1));
            }

            return playerDetail;
        }

        private class PlayerProfileDetails
        {
            public string PlayerGladiatorUrl { get; set; }
            public string PlayerHeadshotUrl { get; set; }
            public bool HasGladiator { get; set; }
            public string TopCourtUri { get; set; }
        }

        private class Content
        {
            public PlayerProfileDetails PlayerProfileDetails { get; set; }
        }



        private class Root
        {
            public Content Content { get; set; }
            public Data Data { get; set; }
        }

    }
}

public class Data
{
    public string PlayerId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int HeroRank { get; set; }
    public bool DblSpecialist { get; set; }
    public string NatlId { get; set; }
    public string BioPersonal { get; set; }
    public string BioYearToDate { get; set; }
    public string BioCareerHighlights { get; set; }
    public string Type { get; set; }
}