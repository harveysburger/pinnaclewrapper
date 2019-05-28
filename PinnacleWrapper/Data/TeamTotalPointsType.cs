using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class TeamTotalPointsType
    {
        [JsonProperty(PropertyName = "points")]
        public decimal Points { get; set; }

        [JsonProperty(PropertyName = "over")]
        public decimal Over { get; set; }

        [JsonProperty(PropertyName = "under")]
        public decimal Under { get; set; }
    }
}