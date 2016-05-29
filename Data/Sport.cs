using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class Sport
    {
        [JsonProperty(PropertyName = "id")]
        public int Id;

        [JsonProperty(PropertyName = "name")]
        public string Name;

        [JsonProperty(PropertyName = "hasOfferings")]
        public bool HasOfferings;
    }
}
