using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class TotalPointsType
    {
        [JsonProperty(PropertyName = "altLineId")]
        public int AltLineId { get; set; }

        [JsonProperty(PropertyName = "points")]
        public decimal Points { get; set; }

        [JsonProperty(PropertyName = "over")]
        public decimal Over { get; set; }

        [JsonProperty(PropertyName = "under")]
        public decimal Under { get; set; }
    }
}
