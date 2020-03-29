using Newtonsoft.Json;
using PinnacleWrapper.Enums;

namespace PinnacleWrapper.Data
{
    public class InRunningEvent
    {
        [JsonProperty(PropertyName = "elapsed")]
        public int Elapsed;

        [JsonProperty(PropertyName = "state")] 
        public InRunningState State;

        [JsonProperty(PropertyName = "id")] 
        public int Id;
    }
}