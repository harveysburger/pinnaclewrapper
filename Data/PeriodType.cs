using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PinnacleWrapper.Data
{
    public class PeriodType
    {
        [JsonProperty(PropertyName = "lineId")]
        public int LineId { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "cutoff")]
        public DateTime Cutoff { get; set; }

        [JsonProperty(PropertyName = "spreads")]
        public List<SpreadType> Spreads { get; set; }

        [JsonProperty(PropertyName = "totals")]
        public List<TotalPointsType> Totals { get; set; }

        [JsonProperty(PropertyName = "moneyLine")]
        public MoneyLineType MoneyLine { get; set; }

        [JsonProperty(PropertyName = "teamTotals")]
        public List<TeamTotalPointsType> TeamTotals { get; set; }

        [JsonProperty(PropertyName = "maxSpread")]
        public decimal MaxSpread { get; set; }

        [JsonProperty(PropertyName = "maxTotal")]
        public decimal MaxTotal { get; set; }

        [JsonProperty(PropertyName = "maxMoneyLine")]
        public decimal MaxMoneyLine { get; set; }

        [JsonProperty(PropertyName = "maxTeamTotal")]
        public decimal MaxTeamTotal { get; set; }
    }
}
