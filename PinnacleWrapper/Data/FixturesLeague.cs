using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class FixturesLeague
    {
        [JsonProperty(PropertyName = "id")] 
        public int Id;

        [JsonProperty(PropertyName = "events")]
        public List<FixturesEvent> Events;
    }
}