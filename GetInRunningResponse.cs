using Newtonsoft.Json;

namespace PinnacleWrapper
{
    public class GetInRunningResponse
    {
        [JsonProperty(PropertyName = "elapsed")]
        public int Elapsed;

        [JsonProperty(PropertyName = "state")]
        public InRunningState State;

        [JsonProperty(PropertyName = "id")]
        public int Id;
    }
}
