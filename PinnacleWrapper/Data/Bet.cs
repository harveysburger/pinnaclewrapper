using System;
using Newtonsoft.Json;
using PinnacleWrapper.Enums;

namespace PinnacleWrapper.Data
{
    public class Bet
    {
        [JsonProperty(PropertyName = "betId")]
        public int BetId;

        [JsonProperty(PropertyName = "wagerNumber")]
        public int WagerNumber;

        [JsonProperty(PropertyName = "placedAt")]
        public DateTime PlacedAt;

        [JsonProperty(PropertyName = "win")] 
        public decimal Win;

        [JsonProperty(PropertyName = "risk")] 
        public decimal Risk;

        [JsonProperty(PropertyName = "winLoss")]
        public decimal? WinLoss;

        [JsonProperty(PropertyName = "betStatus")]
        public BetStatus BetStatus;

        [JsonProperty(PropertyName = "betType")]
        public BetType BetType;

        [JsonProperty(PropertyName = "sportId")]
        public int SportId;

        [JsonProperty(PropertyName = "leagueId")]
        public int LeagueId;

        [JsonProperty(PropertyName = "eventId")]
        public int EventId;

        [JsonProperty(PropertyName = "handicap")]
        public decimal? Handicap;

        [JsonProperty(PropertyName = "price")]
        public decimal Price;

        [JsonProperty(PropertyName = "teamName")]
        public string TeamName;

        [JsonProperty(PropertyName = "side")]
        public SideType? Side;

        [JsonProperty(PropertyName = "oddsFormat")]
        public OddsFormat OddsFormat;

        [JsonProperty(PropertyName = "customerCommission")]
        public decimal? ClientCommission;

        [JsonProperty(PropertyName = "pitcher1")]
        public string Pitcher1;

        [JsonProperty(PropertyName = "pitcher2")]
        public string Pitcher2;

        [JsonProperty(PropertyName = "pitcher1MustStart")]
        public bool? Pitcher1MustStart;

        [JsonProperty(PropertyName = "pitcher2MustStart")]
        public bool? Pitcher2MustStart;

        [JsonProperty(PropertyName = "team1")]
        public string Team1;

        [JsonProperty(PropertyName = "team2")]
        public string Team2;

        [JsonProperty(PropertyName = "periodNumber")]
        public string PeriodNumber;

        [JsonProperty(PropertyName = "team1Score")]
        public decimal? Team1Score;

        [JsonProperty(PropertyName = "team2Score")]
        public decimal? Team2Score;

        [JsonProperty(PropertyName = "ftTeam1Score")]
        public decimal? FullTimeTeam1Score;

        [JsonProperty(PropertyName = "ftTeam2Score")]
        public decimal? FullTimeTeam2Score;

        [JsonProperty(PropertyName = "pTeam1Score")]
        public decimal? PartTimeTeam1Score;

        [JsonProperty(PropertyName = "pTeam2Score")]
        public decimal? PartTimeTeam2Score;

        [JsonProperty(PropertyName = "isLive")]
        public bool IsLive;
    }
}