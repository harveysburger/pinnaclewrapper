using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class GetBetsResponse
    {
        [JsonProperty(PropertyName = "bets")]
        public List<Bet> Bets;
    }
}
