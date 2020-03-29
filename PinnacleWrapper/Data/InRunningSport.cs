using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class InRunningSport
    {
        [JsonProperty(PropertyName = "id")] 
        public int Id;

        [JsonProperty(PropertyName = "leagues")] 
        public List<InRunningLeague> Leagues;
    }
}