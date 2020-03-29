using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class GetInRunningResponse
    {
        [JsonProperty(PropertyName = "sports")]
        public List<InRunningSport> InRunningSports { get; set; }
     
    }
}