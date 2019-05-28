using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class GetFixturesResponse
    {
        [JsonProperty(PropertyName = "sportId")]
        public int SportId;

        [JsonProperty(PropertyName = "last")] 
        public long Last;

        [JsonProperty(PropertyName = "league")]
        public List<FixturesLeague> Leagues;
    }
}