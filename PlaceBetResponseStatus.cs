using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlaceBetResponseStatus
    {
        Accepted,
        PendingAcceptance,      // live bets in the danger zone
        ProcessedWithError
    }
}
