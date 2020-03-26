using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class InRunningLeague
    {
        [JsonProperty(PropertyName = "id")] 
        public int Id;

        [JsonProperty(PropertyName = "events")] 
        public List<InRunningEvent> Events;
    }
}