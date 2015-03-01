using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BetType
    {
        Spread,
        MoneyLine,
        TotalPoints,
        TeamTotalPoints
    }
}
