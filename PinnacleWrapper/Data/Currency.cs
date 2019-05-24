using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class Currency
    {
        [JsonProperty(PropertyName = "code")]
        public string Code;

        [JsonProperty(PropertyName = "name")]
        public string Name;

        [JsonProperty(PropertyName = "rate")]
        public decimal rate;
    }
}
