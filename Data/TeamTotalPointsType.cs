using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class TeamTotalPointsType
    {
        [JsonProperty(PropertyName = "away")]
        public decimal Away { get; set; }

        [JsonProperty(PropertyName = "home")]
        public decimal Home { get; set; }
    }
}
