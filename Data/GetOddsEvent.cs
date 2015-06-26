using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class GetOddsEvent
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "periods")]
        public List<PeriodType> Periods { get; set; }

        [JsonProperty(PropertyName = "awayScore")]
        public decimal AwayScore { get; set; }

        [JsonProperty(PropertyName = "homeScore")]
        public decimal HomeScore { get; set; }

        [JsonProperty(PropertyName = "awayRedCards")]
        public decimal AwayRedCards { get; set; }

        [JsonProperty(PropertyName = "homeRedCards")]
        public decimal HomeRedCards { get; set; }
    }
}
