using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class SpreadType
    {
        [JsonProperty(PropertyName = "altLineId")]
        public int AltLineId { get; set; }

        [JsonProperty(PropertyName = "hdp")]
        public decimal HomeHandicap { get; set; }

        [JsonProperty(PropertyName = "away")]
        public decimal Away { get; set; }

        [JsonProperty(PropertyName = "home")]
        public decimal Home { get; set; }
    }
}
