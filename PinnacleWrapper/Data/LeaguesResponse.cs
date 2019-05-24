using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class LeaguesResponse
    {
        [JsonProperty(PropertyName = "leagues")]
        public List<League> Leagues;
    }
}
