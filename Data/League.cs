using Newtonsoft.Json;
using System.Xml.Serialization;

namespace PinnacleWrapper.Data
{
    public class League
    {
        [JsonProperty(PropertyName = "id")]
        public int Id;

        [JsonProperty(PropertyName = "name")]
        public string Name;

        [JsonProperty(PropertyName = "homeTeamType")]
        public string HomeTeamType;

        [JsonProperty(PropertyName = "hasOfferings")]
        public bool HasOfferings;

        [JsonProperty(PropertyName = "allowRoundRobins")]
        public string AllowRoundRobins;
    }
}
