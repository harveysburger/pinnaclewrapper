using System;
using Newtonsoft.Json;
using PinnacleWrapper.Enums;

namespace PinnacleWrapper.Data
{
    public class GetLineResponse
    {
        [JsonProperty(PropertyName = "status")]
        public GetLineResponseStatus Status;        // if the value is NOT_EXISTS, then this will be the only parameter in the response. All other params would be empty.

        [JsonProperty(PropertyName = "price")] 
        public decimal? Price;

        [JsonProperty(PropertyName = "lineId")]
        public int? LineId;
        
        [JsonProperty(PropertyName = "altLineId")]
        public int? AltLineId;                      // This would be needed to place the bet if the handicap is on alternate line, otherwise it will not be in the response.

        [JsonProperty(PropertyName = "team1Score")]
        public int? Team1Score;                     // Soccer only

        [JsonProperty(PropertyName = "team2Score")]
        public int? Team2Score;                     // Soccer only

        [JsonProperty(PropertyName = "team1RedCards")]
        public int? Team1RedCards;                  // Soccer only

        [JsonProperty(PropertyName = "team2RedCards")]
        public int? Team2RedCards;                  // Soccer only

        [JsonProperty(PropertyName = "maxRiskStake")]
        public decimal? MaxRiskStake;

        [JsonProperty(PropertyName = "minRiskStake")]
        public decimal? MinRiskStake;

        [JsonProperty(PropertyName = "maxWinStake")]
        public decimal? MaxWinStake;

        [JsonProperty(PropertyName = "minWinStake")]
        public decimal? MinWinStake;

        [JsonProperty(PropertyName = "effectiveAsOf")]
        public DateTime? EffectiveAsOf;             // Line is effective as of this date and time
    }
}
