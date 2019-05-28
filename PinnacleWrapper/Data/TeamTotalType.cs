using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class TeamTotalType
    {
        [JsonProperty(PropertyName = "home")]
        public TeamTotalPointsType Home { get; set; }

        [JsonProperty(PropertyName = "away")]
        public TeamTotalPointsType Away { get; set; }
    }
}
