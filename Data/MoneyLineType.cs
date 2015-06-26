using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class MoneyLineType
    {
        [JsonProperty(PropertyName = "away")]
        public decimal Away { get; set; }

        [JsonProperty(PropertyName = "home")]
        public decimal Home { get; set; }

        [JsonProperty(PropertyName = "draw")]
        public decimal Draw { get; set; }
    }
}
