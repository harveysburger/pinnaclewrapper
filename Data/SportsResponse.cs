using Newtonsoft.Json;
using System.Collections.Generic;

namespace PinnacleWrapper.Data
{
    public class SportsResponse
    {
        [JsonProperty(PropertyName = "sports")]
        public List<Sport> Sports;
    }
}
